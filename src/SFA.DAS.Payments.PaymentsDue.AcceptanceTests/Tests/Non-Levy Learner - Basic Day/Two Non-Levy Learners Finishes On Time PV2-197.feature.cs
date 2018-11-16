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
    [NUnit.Framework.DescriptionAttribute("Two Non-Levy Learners Finishes On Time PV2-197")]
    public partial class TwoNon_LevyLearnersFinishesOnTimePV2_197Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Two Non-Levy Learners Finishes On Time PV2-197.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Two Non-Levy Learners Finishes On Time PV2-197", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 3
#line 4
 testRunner.Given("the current collection period is R02", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.And("the SFA contribution percentage is 90%", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.And("planned course duration is 12 months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "LearnerId"});
            table22.AddRow(new string[] {
                        "L1"});
            table22.AddRow(new string[] {
                        "L2"});
#line 8
 testRunner.And("following learners are undertaking training with a training provider", ((string)(null)), table22, "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "LearnerId",
                        "AimSeqNumber",
                        "ProgrammeType",
                        "FrameworkCode",
                        "PathwayCode",
                        "StandardCode",
                        "FundingLineType",
                        "LearnAimRef",
                        "TotalNegotiatedPrice",
                        "CompletionStatus"});
            table23.AddRow(new string[] {
                        "L1",
                        "1",
                        "2",
                        "403",
                        "1",
                        "",
                        "16-18 Apprenticeship (From May 2017) Non-Levy Contract (non-procured)",
                        "ZPROG001",
                        "15000",
                        "completed"});
            table23.AddRow(new string[] {
                        "L2",
                        "1",
                        "2",
                        "403",
                        "1",
                        "",
                        "16-18 Apprenticeship (From May 2017) Non-Levy Contract (non-procured)",
                        "ZPROG001",
                        "7500",
                        "completed"});
#line 13
 testRunner.And("the following course information for Learners:", ((string)(null)), table23, "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "LearnerId",
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table24.AddRow(new string[] {
                        "L1",
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table24.AddRow(new string[] {
                        "L1",
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "3000"});
            table24.AddRow(new string[] {
                        "L2",
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "800"});
            table24.AddRow(new string[] {
                        "L2",
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "2400"});
#line 18
 testRunner.And("the following contract type 2 On Programme earnings are provided:", ((string)(null)), table24, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Learning and Completion")]
        [NUnit.Framework.CategoryAttribute("NonLevy_BasicDay")]
        [NUnit.Framework.CategoryAttribute("MultipleLearners")]
        public virtual void LearningAndCompletion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Learning and Completion", null, new string[] {
                        "NonLevy_BasicDay",
                        "MultipleLearners"});
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 29
 testRunner.When("an earnings event is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "LearnerId",
                        "PriceEpisodeIdentifier",
                        "Delivery Period",
                        "TransactionType",
                        "Amount"});
            table25.AddRow(new string[] {
                        "L1",
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "1000"});
            table25.AddRow(new string[] {
                        "L1",
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "3000"});
            table25.AddRow(new string[] {
                        "L2",
                        "p2",
                        "1",
                        "Learning (TT1)",
                        "800"});
            table25.AddRow(new string[] {
                        "L2",
                        "p2",
                        "2",
                        "Completion (TT2)",
                        "2400"});
#line 30
 testRunner.Then("the payments due component will generate the following contract type 2 payments d" +
                    "ue:", ((string)(null)), table25, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
