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
namespace SFA.DAS.Payments.AcceptanceTests.EndToEnd.Tests.InconsistentSubmissionData
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Inconsistent Submissions Data PV2-1625")]
    public partial class InconsistentSubmissionsDataPV2_1625Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PV2-1626 Levy learner, learner is deleted should refund correct types and values.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Inconsistent Submissions Data PV2-1625", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Levy learner a is deleted from ILR in 07/18, but Levy learner b is added to the 0" +
            "7/18 ILR PV2-1625")]
        public virtual void LevyLearnerAIsDeletedFromILRIn0718ButLevyLearnerBIsAddedToThe0718ILRPV2_1625()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Levy learner a is deleted from ILR in 07/18, but Levy learner b is added to the 0" +
                    "7/18 ILR PV2-1625", null, ((string[])(null)));
#line 3
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
 testRunner.Given("the employer levy account balance in collection period R12/Current Academic Year " +
                    "is 9000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1107 = new TechTalk.SpecFlow.Table(new string[] {
                        "Identifier",
                        "Learner ID",
                        "start date",
                        "end date",
                        "agreed price",
                        "Framework Code",
                        "Pathway Code",
                        "Programme Type"});
            table1107.AddRow(new string[] {
                        "Apprenticeship 1",
                        "learner a",
                        "01/May/Current Academic Year",
                        "01/May/Next Academic Year",
                        "9000",
                        "593",
                        "1",
                        "20"});
#line 5
 testRunner.And("the following commitments exist", ((string)(null)), table1107, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1108 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
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
            table1108.AddRow(new string[] {
                        "learner a",
                        "06/May/Current Academic Year",
                        "12 months",
                        "9000",
                        "06/May/Current Academic Year",
                        "0",
                        "06/May/Current Academic Year",
                        "",
                        "continuing",
                        "Act1",
                        "1",
                        "ZPROG001",
                        "593",
                        "1",
                        "20",
                        "16-18 Apprenticeship (From May 2017) Levy Contract",
                        "90%"});
#line 8
 testRunner.And("the provider previously submitted the following learner details", ((string)(null)), table1108, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1109 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Aug/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Sep/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Oct/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Nov/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Dec/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Jan/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Feb/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Mar/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Apr/Current Academic Year",
                        "0",
                        "0",
                        "0"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "May/Current Academic Year",
                        "600",
                        "500",
                        "1000"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Jun/Current Academic Year",
                        "600",
                        "500",
                        "1000"});
            table1109.AddRow(new string[] {
                        "learner a",
                        "Jul/Current Academic Year",
                        "600",
                        "500",
                        "1000"});
#line 11
    testRunner.And("the following earnings had been generated for the learner", ((string)(null)), table1109, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1110 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
                        "Collection Period",
                        "Delivery Period",
                        "Levy Payments",
                        "Transaction Type"});
            table1110.AddRow(new string[] {
                        "learner a",
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "600",
                        "Learning"});
            table1110.AddRow(new string[] {
                        "learner a",
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "600",
                        "Learning"});
            table1110.AddRow(new string[] {
                        "learner a",
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "500",
                        "Completion"});
            table1110.AddRow(new string[] {
                        "learner a",
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "500",
                        "Completion"});
            table1110.AddRow(new string[] {
                        "learner a",
                        "R10/Current Academic Year",
                        "May/Current Academic Year",
                        "1000",
                        "Balancing"});
            table1110.AddRow(new string[] {
                        "learner a",
                        "R11/Current Academic Year",
                        "Jun/Current Academic Year",
                        "1000",
                        "Balancing"});
