﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.DAS.Payments.RequiredPayments.AcceptanceTests.Tests.Non_LevyLearner_BasicDay
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("One Non-Levy Learner Finishes Early PV2-195")]
    public partial class OneNon_LevyLearnerFinishesEarlyPV2_195Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "One Non-Levy Learner Finishes Early PV2-195.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "One Non-Levy Learner Finishes Early PV2-195", "Provider earnings and payments where learner completes earlier than planned", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
 testRunner.Given("a learner is undertaking a training with a training provider", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("the SFA contribution percentage is 90%", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner finishes early")]
        [NUnit.Framework.CategoryAttribute("NonDas_BasicDay")]
        [NUnit.Framework.CategoryAttribute("finishes_early")]
        public virtual void ANon_DASLearnerLearnerFinishesEarly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner finishes early", null, new string[] {
                        "NonDas_BasicDay",
                        "finishes_early"});
#line 11
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 12
 testRunner.Given("the current collection period is R02", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table1.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table1.AddRow(new string[] {
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "3750"});
            table1.AddRow(new string[] {
                        "p2",
                        "2",
                        "Balancing (TT3)",
                        "3000"});
#line 15
 testRunner.And("the payments due component generates the following contract type 2 payments due:", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table2.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
#line 21
 testRunner.And("the following historical contract type 2 payments exist:", ((string)(null)), table2, "And ");
#line 25
 testRunner.When("a payments due event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table3.AddRow(new string[] {
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "3750"});
            table3.AddRow(new string[] {
                        "p2",
                        "2",
                        "Balancing (TT3)",
                        "3000"});
#line 26
 testRunner.Then("the required payments component will only generate contract type 2 required payme" +
                    "nts", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner finishes early - no history")]
        [NUnit.Framework.CategoryAttribute("NonDas_BasicDay")]
        [NUnit.Framework.CategoryAttribute("finishes_early")]
        [NUnit.Framework.CategoryAttribute("NoHistory")]
        public virtual void ANon_DASLearnerLearnerFinishesEarly_NoHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner finishes early - no history", null, new string[] {
                        "NonDas_BasicDay",
                        "finishes_early",
                        "NoHistory"});
#line 36
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 37
 testRunner.Given("the current collection period is R02", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table4.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table4.AddRow(new string[] {
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "3750"});
            table4.AddRow(new string[] {
                        "p2",
                        "2",
                        "Balancing (TT3)",
                        "3000"});
#line 40
 testRunner.And("the payments due component generates the following contract type 2 payments due:", ((string)(null)), table4, "And ");
#line 46
 testRunner.When("a payments due event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table5.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table5.AddRow(new string[] {
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "3750"});
            table5.AddRow(new string[] {
                        "p2",
                        "2",
                        "Balancing (TT3)",
                        "3000"});
#line 47
 testRunner.Then("the required payments component will only generate contract type 2 required payme" +
                    "nts", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner withdraws after qualifying period")]
        [NUnit.Framework.CategoryAttribute("withdrawal")]
        public virtual void ANon_DASLearnerLearnerWithdrawsAfterQualifyingPeriod()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner withdraws after qualifying period", null, new string[] {
                        "withdrawal"});
#line 55
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 56
 testRunner.Given("the current collection period is R06", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table6.AddRow(new string[] {
                        "p1",
                        "2",
                        "Learning (TT1)",
                        "1000"});
            table6.AddRow(new string[] {
                        "p1",
                        "3",
                        "Learning (TT1)",
                        "1000"});
            table6.AddRow(new string[] {
                        "p1",
                        "4",
                        "Learning (TT1)",
                        "1000"});
            table6.AddRow(new string[] {
                        "p1",
                        "5",
                        "Learning (TT1)",
                        "1000"});
#line 59
 testRunner.And("the payments due component generates the following contract type 2 payments due:", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table7.AddRow(new string[] {
                        "p1",
                        "2",
                        "Learning (TT1)",
                        "1000"});
            table7.AddRow(new string[] {
                        "p1",
                        "3",
                        "Learning (TT1)",
                        "1000"});
            table7.AddRow(new string[] {
                        "p1",
                        "4",
                        "Learning (TT1)",
                        "1000"});
            table7.AddRow(new string[] {
                        "p1",
                        "5",
                        "Learning (TT1)",
                        "1000"});
#line 66
 testRunner.And("the following historical contract type 2 payments exist:", ((string)(null)), table7, "And ");
#line 73
 testRunner.When("a payments due event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.Then("the required payments component will not generate any contract type 2 payable ear" +
                    "nings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner withdraws after qualifying period - partial history")]
        [NUnit.Framework.CategoryAttribute("withdrawal")]
        [NUnit.Framework.CategoryAttribute("PartialHistory")]
        public virtual void ANon_DASLearnerLearnerWithdrawsAfterQualifyingPeriod_PartialHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner withdraws after qualifying period - partial history", null, new string[] {
                        "withdrawal",
                        "PartialHistory"});
#line 79
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 80
 testRunner.Given("the current collection period is R06", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table8.AddRow(new string[] {
                        "p1",
                        "2",
                        "Learning (TT1)",
                        "1000"});
            table8.AddRow(new string[] {
                        "p1",
                        "3",
                        "Learning (TT1)",
                        "1000"});
            table8.AddRow(new string[] {
                        "p1",
                        "4",
                        "Learning (TT1)",
                        "1000"});
            table8.AddRow(new string[] {
                        "p1",
                        "5",
                        "Learning (TT1)",
                        "1000"});
#line 83
 testRunner.And("the payments due component generates the following contract type 2 payments due:", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table9.AddRow(new string[] {
                        "p1",
                        "2",
                        "Learning (TT1)",
                        "1000"});
            table9.AddRow(new string[] {
                        "p1",
                        "3",
                        "Learning (TT1)",
                        "1000"});
#line 90
 testRunner.And("the following historical contract type 2 payments exist:", ((string)(null)), table9, "And ");
#line 95
 testRunner.When("a payments due event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table10.AddRow(new string[] {
                        "p1",
                        "4",
                        "Learning (TT1)",
                        "1000"});
            table10.AddRow(new string[] {
                        "p1",
                        "5",
                        "Learning (TT1)",
                        "1000"});
#line 96
 testRunner.Then("the required payments component will only generate contract type 2 required payme" +
                    "nts", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
