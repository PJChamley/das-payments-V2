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
namespace SFA.DAS.Payments.AcceptanceTests.EndToEnd.Tests.Non_LevyLearner_LearnerChangeOfCircumstances
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("One learner change of ULN - PV2-394")]
    public partial class OneLearnerChangeOfULN_PV2_394Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "One learner change of ULN - PV2-394.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "One learner change of ULN - PV2-394", @"	As a provider,
	I want a non-Levy apprentice, provider changes ULN for an apprentice in the ILR after payments have already occurred, to be paid the correct amount
	So that I am accurately paid my apprenticeship provision.

Feature: Non-Levy apprentice, provider changes ULN for an apprentice in the ILR after payments have already occurred", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Non-levy learner provider changes ULN after payments have already occurred PV2-39" +
            "4")]
        [NUnit.Framework.TestCaseAttribute("R03/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R04/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R05/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R06/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R07/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R08/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R09/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R10/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R11/Current Academic Year", null)]
        [NUnit.Framework.TestCaseAttribute("R12/Current Academic Year", null)]
        public virtual void Non_LevyLearnerProviderChangesULNAfterPaymentsHaveAlreadyOccurredPV2_394(string collection_Period, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Non-levy learner provider changes ULN after payments have already occurred PV2-39" +
                    "4", null, exampleTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
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
            table1.AddRow(new string[] {
                        "11111111",
                        "06/Aug/Current Academic Year",
                        "12 months",
                        "9000",
                        "06/Aug/Current Academic Year",
                        "0",
                        "06/Aug/Current Academic Year",
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
#line 9
 testRunner.Given("the provider previously submitted the following learner details", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table2.AddRow(new string[] {
                        "Aug/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Sep/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Oct/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Nov/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Dec/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Jan/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Feb/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Mar/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Apr/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "May/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Jun/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "Jul/Current Academic Year",
                        "600",
                        "0",
                        "0"});
#line 13
    testRunner.And("the following earnings had been generated for the learner", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "SFA Co-Funded Payments",
                        "Employer Co-Funded Payments",
                        "Transaction Type"});
            table3.AddRow(new string[] {
                        "R01/Current Academic Year",
                        "Aug/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table3.AddRow(new string[] {
                        "R02/Current Academic Year",
                        "Sep/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
#line 27
    testRunner.And("the following provider payments had been generated", ((string)(null)), table3, "And ");
#line 32
    testRunner.But("the Provider now changes the Learner\'s ULN to \"22222222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "But ");
#line 33
 testRunner.When(string.Format("the amended ILR file is re-submitted for the learners in collection period {0}", collection_Period), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table4.AddRow(new string[] {
                        "Aug/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Sep/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Oct/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Nov/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Dec/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Jan/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Feb/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Mar/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Apr/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "May/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Jun/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table4.AddRow(new string[] {
                        "Jul/Current Academic Year",
                        "600",
                        "0",
                        "0"});
#line 34
    testRunner.Then("the following learner earnings should be generated", ((string)(null)), table4, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table5.AddRow(new string[] {
                        "R03/Current Academic Year",
                        "Oct/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R04/Current Academic Year",
                        "Nov/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R05/Current Academic Year",
                        "Dec/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R06/Current Academic Year",
                        "Jan/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R07/Current Academic Year",
                        "Feb/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R08/Current Academic Year",
                        "Mar/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R09/Current Academic Year",
                        "Apr/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "600",
                        "0",
                        "0"});
#line 48
    testRunner.And("only the following payments will be calculated", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "SFA Co-Funded Payments",
                        "Employer Co-Funded Payments",
                        "Transaction Type"});
            table6.AddRow(new string[] {
                        "R03/Current Academic Year",
                        "Oct/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R04/Current Academic Year",
                        "Nov/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R05/Current Academic Year",
                        "Dec/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R06/Current Academic Year",
                        "Jan/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R07/Current Academic Year",
                        "Feb/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R08/Current Academic Year",
                        "Mar/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R09/Current Academic Year",
                        "Apr/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table6.AddRow(new string[] {
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
#line 60
    testRunner.And("only the following provider payments will be recorded", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Collection Period",
                        "Delivery Period",
                        "SFA Co-Funded Payments",
                        "Employer Co-Funded Payments",
                        "Transaction Type"});
            table7.AddRow(new string[] {
                        "R03/Current Academic Year",
                        "Oct/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R04/Current Academic Year",
                        "Nov/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R05/Current Academic Year",
                        "Dec/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R06/Current Academic Year",
                        "Jan/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R07/Current Academic Year",
                        "Feb/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R08/Current Academic Year",
                        "Mar/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R09/Current Academic Year",
                        "Apr/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
            table7.AddRow(new string[] {
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "540",
                        "60",
                        "Learning"});
#line 72
 testRunner.And("at month end only the following provider payments will be generated", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion