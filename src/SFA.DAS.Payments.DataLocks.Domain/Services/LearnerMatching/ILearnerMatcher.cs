﻿using System.Threading.Tasks;
using SFA.DAS.Payments.DataLocks.Domain.Models;

namespace SFA.DAS.Payments.DataLocks.Domain.Services.LearnerMatching
{
    public interface ILearnerMatcher
    {
        Task<LearnerMatchResult> MatchLearner(long ukprn, long uln);
    }
}
