﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SFA.DAS.Payments.Application.Infrastructure.Logging;
using SFA.DAS.Payments.Application.Messaging;
using SFA.DAS.Payments.Core;
using SFA.DAS.Payments.Monitoring.Jobs.Application;
using SFA.DAS.Payments.Monitoring.Jobs.Application.JobProcessing;
using SFA.DAS.Payments.Monitoring.Jobs.Application.JobProcessing.PeriodEnd;
using SFA.DAS.Payments.Monitoring.Jobs.Messages.Commands;
using SFA.DAS.Payments.Monitoring.Jobs.Model;

namespace SFA.DAS.Payments.Monitoring.Jobs.JobService.Handlers.PeriodEnd
{
    public class RecordPeriodEndSubmissionWindowValidationJobHandler : IHandleMessageBatches<RecordPeriodEndSubmissionWindowValidationJob>
    {
        private readonly IPaymentLogger logger;
        private readonly IPeriodEndJobService periodEndJobService;
        private readonly IPeriodEndJobStatusManager jobStatusManager;
        private readonly IMetricsValidationService metricsValidationService;
        private readonly IJobStorageService jobStorageService;


        public RecordPeriodEndSubmissionWindowValidationJobHandler(IPaymentLogger logger, IPeriodEndJobService periodEndJobService, IPeriodEndJobStatusManager jobStatusManager, IMetricsValidationService metricsValidationService, IJobStorageService jobStorageService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.periodEndJobService = periodEndJobService ?? throw new ArgumentNullException(nameof(periodEndJobService));
            this.jobStatusManager = jobStatusManager ?? throw new ArgumentNullException(nameof(jobStatusManager));
            this.metricsValidationService = metricsValidationService ?? throw new ArgumentNullException(nameof(metricsValidationService));
            this.jobStorageService = jobStorageService ?? throw new ArgumentNullException(nameof(jobStorageService));
        }

        public async Task Handle(IList<RecordPeriodEndSubmissionWindowValidationJob> messages, CancellationToken cancellationToken)
        {
            foreach (var message in messages)
            {
                logger.LogInfo($"Handling period end submission window validation job: {message.ToJson()}");
                await periodEndJobService.RecordPeriodEndJob(message, cancellationToken);
                jobStatusManager.StartMonitoringJob(message.JobId, JobType.PeriodEndSubmissionWindowValidationJob); //todo is the status of the job handled correctly throughout the process?
                var metricsValid = await metricsValidationService.Validate(message.JobId, message.CollectionYear, message.CollectionPeriod);
                await jobStorageService.SaveJobStatus(message.JobId, metricsValid ? JobStatus.Completed : JobStatus.CompletedWithErrors, DateTimeOffset.Now, cancellationToken);
                logger.LogInfo($"Handled period end submission window validation job: {message.JobId}");
            }
        }
    }
}