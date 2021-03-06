﻿using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Payments.Model.Core.Factories;

namespace SFA.DAS.Payments.Model.Core.UnitTests.Tests.GivenACollectionPeriod
{
    [TestFixture]
    public class WhenCallingCreateFromAcademicYearAndPeriod
    {
        [TestCase(1819, 1, 1819)]
        [TestCase(1819, 2, 1819)]
        [TestCase(1819, 3, 1819)]
        [TestCase(1819, 10, 1819)]
        [TestCase(1819, 11, 1819)]
        [TestCase(1819, 12, 1819)]
        [TestCase(1819, 13, 1819)]
        [TestCase(1819, 14, 1819)]
        [TestCase(1920, 1, 1920)]
        [TestCase(1920, 12, 1920)]
        [TestCase(1920, 13, 1920)]
        [TestCase(1920, 14, 1920)]
        public void AcademicYearIsCorrect(short academicYear, byte period, short expected)
        {
            var actual = CollectionPeriodFactory.CreateFromAcademicYearAndPeriod(academicYear, period);

            actual.AcademicYear.Should().Be(expected);
        }

        [TestCase(1819, 1, 1)]
        [TestCase(1819, 2, 2)]
        [TestCase(1819, 3, 3)]
        [TestCase(1819, 10, 10)]
        [TestCase(1819, 11, 11)]
        [TestCase(1819, 12, 12)]
        [TestCase(1819, 13, 13)]
        [TestCase(1819, 14, 14)]
        [TestCase(1920, 1, 1)]
        [TestCase(1920, 12, 12)]
        [TestCase(1920, 14, 14)]
        public void PeriodIsCorrect(short academicYear, byte period, byte expected)
        {
            var actual = CollectionPeriodFactory.CreateFromAcademicYearAndPeriod(academicYear, period);

            actual.Period.Should().Be(expected);
        }
    }
}
