﻿using SFA.DAS.Payments.Monitoring.Metrics.Domain.Submission;

namespace SFA.DAS.Payments.Monitoring.Metrics.Application.Submission
{
    public interface ISubmissionSummaryFactory
    {
        ISubmissionSummary Create(long ukprn, long jobId, short academicYear, byte collectionPeriod);
    }

    public class SubmissionSummaryFactory: ISubmissionSummaryFactory
    {
        public ISubmissionSummary Create(long ukprn, long jobId, short academicYear, byte collectionPeriod)
        {
            return new SubmissionSummary(ukprn, jobId, collectionPeriod, academicYear);
        }
    }
}