﻿using System;
using System.Collections.Generic;
using DCT.TestDataGenerator.Functor;
using SFA.DAS.Payments.AcceptanceTests.Core.Data;
using SFA.DAS.Payments.AcceptanceTests.EndToEnd.LearnerMutators.NonLevy.BasicDay;
using SFA.DAS.Payments.AcceptanceTests.EndToEnd.LearnerMutators.NonLevy.SmallEmployer;

namespace SFA.DAS.Payments.AcceptanceTests.EndToEnd.LearnerMutators
{
    public class LearnerMutatorFactory
    {
        public static ILearnerMultiMutator Create(string featureNumber, IEnumerable<LearnerRequest> learnerRequests = null, IEnumerable<Learner> learners = null)
        {
            switch (featureNumber)
            {
                case "199":
                case "261":
                case "262":
                case "282":
                case "283":
                case "334":
                case "335":
                case "336":
                case "337":
                case "402":
                case "427":
                case "615":
                    return new Framework593Learner(learnerRequests, featureNumber);
                case "485":
                    return new Framework593Learner(learners, featureNumber);
                case "487":
                case "326":
                    return new Framework403Learner(learnerRequests, featureNumber);
                case "277":
                    return new Framework593LearnerWithdrawsAfterQualifyingPeriod(learnerRequests);
                case "278":
                    return new Framework593LearnerWithdrawsAfterPlannedEndDate(learnerRequests);
                case "328":
                    return new Framework403LearnerWithEHCPlanAndSmallEmployer(learnerRequests);
                default:
                    throw new ArgumentException("A valid feature number is required.", nameof(featureNumber));
            }
        }
    }
}