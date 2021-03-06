﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Payments.DataLocks.Domain.Models;
using SFA.DAS.Payments.DataLocks.Domain.Services;
using SFA.DAS.Payments.DataLocks.Domain.Services.LearnerMatching;
using SFA.DAS.Payments.Model.Core;
using SFA.DAS.Payments.Model.Core.Entities;

namespace SFA.DAS.Payments.DataLocks.Domain.UnitTests.Services.LearnerMatching
{
    [TestFixture]
    public class LearnerMatcherTest
    {
        private Mock<IUlnLearnerMatcher> ulnLearnerMatcher;
        private Mock<IUkprnMatcher> ukprnMatcher;
        private const long Uln = 1000;

        [SetUp]
        public void SetUpTest()
        {
            ukprnMatcher = new Mock<IUkprnMatcher>(MockBehavior.Strict);
            ulnLearnerMatcher = new Mock<IUlnLearnerMatcher>(MockBehavior.Strict);
        }

        [TearDown]
        public void CleanUp()
        {
            ukprnMatcher.Verify();
            ulnLearnerMatcher.Verify();
        }

        [Test]
        public async Task WhenLearnerProviderIsNotFoundReturnDataLockErrorCode()
        {
            ulnLearnerMatcher
                .Setup(o => o.MatchUln(Uln))
                .Returns(Task.FromResult<LearnerMatchResult>(new LearnerMatchResult
                {
                    Apprenticeships = new List<ApprenticeshipModel> { new ApprenticeshipModel() }
                }))
                .Verifiable();

            DataLockErrorCode? expectedDataLockErrorCode = DataLockErrorCode.DLOCK_01;
            ukprnMatcher
                .Setup(o => o.MatchUkprn(It.IsAny<long>(), It.IsAny<List<ApprenticeshipModel>>()))
                .Returns(new LearnerMatchResult{ DataLockErrorCode = expectedDataLockErrorCode } )
                .Verifiable();

            var learnerMatcher = new LearnerMatcher(ukprnMatcher.Object, ulnLearnerMatcher.Object);

            var actual = await learnerMatcher.MatchLearner(1234,Uln);

            actual.DataLockErrorCode.Should().NotBeNull();
            actual.DataLockErrorCode.Should().Be(expectedDataLockErrorCode);
        }

        [Test]
        public async Task WhenLearnerApprenticeshipsAreNotFoundReturnDataLockErrorCode()
        {
            var expectedLearnerMatchResult = new LearnerMatchResult
            {
                DataLockErrorCode = DataLockErrorCode.DLOCK_02
            };
            
            ulnLearnerMatcher
                .Setup(o => o.MatchUln(Uln))
                .Returns(Task.FromResult<LearnerMatchResult>(expectedLearnerMatchResult))
                .Verifiable();

            var learnerMatcher = new LearnerMatcher(ukprnMatcher.Object, ulnLearnerMatcher.Object);

            var actual = await learnerMatcher.MatchLearner(1234,Uln);
            actual.Should().NotBeNull();
            actual.DataLockErrorCode.Should().Be(expectedLearnerMatchResult.DataLockErrorCode);

            actual.Apprenticeships.Should().BeNull();
        }

        [Test]
        public async Task WhenLearnerApprenticeshipsAreFoundReturnApprenticeships()
        {
            var expectedLearnerMatchResult = new LearnerMatchResult
            {
                Apprenticeships = new List<ApprenticeshipModel> { new ApprenticeshipModel() }
            };

            ukprnMatcher
                .Setup(o => o.MatchUkprn(It.IsAny<long>(), It.IsAny<List<ApprenticeshipModel>>()))
                .Returns(expectedLearnerMatchResult)
                .Verifiable();

            ulnLearnerMatcher
                .Setup(o => o.MatchUln(Uln))
                .Returns(Task.FromResult<LearnerMatchResult>(expectedLearnerMatchResult))
                .Verifiable();

            var learnerMatcher = new LearnerMatcher(ukprnMatcher.Object, ulnLearnerMatcher.Object);

            var actual = await learnerMatcher.MatchLearner(1234,Uln);

            actual.Should().NotBeNull();
            actual.DataLockErrorCode.Should().BeNull();

            actual.Apprenticeships.Should().NotBeNull();
            actual.Apprenticeships.Should().BeSameAs(expectedLearnerMatchResult.Apprenticeships);
        }

    }
}
