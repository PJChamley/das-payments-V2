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
namespace SFA.DAS.Payments.AcceptanceTests.EndToEnd.Tests.Non_LevyLearner.EmployerChangeOfCIrcumstances
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Change employer at end of month PV2-381")]
    public partial class ChangeEmployerAtEndOfMonthPV2_381Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Change employer at end of month PV2-381.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Change employer at end of month PV2-381", "\tAs a provider,\r\n\tI want earnings and payments for a non-levy learner, and there " +
                    "is a change to the Negotiated Cost which happens at the end of the month, to be " +
                    "paid the correct amount\r\n\tSo that I am accurately paid my apprenticeship provisi" +
                    "on.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Non-levy learner changes employer with change to negotiated price at the end of m" +
            "onth PV2-381")]
        [NUnit.Framework.TestCaseAttribute("R04/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R05/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R06/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R07/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R08/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R09/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R10/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R11/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R12/Current Academic Year", null)]
        public virtual void Non_LevyLearnerChangesEmployerWithChangeToNegotiatedPriceAtTheEndOfMonthPV2_381(string collection_Period, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Non-levy learner changes employer with change to negotiated price at the end of m" +
                    "onth PV2-381", null, exampleTags);
#line 15
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table78 = new TechTalk.SpecFlow.Table(new string[] {
                        "Start Date",
                        "Planned Duration",
                        "Total Training Price",
                        "Total Training Price Effective Date",
                        "Total Assessment Price",
                        "Total Assessment Price Effective Date",
                        "Actual Duration",
                        "Completion Status",
                        "Contract Type",
                        "Aim Sequence Number",
                        "Aim Reference",
                        "Framework Code",
                        "Pathway Code",
                        "Programme Type",
                        "Funding Line Type",
                        "SFA Contribution Percentage"});
            table78.AddRow(new string[] {
                        "01/Aug/Current Academic Year",
                        "12 months",
                        "12000",
                        "01/Aug/Current Academic Year",
                        "3000",
                        "01/Aug/Current Academic Year",
                        "",
                        "continuing",
                        "Act2",
                        "1",
                        "ZPROG001",
                        "403",
                        "1",
                        "25",
                        "16-18 Apprenticeship (From May 2017) Non-Levy Contract (non-procured)",
                        "90%"});
