﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using SFA.DAS.Payments.Application.Infrastructure.Logging;
using SFA.DAS.Payments.Application.Infrastructure.Telemetry;
using SFA.DAS.Payments.Application.Repositories;
using SFA.DAS.Payments.DataLocks.Application.Interfaces;
using SFA.DAS.Payments.DataLocks.Application.Services;
using SFA.DAS.Payments.DataLocks.DataLockService.Interfaces;
using SFA.DAS.Payments.DataLocks.Domain.Infrastructure;
using SFA.DAS.Payments.DataLocks.Domain.Services.Apprenticeships;
using SFA.DAS.Payments.DataLocks.Messages.Events;
using SFA.DAS.Payments.EarningEvents.Messages.Events;
using SFA.DAS.Payments.Model.Core.Entities;

namespace SFA.DAS.Payments.DataLocks.DataLockService
{
    [StatePersistence(StatePersistence.Volatile)]
    public class DataLockService : Actor, IDataLockService
    {
        private readonly IPaymentLogger paymentLogger;
        private readonly IActorDataCache<List<ApprenticeshipModel>> apprenticeships;
        private readonly IActorDataCache<List<long>> providers;
        private readonly IDataLockProcessor dataLockProcessor;
        private readonly IApprenticeshipUpdatedProcessor apprenticeshipUpdatedProcessor;
        private readonly ITelemetry telemetry;
        private readonly Func<IApprenticeshipRepository> apprenticeshipRepository;

       
        public DataLockService(
            ActorService actorService,
            ActorId actorId,
            IPaymentLogger paymentLogger,
            Func<IApprenticeshipRepository> apprenticeshipRepository,
            IActorDataCache<List<ApprenticeshipModel>> apprenticeships,
            IActorDataCache<List<long>> providers,
            IDataLockProcessor dataLockProcessor,
            IApprenticeshipUpdatedProcessor apprenticeshipUpdatedProcessor,
            ITelemetry telemetry
          )
            : base(actorService, actorId)
        {
            this.paymentLogger = paymentLogger;
            this.apprenticeshipRepository = apprenticeshipRepository;
            this.apprenticeships = apprenticeships;
            this.providers = providers ?? throw new ArgumentNullException(nameof(providers));
            this.dataLockProcessor = dataLockProcessor;
            this.apprenticeshipUpdatedProcessor = apprenticeshipUpdatedProcessor ?? throw new ArgumentNullException(nameof(apprenticeshipUpdatedProcessor));
            this.telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
           
        }

        public async Task<List<DataLockEvent>> HandleEarning(ApprenticeshipContractType1EarningEvent message, CancellationToken cancellationToken)
        {
            using (var operation = telemetry.StartOperation("DataLockService.HandleEarning", message.EventId.ToString()))
            {
                var stopwatch = Stopwatch.StartNew();
                await Initialise().ConfigureAwait(false);
                var dataLockEvents = await dataLockProcessor.GetPaymentEvents(message, cancellationToken);
                telemetry.TrackDuration("DataLockService.HandleEarning", stopwatch, message);
                telemetry.StopOperation(operation);
                return dataLockEvents;
            }
        }

        public async Task<List<FunctionalSkillDataLockEvent>> HandleFunctionalSkillEarning(Act1FunctionalSkillEarningsEvent message, CancellationToken cancellationToken)
        {
            using (var operation = telemetry.StartOperation("DataLockService.HandleFunctionalSkillEarning", message.EventId.ToString()))
            {
                var stopwatch = Stopwatch.StartNew();
                await Initialise().ConfigureAwait(false);
                var dataLockEvents = await dataLockProcessor.GetFunctionalSkillPaymentEvents(message, cancellationToken);
                telemetry.TrackDuration("DataLockService.HandleFunctionalSkillEarning", stopwatch, message);
                telemetry.StopOperation(operation);
                return dataLockEvents;
            }
        }

        public async Task<List<InvalidatedPayableEarningEvent>> HandleApprenticeshipUpdated(ApprenticeshipUpdated message, CancellationToken none)
        {
            using (var operation = telemetry.StartOperation("DataLockService.HandleApprenticeshipUpdated", message.EventId.ToString()))
            {
                var stopwatch = Stopwatch.StartNew();
                await Initialise().ConfigureAwait(false);
                var invalidatedPayableEarningEvents =  await apprenticeshipUpdatedProcessor.ProcessApprenticeshipUpdate(message);
                TrackInfrastructureEvent("DataLockService.HandleApprenticeshipUpdated", stopwatch);
                telemetry.StopOperation(operation);
                return invalidatedPayableEarningEvents;
            }
        }

