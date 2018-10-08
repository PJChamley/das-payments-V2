﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Autofac;
using Microsoft.SqlServer.Dac;
using SFA.DAS.Payments.AcceptanceTests.Core;
using SFA.DAS.Payments.AcceptanceTests.Core.Infrastructure;
using SFA.DAS.Payments.Model.Core;
using SFA.DAS.Payments.RequiredPayments.AcceptanceTests.Data;
using SFA.DAS.Payments.RequiredPayments.Application;
using SFA.DAS.Payments.RequiredPayments.Application.Data;
using SFA.DAS.Payments.RequiredPayments.Model.Entities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Payments.RequiredPayments.AcceptanceTests.Steps
{
    [Binding]
    public class HistoricalPaymentSteps : StepsBase
    {
        public HistoricalPaymentSteps(ScenarioContext context) : base(context)
        {
        }

        [BeforeTestRun(Order = 40)]
        public static void SetUpPaymentsDb()
        {
            var config = new TestsConfiguration();
            var env = config.GetAppSetting("Environment");
            if (!(env?.Equals("DEVELOPMENT", StringComparison.OrdinalIgnoreCase) ?? false) 
                && !(env?.Equals("LOCAL", StringComparison.OrdinalIgnoreCase) ?? false))
            {
                return;
            }

            var instance = new DacServices(config.PaymentsConnectionString);
            var path = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(typeof(HistoricalPaymentSteps).Assembly.Location) ?? throw new InvalidOperationException("Failed to get assembly location path"),
                @"..\..\..\SFA.DAS.Payments.Database\bin\Debug\SFA.DAS.Payments.Database.dacpac"));

            using (var dacpac = DacPackage.Load(path))
            {
                instance.Deploy(dacpac, "SFA.DAS.Payments.Database", true);
            }

            Builder.Register((c, p) =>
            {
                var configHelper = c.Resolve<TestsConfiguration>();
                return new RequiredPaymentsDataContext(configHelper.GetConnectionString("PaymentsConnectionString"));
            }).As<IRequiredPaymentsDataContext>().InstancePerDependency();

//            paymentHistoryDataContext = new RequiredPaymentsDataContext(config.PaymentsConnectionString);
        }

        private void AddHistoricalPayments(IList<HistoricalPayment> payments)
        {
            var apprenticeshipKey = string.Join("-",
                TestSession.Ukprn.ToString(CultureInfo.InvariantCulture),
                TestSession.Learner.LearnRefNumber,
                TestSession.Learner.Course.FrameworkCode.ToString(CultureInfo.InvariantCulture),
                TestSession.Learner.Course.PathwayCode.ToString(CultureInfo.InvariantCulture),
                ((int) TestSession.Learner.Course.ProgrammeType).ToString(CultureInfo.InvariantCulture),
                TestSession.Learner.Course.StandardCode.ToString(CultureInfo.InvariantCulture),
                TestSession.Learner.Course.LearnAimRef.ToString(CultureInfo.InvariantCulture)
            );
            var collectionPeriod = new CalendarPeriod(CollectionYear, CollectionPeriod).Name;
            var paymentHistoryDataContext = Container.Resolve<IRequiredPaymentsDataContext>();
            var paymentEntities = paymentHistoryDataContext.PaymentHistory.Where(p => p.ApprenticeshipKey == apprenticeshipKey);
            paymentHistoryDataContext.PaymentHistory.RemoveRange(paymentEntities);

            foreach (var payment in payments)
            {
                paymentHistoryDataContext.PaymentHistory.Add(new PaymentEntity
                {
                    Id = Guid.NewGuid(),
                    PriceEpisodeIdentifier = payment.PriceEpisodeIdentifier,
                    Amount = payment.Amount,
                    TransactionType = (int)payment.Type,
                    DeliveryPeriod = new CalendarPeriod(CollectionYear, payment.DeliveryPeriod).Name,

                    ApprenticeshipKey = apprenticeshipKey,
                    CollectionPeriod = collectionPeriod,
                    Ukprn = TestSession.Ukprn,
                    LearnAimReference = TestSession.Learner.Course.LearnAimRef,
                    LearnerReferenceNumber = TestSession.Learner.LearnRefNumber
                });
            }

            paymentHistoryDataContext.SaveChanges();
        }

        [Given(@"the following historical contract type (.*) payments exist:")]
        public void GivenTheFollowingHistoricalContractTypePaymentsExist(int p0, Table table)
        {
            AddHistoricalPayments(table.CreateSet<HistoricalPayment>().ToList());
        }
    }
}