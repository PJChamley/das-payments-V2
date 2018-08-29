﻿using Autofac;
using ESFA.DC.Logging.Interfaces;
using NServiceBus;
using SFA.DAS.Payments.Application.Infrastructure.Logging;
using SFA.DAS.Payments.Messages.Core;
using SFA.DAS.Payments.RequiredPayments.Messages.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.Payments.FundingSource.NonLevyFundedService.Handlers
{
    public class CalculatedPaymentDueEventHandler : IHandleMessages<CalculatedPaymentDueEvent>
    {
        private readonly IPaymentLogger _paymentLogger;
        private readonly ILifetimeScope _lifetimeScope;

        public CalculatedPaymentDueEventHandler(IPaymentLogger paymentLogger, ILifetimeScope lifetimeScope)
        {
            _paymentLogger = paymentLogger;
            _lifetimeScope = lifetimeScope;
        }

        public async Task Handle(CalculatedPaymentDueEvent message, IMessageHandlerContext context)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                _paymentLogger.LogInfo($"Processing CalculatedPaymentDueEvent Service event. Message Id : {context.MessageId}");

                var executionContext = (ESFA.DC.Logging.ExecutionContext)_lifetimeScope.Resolve<IExecutionContext>();
                executionContext.JobId = message.JobId;

                try
                {
                    //TODO Logic to generate Payments
                    var payments = new List<RecordablePaymentEvent>
                    {
                        new RecordablePaymentEvent
                        {
                            JobId =  message.JobId,
                            EventTime = DateTime.UtcNow
                         }
                    };

                    foreach (var recordablePaymentEvent in payments)
                    {
                        try
                        {
                            await context.Publish(recordablePaymentEvent);
                        }
                        catch (Exception ex)
                        {
                            //TODO: add more details when we flesh out the event.
                            _paymentLogger.LogError($"Error publishing the event: RecordablePaymentEvent", ex);
                            throw;
                            //TODO: update the job
                        }
                    }

                    _paymentLogger.LogInfo($"Successfully processed NonLevyFunded Service event for Actor Id {message.JobId}");
                }
                catch (Exception ex)
                {
                    _paymentLogger.LogError($"Error while handling NonLevyFundedService event", ex);
                    throw;
                }
            }
        }
    }
}
