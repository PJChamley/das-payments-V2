﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SFA.DAS.Payments.Model.Core;
using SFA.DAS.Payments.PaymentsDue.Messages.Events;
using SFA.DAS.Payments.RequiredPayments.Domain;
using SFA.DAS.Payments.RequiredPayments.Domain.Entities;
using SFA.DAS.Payments.RequiredPayments.Messages.Events;
using SFA.DAS.Payments.RequiredPayments.Model.Entities;

namespace SFA.DAS.Payments.RequiredPayments.Application.Handlers
{
    public class ApprenticeshipContractType2PaymentDueEventHandler : IApprenticeshipContractType2PaymentDueEventHandler
    {
        private readonly IApprenticeshipContractType2PaymentDueProcessor act2PaymentDueProcessor;
        private readonly IRepositoryCache<PaymentEntity[]> paymentHistoryCache;
        private readonly IMapper mapper;
        private readonly IApprenticeshipKeyService apprenticeshipKeyService;
        private readonly IPaymentHistoryRepository paymentHistoryRepository;
        private readonly string apprenticeshipKey;

        public ApprenticeshipContractType2PaymentDueEventHandler(IApprenticeshipContractType2PaymentDueProcessor act2PaymentDueProcessor, IRepositoryCache<PaymentEntity[]> paymentHistoryCache, IMapper mapper, IApprenticeshipKeyService apprenticeshipKeyService, IPaymentHistoryRepository paymentHistoryRepository, string apprenticeshipKey)
        {
            this.act2PaymentDueProcessor = act2PaymentDueProcessor;
            this.paymentHistoryCache = paymentHistoryCache;
            this.mapper = mapper;
            this.apprenticeshipKeyService = apprenticeshipKeyService;
            this.paymentHistoryRepository = paymentHistoryRepository;
            this.apprenticeshipKey = apprenticeshipKey;
        }

        public async Task<ApprenticeshipContractType2RequiredPaymentEvent> HandlePaymentDue(ApprenticeshipContractType2PaymentDueEvent paymentDue, CancellationToken cancellationToken)
        {
            if (paymentDue == null)
                throw new ArgumentNullException(nameof(paymentDue));

            var key = apprenticeshipKeyService.GeneratePaymentKey(paymentDue.PriceEpisodeIdentifier, paymentDue.LearningAim.Reference, (int)paymentDue.Type, paymentDue.DeliveryPeriod);

            var paymentHistoryValue = await paymentHistoryCache.TryGet(key, cancellationToken);

            var payments = paymentHistoryValue.HasValue ? paymentHistoryValue.Value.Select(p => mapper.Map<PaymentEntity, Payment>(p)).ToArray() : new Payment[0];

            var amountDue = act2PaymentDueProcessor.CalculateRequiredPaymentAmount(paymentDue.AmountDue, payments);

            if (amountDue == 0)
                return null;

            return new ApprenticeshipContractType2RequiredPaymentEvent
            {
                AmountDue = amountDue,
                Learner = paymentDue.Learner.Clone(),
                Ukprn = paymentDue.Ukprn,
                CollectionPeriod = paymentDue.CollectionPeriod.Clone(),
                DeliveryPeriod = paymentDue.DeliveryPeriod.Clone(),
                LearningAim = paymentDue.LearningAim.Clone(),
                PriceEpisodeIdentifier = paymentDue.PriceEpisodeIdentifier,
                OnProgrammeEarningType = paymentDue.Type,
                EventTime = DateTimeOffset.UtcNow,
                JobId = paymentDue.JobId
            };
        }

        public async Task PopulatePaymentHistoryCache(CancellationToken cancellationToken)
        {
            var paymentHistory = await paymentHistoryRepository.GetPaymentHistory(apprenticeshipKey, cancellationToken).ConfigureAwait(false);

            if (paymentHistory != null)
            {
                var groupedEntities = paymentHistory
                    .GroupBy(payment => apprenticeshipKeyService.GeneratePaymentKey(payment.PriceEpisodeIdentifier, payment.LearnAimReference, payment.TransactionType, new CalendarPeriod(payment.DeliveryPeriod)))
                    .ToDictionary(c => c.Key, c => c.ToArray());

                foreach (var p in groupedEntities)
                {
                    await paymentHistoryCache.Add(p.Key, p.Value, CancellationToken.None).ConfigureAwait(false);
                }
            }
        }
    }
}
