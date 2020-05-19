﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SFA.DAS.Payments.Application.Infrastructure.Logging;
using SFA.DAS.Payments.Model.Core.Audit;

namespace SFA.DAS.Payments.Audit.Application.Data.FundingSource
{
    public interface IFundingSourceEventRepository
    {
        Task RemovePriorEvents(long ukprn, short academicYear, byte collectionPeriod, DateTime latestIlrSubmissionTime,
            CancellationToken cancellationToken);

        Task RemoveFailedSubmissionEvents(long jobId, CancellationToken cancellationToken);

        Task SaveSaveFundingSourceEvents(List<FundingSourceEventModel> fundingSourceEvents,
            CancellationToken cancellationToken);

        Task SaveFundingSourceEventsIndividually(List<FundingSourceEventModel> fundingSourceEvents,
            CancellationToken cancellationToken);
    }

    public class FundingSourceEventRepository : IFundingSourceEventRepository
    {
        
        private readonly IAuditDataContext dataContext;
        private readonly IAuditDataContextFactory retryDataContextFactory;
        private readonly IPaymentLogger logger;

        public FundingSourceEventRepository(IAuditDataContext dataContext, IAuditDataContextFactory retryDataContextFactory, IPaymentLogger logger)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            this.retryDataContextFactory = retryDataContextFactory ?? throw new ArgumentNullException(nameof(retryDataContextFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task RemovePriorEvents(long ukprn, short academicYear, byte collectionPeriod, DateTime latestIlrSubmissionTime, CancellationToken cancellationToken)
        {
            await dataContext.Database.ExecuteSqlCommandAsync($@"
                    Delete 
                        From [Payments2].[FundingSourceEvent] 
                    Where 
                        Ukprn = {ukprn}
                        And AcademicYear = {academicYear}
                        And CollectionPeriod = {collectionPeriod}
                        And IlrSubmissionDateTime < {latestIlrSubmissionTime}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task RemoveFailedSubmissionEvents(long jobId, CancellationToken cancellationToken)
        {
            await dataContext.Database.ExecuteSqlCommandAsync($@"
                    Delete 
                        From [Payments2].[FundingSourceEvent] 
                    Where 
                        JobId = {jobId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task SaveSaveFundingSourceEvents(List<FundingSourceEventModel> fundingSourceEvents, CancellationToken cancellationToken)
        {
            using (var tx = await dataContext.Database.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken).ConfigureAwait(false))
            {
                var bulkConfig = new BulkConfig
                { SetOutputIdentity = false, BulkCopyTimeout = 60, PreserveInsertOrder = false };
                await ((DbContext)dataContext).BulkInsertAsync(fundingSourceEvents, bulkConfig, null, cancellationToken)
                    .ConfigureAwait(false);
                tx.Commit();
            }
        }

        public async Task SaveFundingSourceEventsIndividually(List<FundingSourceEventModel> fundingSourceEvents, CancellationToken cancellationToken)
        {
            var mainContext = retryDataContextFactory.Create();
            using (var tx = await ((DbContext)mainContext).Database.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken).ConfigureAwait(false))
            {
                foreach (var fundingSourceEvent in fundingSourceEvents)
                {
                    try
                    {
                        var retryDataContext = retryDataContextFactory.Create(tx.GetDbTransaction());
                        await retryDataContext.FundingSourceEvent.AddAsync(fundingSourceEvent, cancellationToken).ConfigureAwait(false);
                        await retryDataContext.SaveChanges(cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        if (e.IsUniqueKeyConstraintException())
                        {
                            logger.LogInfo($"Discarding duplicate FUNDING SOURCE event. Event Id: {fundingSourceEvent.EventId}, JobId: {fundingSourceEvent.JobId}, Learn ref: {fundingSourceEvent.LearnerReferenceNumber}");
                            continue;
                        }
                        throw;
                    }
                }
                tx.Commit();
            }
        }
    }
}