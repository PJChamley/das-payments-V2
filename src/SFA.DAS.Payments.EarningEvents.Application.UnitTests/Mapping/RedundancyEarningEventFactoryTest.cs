﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Payments.EarningEvents.Application.Mapping;
using SFA.DAS.Payments.EarningEvents.Messages.Events;
using SFA.DAS.Payments.Model.Core.Incentives;

namespace SFA.DAS.Payments.EarningEvents.Application.UnitTests.Mapping
{
    [TestFixture]
    public class RedundancyEarningEventFactoryTest
    {
        [OneTimeSetUp]
        public void InitialiseMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfile<EarningsEventProfile>(); });
            Mapper.AssertConfigurationIsValid();
        }


        [TestCase(typeof(ApprenticeshipContractType1EarningEvent),
            typeof(ApprenticeshipContractType1RedundancyEarningEvent))]
        [TestCase(typeof(ApprenticeshipContractType2EarningEvent),
            typeof(ApprenticeshipContractType2RedundancyEarningEvent))]
        public void CreateRedundancyContractType_CreatesCorrectContractTypeEvents(Type inputType, Type expectedType)
        {
            var factory = new RedundancyEarningEventFactory(Mapper.Instance);
            ApprenticeshipContractTypeEarningsEvent earningEvent;

            earningEvent =
                factory.CreateRedundancyContractType(
                    (ApprenticeshipContractTypeEarningsEvent) Activator.CreateInstance(inputType));

            Assert.AreEqual(expectedType, earningEvent.GetType());
        }


        [Test]
        public void CreateRedundancyContractType_ForAct1ContractType_ShouldCreateANewEventId()
        {
            var factory = new RedundancyEarningEventFactory(Mapper.Instance);
            var earningEvent = new ApprenticeshipContractType1EarningEvent {EventId = Guid.NewGuid()};

            var createdEvent = factory.CreateRedundancyContractType(earningEvent);

            Assert.AreNotEqual(createdEvent.EventId, earningEvent.EventId);
        }

        [Test]
        public void CreateRedundancyContractType_ForAct2ContractType_ShouldCreateANewEventId()
        {
            var factory = new RedundancyEarningEventFactory(Mapper.Instance);
            var earningEvent = new ApprenticeshipContractType2EarningEvent {EventId = Guid.NewGuid()};

            var createdEvent = factory.CreateRedundancyContractType(earningEvent);

            Assert.AreNotEqual(createdEvent.EventId, earningEvent.EventId);
        }

        [Test]
        public void CreateRedundancyContractType_ForAct1RedundancyFunctionalSkillEarningsEvent_ShouldCreateANewEventId()
        {
            var factory = new RedundancyEarningEventFactory(Mapper.Instance);
            var earningEvent = new Act1FunctionalSkillEarningsEvent
            {
                EventId = Guid.NewGuid(),
                Earnings = new ReadOnlyCollection<FunctionalSkillEarning>(new List<FunctionalSkillEarning>())
            };

            var createdEvent = factory.CreateRedundancyFunctionalSkillType(earningEvent);

            createdEvent.EventId.Should().NotBe(earningEvent.EventId);
        }

        [Test]
        public void CreateRedundancyContractType_ForAct2RedundancyFunctionalSkillEarningsEvent_ShouldCreateANewEventId()
        {
            var factory = new RedundancyEarningEventFactory(Mapper.Instance);
            var earningEvent = new Act2FunctionalSkillEarningsEvent
            {
                EventId = Guid.NewGuid(),
                Earnings = new ReadOnlyCollection<FunctionalSkillEarning>(new List<FunctionalSkillEarning>())
            };

            var createdEvent = factory.CreateRedundancyFunctionalSkillType(earningEvent);

            createdEvent.EventId.Should().NotBe(earningEvent.EventId);
        }
    }
}