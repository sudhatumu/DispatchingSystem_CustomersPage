using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchingSystemPOM.CommonUtilities;
using DispatchingSystemPOM.WebPages;
using DispatchingSystemPOM.Inputs;

namespace DispatchingSystemPOM.TestCases
{
    [TestFixture]
    class CretaeNewCustomerTests  //for TestCondition 01
    {
        LoginPage loginPage;
        DashboardPage dashboardPage;
        CustomersPage customersPage;

        [OneTimeSetUp]
        public void ClassInit()
        {

           BrowserManagement.InitExtentReport();

        }
        [SetUp]
        public void TestInit()
        {
            BrowserManagement.openBrowser();
            loginPage = new LoginPage();
            dashboardPage = loginPage.loginMethod();
            customersPage = dashboardPage.navigateToCustomersPage();
        }
        [Test]
        public void TC01_01_CreateNewBtnEnable()
        {
            BrowserManagement.updateReportTestName("Create New button Enable Test");
            if(customersPage.CheckCreateNewBtnEnabled())
            {
                Assert.IsTrue(true);
                BrowserManagement.passLog("Create New button is Enabled");
            } else
            {
                
                BrowserManagement.failLog("Create New Button is not enabled");
                Assert.Fail("Create New Button is not enabled");
            }

        }
        [Test]
        public void TC01_02_CreateNewBtnPage()
        {
            BrowserManagement.updateReportTestName("Create New Page test");
            customersPage.clickOnCreateNewBtn();

            if((BrowserManagement.driver.Title).Equals(Resources.title))
            {
                Assert.True(true);
                BrowserManagement.passLog("User navigates to the correct page");
            } else
            {
                BrowserManagement.failLog("Unable to navigate to correct page");
                Assert.Fail("Test failed");

            }
        }
        [Test]
        public void TC01_03_CreateNewPageEditContactBtn()
        {
            BrowserManagement.updateReportTestName("Edit Contact button test in Create New Page");
            customersPage.clickOnCreateNewBtn();
            customersPage.inputContactDetails();
            if (BrowserManagement.driver.Title.Equals(Resources.title))
            {
                Assert.True(true);
                BrowserManagement.passLog("Able to input and save Contact details"); // coming back to the create new page
            } else
            {
                BrowserManagement.failLog("Unable to save the contact details");  //not returning back to the correct page
                Assert.Fail("Test failed");

            }
        }
        [Test]
        public void TC01_04_CreateNewEditBillingContact()
        {
            BrowserManagement.test = BrowserManagement.report.StartTest("Edit Billing Contact button Test");
            customersPage.clickOnCreateNewBtn();
            customersPage.inputBillingContactDetails();
            //need to add assertion
            BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Able to input and save the Billing contact details");
        }
        [Test]
        public void TC01_05_CreateNewSave()
        {
            BrowserManagement.test = BrowserManagement.report.StartTest("Create new record with all inputs");
            customersPage.clickOnCreateNewBtn();
            customersPage.inputContactDetails();
            customersPage.inputBillingContactDetails();
            customersPage.clickSaveBtn();
            //customersPage.createNewCustomerRecord();
            //need to add assertion
            BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "New record created successfully");
        }
        
        [Test]
        public void TC01_06_CreateNewEditBillContactBtnWithChkBox()
        {
            BrowserManagement.test = BrowserManagement.report.StartTest("Enable Billing contact details with check box");
            customersPage.clickOnCreateNewBtn();
            customersPage.inputContactDetails();
            customersPage.selectCheckBox();
            //check whether the billing contact details updated or not


        }
        [Test]
        public void TC07_CreateNewSaveWithChkBox()
        {

        }
        [Test]
        public void TC08_CreateNewChkCustomersList()
        {

        }
        [Test]
        public void TC09_CreateNewChkTotalLable()
        {

        }
        [TearDown]
        public void TestCleanup()
        {
           // BrowserManagement.closeBrowser();
        }
        [OneTimeTearDown]
        public void ClassCleanup()
        {
            BrowserManagement.flushReport();
        }
    }
    [TestFixture]
    class CreateNewNegativeTestScenarios
    {
        [Test]
        public void TC01_Test()
        {
            Assert.IsTrue(true);
        }
    }
}
