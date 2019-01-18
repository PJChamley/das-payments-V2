﻿using ESFA.DC.Logging.Interfaces;
using Microsoft.ServiceFabric.Actors.Client;
using SFA.DAS.Payments.Application.Infrastructure.Logging;
using SFA.DAS.Payments.RequiredPayments.Domain;
using SFA.DAS.Payments.EarningEvents.Messages.Events;

namespace SFA.DAS.Payments.RequiredPayments.RequiredPaymentsProxyService.Handlers
{
    public class FunctionalSkillEarningsEventHandler : EarningEventHandlerBase<FunctionalSkillEarningsEvent>
    {
        public FunctionalSkillEarningsEventHandler(IApprenticeshipKeyService apprenticeshipKeyService, IActorProxyFactory proxyFactory, IPaymentLogger paymentLogger, IExecutionContext executionContext) 
            : base(apprenticeshipKeyService, proxyFactory, paymentLogger, executionContext)
        {
        }
    }
}