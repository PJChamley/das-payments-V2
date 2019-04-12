﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SFA.DAS.Payments.DataLocks.Domain.Interfaces;
using SFA.DAS.Payments.DataLocks.Domain.Models;
using SFA.DAS.Payments.DataLocks.Domain.Services;
using SFA.DAS.Payments.Model.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.Payments.DataLocks.Domain.UnitTests.Services
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
            ukprnMatcher = new Mock<IUkprnMatcher>();
            ulnLearnerMatcher = new Mock<IUlnLearnerMatcher>();
        }

        [Test]
        public async Task WhenLearnerProviderIsNotFoundReturnDataLockErrorCode()
        {
            DataLockErrorCode? expectedDataLockErrorCode = DataLockErrorCode.DLOCK_01;
            ukprnMatcher
                .Setup(o => o.MatchUkprn())
                .Returns(Task.FromResult(expectedDataLockErrorCode))
                .Verifiable();

            var learnerMatcher = new LearnerMatcher(ukprnMatcher.Object, ulnLearnerMatcher.Object);

            var actual = await learnerMatcher.MatchLearner(Uln);

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

            ukprnMatcher
                .Setup(o => o.MatchUkprn())
                .Returns(Task.FromResult(default(DataLockErrorCode?)))
                .Verifiable();

            ulnLearnerMatcher
                .Setup(o => o.MatchUln(Uln))
                .Returns(Task.FromResult<LearnerMatchResult>(expectedLearnerMatchResult))
                .Verifiable();

            var learnerMatcher = new LearnerMatcher(ukprnMatcher.Object, ulnLearnerMatcher.Object);

            var actual = await learnerMatcher.MatchLearner(Uln);

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
                .Setup(o => o.MatchUkprn())
                .Returns(Task.FromResult(default(DataLockErrorCode?)))
                .Verifiable();

            ulnLearnerMatcher
                .Setup(o => o.MatchUln(Uln))
                .Returns(Task.FromResult<LearnerMatchResult>(expectedLearnerMatchResult))
                .Verifiable();

            var learnerMatcher = new LearnerMatcher(ukprnMatcher.Object, ulnLearnerMatcher.Object);

            var actual = await learnerMatcher.MatchLearner(Uln);

            actual.Apprenticeships.Should().NotBeNull();
            actual.Apprenticeships.Should().HaveSameCount(expectedLearnerMatchResult.Apprenticeships);
            actual.Apprenticeships.Should().BeSameAs(expectedLearnerMatchResult.Apprenticeships);

            actual.Should().NotBeNull();
            actual.DataLockErrorCode.Should().BeNull();
        }

    }
}
