﻿using System;
using System.Threading.Tasks;
using NServiceBus;
using SFA.DAS.Payments.Application.Infrastructure.Logging;
using SFA.DAS.Payments.Core;
using SFA.DAS.Payments.Monitoring.Jobs.Messages.Commands;

namespace SFA.DAS.Payments.Monitoring.Jobs.JobService.Handlers
{
    public class RecordPeriodEndRunJobHandler : IHandleMessages<RecordPeriodEndRunJob>
    {
        private readonly IPaymentLogger logger;

        public RecordPeriodEndRunJobHandler(IPaymentLogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(RecordPeriodEndRunJob message, IMessageHandlerContext context)
        {
            logger.LogInfo($"Period end not handled yet. Job: {message.ToJson()}");
        }
    }
}