        public async Task<List<DataLockEvent>> GetApprenticeshipUpdatedPayments(ApprenticeshipUpdated message, CancellationToken none)
        {
            using (var operation = telemetry.StartOperation("DataLockService.HandleApprenticeshipUpdated", message.EventId.ToString()))
            {
                var stopwatch = Stopwatch.StartNew();
                await Initialise().ConfigureAwait(false);
                var payments = await apprenticeshipUpdatedProcessor.GetApprenticeshipUpdatePayments(message).ConfigureAwait(false);
                TrackInfrastructureEvent("DataLockService.GetApprenticeshipUpdatedPayments", stopwatch);
                telemetry.StopOperation(operation);

                return payments;
            }
        }

        public async Task<List<FunctionalSkillDataLockEvent>> GetApprenticeshipUpdateFunctionalSkillPayments(ApprenticeshipUpdated message, CancellationToken none)
        {
            using (var operation = telemetry.StartOperation("DataLockService.HandleApprenticeshipUpdated", message.EventId.ToString()))
            {
                var stopwatch = Stopwatch.StartNew();
                await Initialise().ConfigureAwait(false);
                var payments = await apprenticeshipUpdatedProcessor.GetApprenticeshipUpdateFunctionalSkillPayments(message).ConfigureAwait(false);
                TrackInfrastructureEvent("DataLockService.GetApprenticeshipUpdatedPayments", stopwatch);
                telemetry.StopOperation(operation);

                return payments;
            }
        }

        public async Task Reset()
        {
            paymentLogger.LogVerbose($"Resetting actor for id {Id}");
            await apprenticeships.ResetInitialiseFlag().ConfigureAwait(false);
            paymentLogger.LogInfo($"Reset actor for Id {Id}");
        }

        protected override async Task OnActivateAsync()
        {
            using (var operation = telemetry.StartOperation("DataLockService.OnActivateAsync", $"{Id}_{Guid.NewGuid():N}"))
            {
                paymentLogger.LogDebug($"Activating data-lock actor: {Id}");
                var stopwatch = Stopwatch.StartNew();
                await Initialise().ConfigureAwait(false);
                await base.OnActivateAsync().ConfigureAwait(false);
                TrackInfrastructureEvent("DataLockService.OnActivateAsync", stopwatch);
                telemetry.StopOperation(operation);
                paymentLogger.LogInfo($"Finished activating data-lock actor: {Id}");
            }
        }

        private async Task Initialise()
        {
            try
            {
                paymentLogger.LogVerbose($"Actor already initialised for apprenticeship {Id}");
                if (await this.apprenticeships.IsInitialiseFlagIsSet())
                    return;
                var stopwatch = Stopwatch.StartNew();
                paymentLogger.LogInfo($"Initialising actor {Id}");
                var uln = long.Parse(Id.ToString());
                using (var repository = apprenticeshipRepository())
                {
                    var providerApprenticeships = await repository.ApprenticeshipsByUln(uln).ConfigureAwait(false);
                    await this.apprenticeships.AddOrReplace(uln.ToString(), providerApprenticeships).ConfigureAwait(false);
                    await this.apprenticeships.AddOrReplace(CacheKeys.DuplicateApprenticeshipsKey, providerApprenticeships).ConfigureAwait(false); //TODO: no need for this anymore
                    var providerIds = await repository.GetProviderIds();
                    await this.providers.AddOrReplace(CacheKeys.ProvidersKey, providerIds).ConfigureAwait(false);
                }
                await apprenticeships.SetInitialiseFlag().ConfigureAwait(false);
                paymentLogger.LogInfo($"Initialised actor for Id {Id}");
                stopwatch.Stop();
                TrackInfrastructureEvent("DataLockService.Initialise", stopwatch);
            }
            catch (Exception e)
            {
                paymentLogger.LogError($"Error initialising the actor: {Id}. Error: {e.Message}", e);
                throw;
            }
        }
        
        private void TrackInfrastructureEvent(string eventName, Stopwatch stopwatch)
        {
            telemetry.TrackEvent(eventName,
                new Dictionary<string, string>
                {
                    { "ActorId",Id.ToString()},
                    { TelemetryKeys.Ukprn, Id.ToString()},
                },
                new Dictionary<string, double>
                {
                    { TelemetryKeys.Duration, stopwatch.ElapsedMilliseconds }
                });
        }
    }
}
