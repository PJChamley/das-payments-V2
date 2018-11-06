﻿using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using NServiceBus;
using SFA.DAS.Payments.AcceptanceTests.EndToEnd.Data;
using SFA.DAS.Payments.AcceptanceTests.EndToEnd.EventMatchers;
using SFA.DAS.Payments.ProviderPayments.Messages.Internal.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using PriceEpisode = ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output.PriceEpisode;

namespace SFA.DAS.Payments.AcceptanceTests.EndToEnd.Steps
{
    [Binding]
    public class EndToEndSteps : EndToEndStepsBase
    {

        public EndToEndSteps(FeatureContext context) : base(context)
        {
        }

        [Given(@"the provider is providing trainging for the following learners")]
        public void GivenTheProviderIsProvidingTraingingForTheFollowingLearners(Table table)
        {
            CurrentIlr = table.CreateSet<Training>().ToList();
            SfaContributionPercentage = CurrentIlr[0].SfaContributionPercentage;
        }

        [When(@"the ILR file is submitted for the learners for collection period R(.*)/(.*)")]
        public async Task WhenTheILRFileIsSubmittedForTheLearnersForCollectionPeriodRCurrentAcademicYear(byte period, string year)
        {
            var calendarPeriod = new CalendarPeriod(year.ToYear(), period);
            CollectionYear = calendarPeriod.Name.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0];
            CollectionPeriod = calendarPeriod.Period;
            var fm36Learners = new List<FM36Learner>();
            foreach (var training in CurrentIlr)
            {
                var learner = new FM36Learner();
                PopulateLearner(learner, training);
                fm36Learners.Add(learner);
            }

            await DcHelper.SendIlrSubmission(fm36Learners, TestSession.Ukprn, CollectionYear);
        }


        [Then(@"the following learner earnings should be generated")]
        public async Task ThenTheFollowingLearnerEarningsShouldBeGenerated(Table table)
        {
            var expectedEarnings = table.CreateSet<OnProgrammeEarning>().ToList();
            expectedEarnings.ForEach(e => e.DeliveryCalendarPeriod = e.DeliveryPeriod.ToCalendarPeriod());
            await WaitForIt(() => EarningEventMatcher.MatchEarnings(expectedEarnings, TestSession.Ukprn), "OnProgrammeEarning event check failure");
        }

        [Then(@"the following payments will be calculated")]
        public async Task ThenTheFollowingPaymentsWillBeCalculated(Table table)
        {
            var expectedPayments = table.CreateSet<Payment>().ToList();
            await WaitForIt(() => PaymentEventMatcher.MatchPayments(expectedPayments, TestSession.Ukprn, new CalendarPeriod(CollectionYear, CollectionPeriod)), "Payment event check failure");
        }

        [Then(@"at month end the following provider payments will be generated")]
        public async Task ThenTheFollowingProviderPaymentsWillBeGenerated(Table table)
        {
            var monthEndCommand = new ProcessProviderMonthEndCommand
            {
                CollectionPeriod = CurrentCollectionPeriod,
                Ukprn = TestSession.Ukprn,
                JobId = TestSession.JobId
            };
            await MessageSession.Send(monthEndCommand);
            var expectedPayments = table.CreateSet<ProviderPayment>().ToList();
            await WaitForIt(() => ProviderPaymentEventMatcher.MatchPayments(expectedPayments, TestSession.Ukprn), "ProviderPayment event check failure");
        }
    }
}
