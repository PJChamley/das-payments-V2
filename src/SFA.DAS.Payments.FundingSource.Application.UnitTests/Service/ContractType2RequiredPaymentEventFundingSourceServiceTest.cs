﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SFA.DAS.Payments.FundingSource.Application.Interfaces;
using SFA.DAS.Payments.FundingSource.Application.Services;
using SFA.DAS.Payments.FundingSource.Domain.Interface;
using SFA.DAS.Payments.FundingSource.Domain.Models;
using SFA.DAS.Payments.FundingSource.Messages.Events;
using SFA.DAS.Payments.RequiredPayments.Messages.Events;

namespace SFA.DAS.Payments.FundingSource.Application.UnitTests.Service
{
    [TestFixture]
    public class ContractType2RequiredPaymentEventFundingSourceServiceTest
    {
        [Test]
        public void GetFundedPaymentsShouldCallAllPaymentProcessors()
        {
            // Arrange
            var message = new CalculatedRequiredCoInvestedAmount();
            var requiredCoInvestedPayment = new RequiredCoInvestedPayment();
            var fundingSourcePayment = new EmployerCoInvestedPayment();

            var sfaPaymentProcessor = new Mock<ICoInvestedPaymentProcessorOld>(MockBehavior.Strict);
            var employerPaymentProcessor = new Mock<ICoInvestedPaymentProcessorOld>(MockBehavior.Strict);

            var sfaPaymentEvent = new SfaCoInvestedFundingSourcePaymentEvent();

            var mapper = new Mock<ICoInvestedFundingSourcePaymentEventMapper>(MockBehavior.Strict);
            mapper.Setup(o => o.MapToRequiredCoInvestedPayment(message)).Returns(requiredCoInvestedPayment);
            mapper.Setup(o => o.MapToCoInvestedPaymentEvent(message, fundingSourcePayment)).Returns(sfaPaymentEvent);

            sfaPaymentProcessor
                .Setup(o => o.Process(requiredCoInvestedPayment)).Returns(fundingSourcePayment)
                .Verifiable();

            employerPaymentProcessor
                .Setup(o => o.Process(requiredCoInvestedPayment)).Returns(fundingSourcePayment)
                .Verifiable();

            var paymentProcessors = new List<ICoInvestedPaymentProcessorOld>
            {
               sfaPaymentProcessor.Object,
               employerPaymentProcessor.Object
            };

            // Act
            var handler = new CoInvestedFundingSourceService(paymentProcessors, mapper.Object);
            handler.GetFundedPayments(message);

            //Assert
            sfaPaymentProcessor.Verify();
            employerPaymentProcessor.Verify();
        }
    }
}