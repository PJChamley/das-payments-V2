﻿using System;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Payments.FundingSource.Messages.Events;
using SFA.DAS.Payments.Model.Core;
using SFA.DAS.Payments.Model.Core.Entities;
using SFA.DAS.Payments.ProviderPayments.Application.Mapping;
using SFA.DAS.Payments.ProviderPayments.Messages;
using SFA.DAS.Payments.ProviderPayments.Model;

namespace SFA.DAS.Payments.ProviderPayments.Application.UnitTests.Mapping
{
    [TestFixture]
    public class FundingSourcePaymentEventMappingTests
    {

        [OneTimeSetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ProviderPaymentsProfile>(); });
            Mapper.AssertConfigurationIsValid();
        }


        [Test]
        public void CanMapFromEmployerCoInvestedFundingSourceEventToPayment()
        {
            var employerCoInvested = new EmployerCoInvestedFundingSourcePaymentEvent
            {
                EventId = Guid.NewGuid(),
                CollectionPeriod = new CollectionPeriod { Period = 12, AcademicYear = 1819 },
                Learner = new Learner { ReferenceNumber = "1234-ref", Uln = 123456 },
                TransactionType = TransactionType.Completion,
                Ukprn = 12345,
                ContractType = ContractType.Act1,
                SfaContributionPercentage = 0.9m,
                PriceEpisodeIdentifier = "pe-1",
                JobId = 123,
                AmountDue = 300,
                FundingSourceType = FundingSourceType.CoInvestedEmployer,
                DeliveryPeriod = 12,
                LearningAim = new LearningAim
                {
                    PathwayCode = 12,
                    FrameworkCode = 1245,
                    FundingLineType = "Non-DAS 16-18 Learner",
                    StandardCode = 1209,
                    ProgrammeType = 7890,
                    Reference = "1234567-aim-ref"
                },
                IlrSubmissionDateTime = DateTime.UtcNow,
                EventTime = DateTimeOffset.UtcNow,
                RequiredPaymentEventId = Guid.NewGuid()
            };
            var payment = Mapper.Map<EmployerCoInvestedFundingSourcePaymentEvent, ProviderPaymentEventModel>(employerCoInvested);
            payment.Ukprn.Should().Be(employerCoInvested.Ukprn);
            payment.CollectionPeriod.Should().Be(employerCoInvested.CollectionPeriod.Period);
            payment.AcademicYear.Should().Be(employerCoInvested.CollectionPeriod.AcademicYear);
            payment.DeliveryPeriod.Should().Be(employerCoInvested.DeliveryPeriod);
            payment.FundingSourceId.Should().Be(employerCoInvested.EventId);
            payment.ContractType.Should().Be(employerCoInvested.ContractType);
            payment.SfaContributionPercentage.Should().Be(employerCoInvested.SfaContributionPercentage);
            payment.Amount.Should().Be(employerCoInvested.AmountDue);
            payment.FundingSource.Should().Be(employerCoInvested.FundingSourceType);
            payment.JobId.Should().Be(employerCoInvested.JobId);
            payment.IlrSubmissionDateTime.Should().Be(employerCoInvested.IlrSubmissionDateTime);
        }

        [Test]
        public void CanMapFromLevyFundingSourcePaymentEventToPayment()
        {
            var agreementId = "AGREEMENT";

            var levy = new LevyFundingSourcePaymentEvent
            {
                EventId = Guid.NewGuid(),
                CollectionPeriod = new CollectionPeriod { Period = 12, AcademicYear = 1819 },
                Learner = new Learner { ReferenceNumber = "1234-ref", Uln = 123456 },
                TransactionType = TransactionType.Completion,
                Ukprn = 12345,
                ContractType = ContractType.Act1,
                SfaContributionPercentage = 0.9m,
                PriceEpisodeIdentifier = "pe-1",
                JobId = 123,
                AmountDue = 300,
                FundingSourceType = FundingSourceType.CoInvestedEmployer,
                DeliveryPeriod = 12,
                LearningAim = new LearningAim
                {
                    PathwayCode = 12,
                    FrameworkCode = 1245,
                    FundingLineType = "Non-DAS 16-18 Learner",
                    StandardCode = 1209,
                    ProgrammeType = 7890,
                    Reference = "1234567-aim-ref"
                },
                IlrSubmissionDateTime = DateTime.UtcNow,
                EventTime = DateTimeOffset.UtcNow,
                AgreementId = agreementId,
                RequiredPaymentEventId = Guid.NewGuid()
            };

            var payment = Mapper.Map<ProviderPaymentEventModel>(levy);
            payment.Ukprn.Should().Be(levy.Ukprn);
            payment.CollectionPeriod.Should().Be(levy.CollectionPeriod.Period);
            payment.AcademicYear.Should().Be(levy.CollectionPeriod.AcademicYear);
            payment.DeliveryPeriod.Should().Be(levy.DeliveryPeriod);
            payment.FundingSourceId.Should().Be(levy.EventId);
            payment.ContractType.Should().Be(levy.ContractType);
            payment.SfaContributionPercentage.Should().Be(levy.SfaContributionPercentage);
            payment.Amount.Should().Be(levy.AmountDue);
            payment.FundingSource.Should().Be(levy.FundingSourceType);
            payment.JobId.Should().Be(levy.JobId);
            payment.IlrSubmissionDateTime.Should().Be(levy.IlrSubmissionDateTime);
        }

        [Test]
        public void CanMapFromEmployerCoInvestedFundingSourceEventToEmployerCoInvestedProviderPaymentEvent()
        {
            var employerCoInvested = new EmployerCoInvestedFundingSourcePaymentEvent
            {
                EventId = Guid.NewGuid(),
                CollectionPeriod = new CollectionPeriod { Period = 12, AcademicYear = 1819 },
                Learner = new Learner { ReferenceNumber = "1234-ref", Uln = 123456 },
                TransactionType = TransactionType.Completion,
                Ukprn = 12345,
                ContractType = ContractType.Act1,
                SfaContributionPercentage = 0.9m,
                PriceEpisodeIdentifier = "pe-1",
                JobId = 123,
                AmountDue = 300,
                FundingSourceType = FundingSourceType.CoInvestedEmployer,
                DeliveryPeriod = 12,
                LearningAim = new LearningAim
                {
                    PathwayCode = 12,
                    FrameworkCode = 1245,
                    FundingLineType = "Non-DAS 16-18 Learner",
                    StandardCode = 1209,
                    ProgrammeType = 7890,
                    Reference = "1234567-aim-ref"
                },
                IlrSubmissionDateTime = DateTime.UtcNow,
                EventTime = DateTimeOffset.UtcNow,
                RequiredPaymentEventId = Guid.NewGuid()
            };
            var payment = Mapper.Map<EmployerCoInvestedFundingSourcePaymentEvent, EmployerCoInvestedProviderPaymentEvent>(employerCoInvested);
            payment.Ukprn.Should().Be(employerCoInvested.Ukprn);
            payment.CollectionPeriod.Period.Should().Be(employerCoInvested.CollectionPeriod.Period);
            payment.CollectionPeriod.AcademicYear.Should().Be(employerCoInvested.CollectionPeriod.AcademicYear);
            payment.DeliveryPeriod.Should().Be(employerCoInvested.DeliveryPeriod);
            //payment.FundingSourceId.Should().Be(employerCoInvested.EventId);
            payment.ContractType.Should().Be((byte)employerCoInvested.ContractType);
            payment.SfaContributionPercentage.Should().Be(employerCoInvested.SfaContributionPercentage);
            payment.AmountDue.Should().Be(employerCoInvested.AmountDue);
            payment.FundingSourceType.Should().Be(employerCoInvested.FundingSourceType);
            payment.JobId.Should().Be(employerCoInvested.JobId);
            payment.IlrSubmissionDateTime.Should().Be(employerCoInvested.IlrSubmissionDateTime);
        }

    }

    
}