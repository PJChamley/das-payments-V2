﻿using SFA.DAS.Payments.Model.Core;
using System;

namespace SFA.DAS.Payments.Messages.Core.Events
{
    public interface IPaymentsEvent : IPaymentsMessage
    {
        DateTimeOffset EventTime { get; }
        Guid Id { get; }
        long Ukprn { get; }
        Learner Learner { get; }
        LearningAim LearningAim { get; }
        DateTime IlrSubmissionDateTime { get; }

    }
}