#line 25
    testRunner.And("the following provider payments had been generated", ((string)(null)), table1110, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1111 = new TechTalk.SpecFlow.Table(new string[] {
                        "Identifier",
                        "Learner ID",
                        "start date",
                        "end date",
                        "agreed price",
                        "Framework Code",
                        "Pathway Code",
                        "Programme Type"});
            table1111.AddRow(new string[] {
                        "Apprenticeship 2",
                        "learner b",
                        "01/May/Current Academic Year",
                        "01/May/Next Academic Year",
                        "9000",
                        "593",
                        "1",
                        "20"});
#line 33
    testRunner.But("the Commitment details are changed as follows", ((string)(null)), table1111, "But ");
#line hidden
            TechTalk.SpecFlow.Table table1112 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
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
            table1112.AddRow(new string[] {
                        "learner b",
                        "06/May/Current Academic Year",
                        "12 months",
                        "9000",
                        "06/May/Current Academic Year",
                        "0",
                        "06/May/Current Academic Year",
                        "",
                        "continuing",
                        "Act1",
                        "1",
                        "ZPROG001",
                        "593",
                        "1",
                        "20",
                        "16-18 Apprenticeship (From May 2017) Levy Contract",
                        "90%"});
#line 36
    testRunner.And("the Provider now changes the Learner details as follows", ((string)(null)), table1112, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1113 = new TechTalk.SpecFlow.Table(new string[] {
                        "Price Episode Id",
                        "Total Training Price",
                        "Total Training Price Effective Date",
                        "Total Assessment Price",
                        "Total Assessment Price Effective Date",
                        "Residual Training Price",
                        "Residual Training Price Effective Date",
                        "Residual Assessment Price",
                        "Residual Assessment Price Effective Date",
                        "Contract Type",
                        "Aim Sequence Number",
                        "SFA Contribution Percentage"});
            table1113.AddRow(new string[] {
                        "pe-1",
                        "9000",
                        "06/May/Current Academic Year",
                        "0",
                        "06/May/Current Academic Year",
                        "0",
                        "",
                        "0",
                        "",
                        "Act1",
                        "1",
                        "90%"});
#line 39
 testRunner.And("price details as follows", ((string)(null)), table1113, "And ");
#line 43
 testRunner.When("the amended ILR file is re-submitted for the learners in collection period R12/Cu" +
                    "rrent Academic Year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1114 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing",
                        "Price Episode Identifier"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Aug/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Sep/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Oct/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Nov/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Dec/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Jan/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Feb/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Mar/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Apr/Current Academic Year",
                        "0",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "May/Current Academic Year",
                        "600",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Jun/Current Academic Year",
                        "600",
                        "0",
                        "0",
                        "pe-1"});
            table1114.AddRow(new string[] {
                        "learner b",
                        "Jul/Current Academic Year",
                        "600",
                        "0",
                        "0",
                        "pe-1"});
#line 44
 testRunner.Then("the following learner earnings should be generated", ((string)(null)), table1114, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1115 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
                        "Collection Period",
                        "Delivery Period",
                        "On-Programme",
                        "Completion",
                        "Balancing"});
            table1115.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-600",
                        "-500",
                        "-1000"});
            table1115.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "-600",
                        "-500",
                        "-1000"});
            table1115.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table1115.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "600",
                        "0",
                        "0"});
            table1115.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "600",
                        "0",
                        "0"});
#line 58
    testRunner.And("at month end only the following payments will be calculated", ((string)(null)), table1115, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1116 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
                        "Collection Period",
                        "Delivery Period",
                        "Levy Payments",
                        "Transaction Type"});
            table1116.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-600",
                        "Learning"});
            table1116.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "-600",
                        "Learning"});
            table1116.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-500",
                        "Completion"});
            table1116.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "-500",
                        "Completion"});
            table1116.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-1000",
                        "Balancing"});
            table1116.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-1000",
                        "Balancing"});
            table1116.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "600",
                        "Learning"});
            table1116.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "600",
                        "Learning"});
            table1116.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "600",
                        "Learning"});
#line 65
 testRunner.And("only the following provider payments will be generated", ((string)(null)), table1116, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1117 = new TechTalk.SpecFlow.Table(new string[] {
                        "Learner ID",
                        "Collection Period",
                        "Delivery Period",
                        "Levy Payments",
                        "Transaction Type"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-600",
                        "Learning"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "-600",
                        "Learning"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-500",
                        "Completion"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "-500",
                        "Completion"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-1000",
                        "Balancing"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "-1000",
                        "Balancing"});
            table1117.AddRow(new string[] {
                        "learner a",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "-600",
                        "Learning"});
            table1117.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "May/Current Academic Year",
                        "600",
                        "Learning"});
            table1117.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "Jun/Current Academic Year",
                        "600",
                        "Learning"});
            table1117.AddRow(new string[] {
                        "learner b",
                        "R12/Current Academic Year",
                        "Jul/Current Academic Year",
                        "600",
                        "Learning"});
#line 76
 testRunner.And("only the following provider payments will be recorded", ((string)(null)), table1117, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
