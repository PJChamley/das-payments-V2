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
namespace SFA.DAS.Payments.PaymentsDue.AcceptanceTests.Tests.Non_LevyLearner_BasicDay
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("One Non-Levy Learner Finishes Late PV2-196")]
    public partial class OneNon_LevyLearnerFinishesLatePV2_196Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "One Non-Levy Learner Finishes Late PV2-196.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "One Non-Levy Learner Finishes Late PV2-196", "Provider earnings and payments where learner completes later than planned", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 7
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner finishes late")]
        [NUnit.Framework.CategoryAttribute("NonDas_BasicDay")]
        [NUnit.Framework.CategoryAttribute("finishes_late")]
        public virtual void ANon_DASLearnerLearnerFinishesLate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner finishes late", null, new string[] {
                        "NonDas_BasicDay",
                        "finishes_late"});
#line 12
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 13
 testRunner.Given("the current collection period is R05", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("planned course duration is 12 months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "AimSeqNumber",
                        "ProgrammeType",
                        "FrameworkCode",
                        "PathwayCode",
                        "StandardCode",
                        "FundingLineType",
                        "LearnAimRef",
                        "TotalNegotiatedPrice",
                        "CompletionStatus"});
            table13.AddRow(new string[] {
                        "1",
                        "2",
                        "403",
                        "1",
                        "",
                        "16-18 Apprenticeship (From May 2017) Non-Levy Contract (non-procured)",
                        "ZPROG001",
                        "15000",
                        "completed"});
#line 15
 testRunner.And("the following course information:", ((string)(null)), table13, "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table14.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table14.AddRow(new string[] {
                        "p2",
                        "5",
                        "Completion (TT2)",
                        "3000"});
#line 19
 testRunner.And("the following contract type 2 On Programme earnings are provided:", ((string)(null)), table14, "And ");
#line 24
 testRunner.When("an earnings event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table15.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table15.AddRow(new string[] {
                        "p2",
                        "5",
                        "Completion (TT2)",
                        "3000"});
#line 25
 testRunner.Then("the payments due component will generate the following contract type 2 payments d" +
                    "ue:", ((string)(null)), table15, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner withdraws after planned end date")]
        [NUnit.Framework.CategoryAttribute("NonDas_BasicDay")]
        [NUnit.Framework.CategoryAttribute("finishes_late")]
        [NUnit.Framework.CategoryAttribute("withdrawal")]
        public virtual void ANon_DASLearnerLearnerWithdrawsAfterPlannedEndDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner withdraws after planned end date", null, new string[] {
                        "NonDas_BasicDay",
                        "finishes_late",
                        "withdrawal"});
#line 35
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 36
 testRunner.Given("the current collection period is R05", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("planned course duration is 12 months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "AimSeqNumber",
                        "ProgrammeType",
                        "FrameworkCode",
                        "PathwayCode",
                        "StandardCode",
                        "FundingLineType",
                        "LearnAimRef",
                        "TotalNegotiatedPrice",
                        "CompletionStatus"});
            table16.AddRow(new string[] {
                        "1",
                        "2",
                        "403",
                        "1",
                        "",
                        "16-18 Apprenticeship (From May 2017) Non-Levy Contract (non-procured)",
                        "ZPROG001",
                        "15000",
                        "withdrawn"});
#line 38
 testRunner.And("the following course information:", ((string)(null)), table16, "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table17.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
#line 42
 testRunner.And("the following contract type 2 On Programme earnings are provided:", ((string)(null)), table17, "And ");
#line 46
 testRunner.When("an earnings event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table18.AddRow(new string[] {
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
#line 47
 testRunner.Then("the payments due component will generate the following contract type 2 payments d" +
                    "ue:", ((string)(null)), table18, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
