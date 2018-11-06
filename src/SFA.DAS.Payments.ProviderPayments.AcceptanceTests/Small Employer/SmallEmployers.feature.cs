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
namespace SFA.DAS.Payments.ProviderPayments.AcceptanceTests.SmallEmployer
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("non-DAS learner employed with a small employer, is fully funded for on programme " +
        "and completion payments")]
    public partial class Non_DASLearnerEmployedWithASmallEmployerIsFullyFundedForOnProgrammeAndCompletionPaymentsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SmallEmployers.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "non-DAS learner employed with a small employer, is fully funded for on programme " +
                    "and completion payments", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("a learner is undertaking a training with a training provider", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.And("the payments are for the current collection year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC1-Payment for a 16-18 non-DAS learner, small employer at start")]
        [NUnit.Framework.CategoryAttribute("SmallEmployerNonDas")]
        public virtual void AC1_PaymentForA16_18Non_DASLearnerSmallEmployerAtStart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC1-Payment for a 16-18 non-DAS learner, small employer at start", null, new string[] {
                        "SmallEmployerNonDas"});
#line 8
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 9
 testRunner.Given("the SFA contribution percentage is 100%", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("the current collection period is R01", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "Transaction Type",
                        "Funding Source",
                        "Amount"});
            table1.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedSfa",
                        "500"});
#line 11
 testRunner.And("the funding source service generates the following contract type 2 payments:", ((string)(null)), table1, "And ");
#line 14
 testRunner.When("the funding source payments event are received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "TransactionType",
                        "FundingSource",
                        "Amount"});
            table2.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedSfa",
                        "500"});
#line 15
 testRunner.Then("the provider payments service will store the following payments:", ((string)(null)), table2, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "TransactionType",
                        "FundingSource",
                        "Amount"});
            table3.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedSfa",
                        "500"});
#line 18
 testRunner.And("at month end the provider payments service will publish the following payments", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC5- Payment for a 16-18 non-DAS learner, employer is not small")]
        public virtual void AC5_PaymentForA16_18Non_DASLearnerEmployerIsNotSmall()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC5- Payment for a 16-18 non-DAS learner, employer is not small", null, ((string[])(null)));
#line 23
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 24
 testRunner.Given("the SFA contribution percentage is 90%", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.And("the current collection period is R01", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "Transaction Type",
                        "Funding Source",
                        "Amount"});
            table4.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedSfa",
                        "450"});
            table4.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedEmployer",
                        "50"});
#line 26
 testRunner.And("the funding source service generates the following contract type 2 payments:", ((string)(null)), table4, "And ");
#line 30
 testRunner.When("the funding source payments event are received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "TransactionType",
                        "FundingSource",
                        "Amount"});
            table5.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedSfa",
                        "450"});
            table5.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedEmployer",
                        "50"});
#line 31
 testRunner.Then("the provider payments service will store the following payments:", ((string)(null)), table5, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "TransactionType",
                        "FundingSource",
                        "Amount"});
            table6.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedSfa",
                        "450"});
            table6.AddRow(new string[] {
                        "1",
                        "Learning (TT1)",
                        "Co-InvestedEmployer",
                        "50"});
#line 35
 testRunner.And("at month end the provider payments service will publish the following payments", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
