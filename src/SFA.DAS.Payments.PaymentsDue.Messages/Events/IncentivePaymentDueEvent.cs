﻿using SFA.DAS.Payments.Model.Core.Incentives;

namespace SFA.DAS.Payments.PaymentsDue.Messages.Events
{
    public class IncentivePaymentDueEvent : PaymentDueEvent
    {
        public IncentiveType Type { get; set; }
    }
}