#line 16
 testRunner.Given("the provider previously submitted the following learner details", ((string)(null)), table78, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table79 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table79.AddRow(new string[] {
                        "Aug/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Sep/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Oct/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Nov/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Dec/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Jan/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Feb/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Mar/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Apr/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "May/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Jun/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table79.AddRow(new string[] {
                        "Jul/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
#line 19
 testRunner.And("the following earnings had been generated for the learner", ((string)(null)), table79, "And ");
#line hidden
            TechTalk.SpecFlow.Table table80 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "SFA Co-Funded Payments",
                        "Employer Co-Funded Payments",
                        "Transaction Type",
                        "Employer"});
            table80.AddRow(new string[] {
                        "R01/Current Academic Year",
                        "Aug/Current Academic Year",
                        "900",
                        "100",
                        "Learning",
                        "employer 1"});
            table80.AddRow(new string[] {
                        "R02/Current Academic Year",
                        "Sep/Current Academic Year",
                        "900",
                        "100",
                        "Learning",
                        "employer 1"});
            table80.AddRow(new string[] {
                        "R03/Current Academic Year",
                        "Oct/Current Academic Year",
                        "900",
                        "100",
                        "Learning",
                        "employer 1"});
#line 33
 testRunner.And("the following provider payments had been generated", ((string)(null)), table80, "And ");
#line hidden
            TechTalk.SpecFlow.Table table81 = new TechTalk.SpecFlow.Table(new string[] {
                        "Start Date",
                        "Planned Duration",
                        "Total Training Price",
                        "Total Training Price Effective Date",
                        "Total Assessment Price",
                        "Total Assessment Price Effective Date",
                        "Actual Duration",
                        "Completion Status",
                        "Contract Type",
                        "Aim Sequence Number",
                        "Aim Reference",
                        "Framework Code",
                        "Pathway Code",
                        "Programme Type",
                        "Funding Line Type"});
            table81.AddRow(new string[] {
                        "01/Aug/Current Academic Year",
                        "12 months",
                        "12000",
                        "01/Aug/Current Academic Year",
                        "3000",
                        "01/Aug/Current Academic Year",
                        "",
                        "continuing",
                        "Act2",
                        "1",
                        "ZPROG001",
                        "403",
                        "1",
                        "25",
                        "16-18 Apprenticeship (From May 2017) Non-Levy Contract (non-procured)"});
#line 38
 testRunner.But("the Provider now changes the Learner details as follows", ((string)(null)), table81, "But ");
#line hidden
            TechTalk.SpecFlow.Table table82 = new TechTalk.SpecFlow.Table(new string[] {
                        "Price details",
                        "Total Training Price",
                        "Total Training Price Effective Date",
                        "Total Assessment Price",
                        "Total Assessment Price Effective Date",
                        "Residual Training Price",
                        "Residual Training Price Effective Date",
                        "Residual Assessment Price",
                        "Residual Assessment Price Effective Date",
                        "SFA Contribution Percentage"});
            table82.AddRow(new string[] {
                        "1st price details",
                        "12000",
                        "01/Aug/Current Academic Year",
                        "3000",
                        "01/Aug/Current Academic Year",
                        "0",
                        "",
                        "0",
                        "",
                        "90%"});
            table82.AddRow(new string[] {
                        "2nd price details",
                        "12000",
                        "01/Aug/Current Academic Year",
                        "3000",
                        "01/Aug/Current Academic Year",
                        "5000",
                        "01/Nov/Current Academic Year",
                        "625",
                        "01/Nov/Current Academic Year",
                        "90%"});
#line 42
 testRunner.And("price details as follows", ((string)(null)), table82, "And ");
#line 46
 testRunner.When(string.Format("the amended ILR file is re-submitted for the learners in collection period {0}", collection_Period), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table83 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table83.AddRow(new string[] {
                        "Aug/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Sep/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Oct/Current Academic Year",
                        "1000",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Nov/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Dec/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Jan/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Feb/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Mar/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Apr/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "May/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Jun/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table83.AddRow(new string[] {
                        "Jul/Current Academic Year",
                        "500",
                        "0",
                        "0"});
#line 47
 testRunner.Then("the following learner earnings should be generated", ((string)(null)), table83, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table84 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table84.AddRow(new string[] {
                        "R04/Current Academic Year",
                        "Nov/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R05/Current Academic Year",
                        "Dec/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R06/Current Academic Year",
                        "Jan/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R07/Current Academic Year",
                        "Feb/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R08/Current Academic Year",
                        "Mar/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R09/Current Academic Year",
                        "Apr/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "500",
                        "0",
                        "0"});
            table84.AddRow(new string[] {
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "500",
                        "0",
                        "0"});
#line 61
 testRunner.And("only the following payments will be calculated", ((string)(null)), table84, "And ");
#line hidden
            TechTalk.SpecFlow.Table table85 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "SFA Co-Funded Payments",
                        "Employer Co-Funded Payments",
                        "Transaction Type"});
            table85.AddRow(new string[] {
                        "R04/Current Academic Year",
                        "Nov/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R05/Current Academic Year",
                        "Dec/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R06/Current Academic Year",
                        "Jan/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R07/Current Academic Year",
                        "Feb/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R08/Current Academic Year",
                        "Mar/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R09/Current Academic Year",
                        "Apr/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table85.AddRow(new string[] {
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
#line 72
 testRunner.And("only the following provider payments will be recorded", ((string)(null)), table85, "And ");
#line hidden
            TechTalk.SpecFlow.Table table86 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "SFA Co-Funded Payments",
                        "Employer Co-Funded Payments",
                        "Transaction Type"});
            table86.AddRow(new string[] {
                        "R04/Current Academic Year",
                        "Nov/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R05/Current Academic Year",
                        "Dec/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R06/Current Academic Year",
                        "Jan/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R07/Current Academic Year",
                        "Feb/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R08/Current Academic Year",
                        "Mar/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R09/Current Academic Year",
                        "Apr/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
            table86.AddRow(new string[] {
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "450",
                        "50",
                        "Learning"});
#line 83
 testRunner.And("at month end only the following provider payments will be generated", ((string)(null)), table86, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
