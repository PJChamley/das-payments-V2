﻿using System.Globalization;
using SFA.DAS.Payments.PaymentsDue.Domain.Enums;
using SFA.DAS.Payments.PaymentsDue.Domain.Interfaces;

namespace SFA.DAS.Payments.PaymentsDue.Domain.Services
{
    public class ApprenticeshipKeyService : IApprenticeshipKeyService
    {
        public string GenerateKey(long ukprn, string learnerReferenceNumber, int frameworkCode, int pathwayCode, ProgrammeType programmeType, int standardCode, string learnAimRef)
        {
            return string.Join("-", 
                new[]
                {
                    ukprn.ToString(CultureInfo.InvariantCulture),
                    learnerReferenceNumber,
                    frameworkCode.ToString(CultureInfo.InvariantCulture),
                    pathwayCode.ToString(CultureInfo.InvariantCulture),
                    ((int)programmeType).ToString(CultureInfo.InvariantCulture),
                    standardCode.ToString(CultureInfo.InvariantCulture),
                    learnAimRef.ToString(CultureInfo.InvariantCulture)
                }
            );
        }
    }
}
