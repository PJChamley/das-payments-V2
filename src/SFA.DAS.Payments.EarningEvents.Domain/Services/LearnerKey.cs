﻿using SFA.DAS.Payments.EarningEvents.Messages.Internal.Commands;

namespace SFA.DAS.Payments.EarningEvents.Domain.Services
{
    public class LearnerKey
    {
        public long JobId { get; set; }
        public long Ukprn { get; set; }
        public short AcademicYear { get; set; }
        public int CollectionPeriod { get; set; }
        public long LearnerUln { get; set; }
        public string LearnerRefNo { get; set; }
        public string Key => CreateKey();
        public string LogSafeKey => CreateLogSafeKey();

        public LearnerKey()
        { }

        public LearnerKey(ProcessLearnerCommand processLearnerCommand)
        {
            JobId = processLearnerCommand.JobId;
            AcademicYear = processLearnerCommand.CollectionYear;
            CollectionPeriod = processLearnerCommand.CollectionPeriod;
            LearnerUln = processLearnerCommand.Learner.ULN;
            LearnerRefNo = processLearnerCommand.Learner.LearnRefNumber;
            Ukprn = processLearnerCommand.Ukprn;
        }

        private string CreateKey()
        {
            return $"{JobId}-{Ukprn}-{LearnerRefNo}-{LearnerUln}-{AcademicYear}-{CollectionPeriod}";
        }

        private string CreateLogSafeKey()
        {
            return $"{JobId}-{LearnerRefNo}-{AcademicYear}-{CollectionPeriod}";
        }
    }
}