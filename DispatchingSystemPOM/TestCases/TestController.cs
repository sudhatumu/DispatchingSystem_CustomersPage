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
            customersPage.createNewRecord();
            //customersPage.createNewCustomerRecord();

            //need to add assertion - system is not returning any message that contact has saved, but record has saved in list
            BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "New record created successfully");
        }
        
        [Test]
        public void TC01_06_CreateNewEditBillContactBtnWithChkBox()
        {
            BrowserManagement.test = BrowserManagement.report.StartTest("Enable Billing contact details with check box");
            customersPage.clickOnCreateNewBtn();
            customersPage.inputContactDetails();
            customersPage.selectCheckBox();
            //check whether the billing contact details button is disabled or not
            if (customersPage.isBillingContactBtnDisabled()) 
            {
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Billing contact button is disabled when we select checkbox");
                Assert.True(true);
            } else
            {
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Button shouldn't be enabled");
                Assert.Fail();
            }

        }
        [Test]
        public void TC01_07_CreateNewSaveWithChkBox()
        {
            customersPage.clickOnCreateNewBtn();
            customersPage.inputContactDetails();
            customersPage.selectCheckBox();
            customersPage.clickSaveBtn();
            //need to add assertion - not getting any message that the record has saved
        }
        [Test]
        public void TC01_08_CreateNewChkCustomersList()
        {

            //checking whether the new record is displayed in the last page
            //create new record before checking 
            customersPage.createNewRecord();
            //------

            BrowserManagement.test = BrowserManagement.report.StartTest("Test for presence of the created new record  in Customers table");
            dashboardPage.navigateToCustomersPage(); // go to the customers page

            customersPage.goToLastPage();  //go to the last page and check the last record 
           if(customersPage.checkLastRowName())
            {
                Assert.IsTrue(true);
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Record present at the last position of the customer table");
            } else
            {
                Assert.Fail();
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Record not saved at the last position of the customer table");
            }

        }
        [Test]
        public void TC01_09_CreateNewChkTotalLable()
        {
            
            BrowserManagement.test = BrowserManagement.report.StartTest("Total number of records Test");
            int prevCount = customersPage.getTotalRecordCount();  //get the total count before creating new record

            customersPage.createNewRecord();  // create new record
            dashboardPage.navigateToCustomersPage(); //go to the Customers page
            int currentCount = customersPage.getTotalRecordCount();   // get the total count again to check the Total number of record updation

            if (currentCount.Equals(prevCount + 1))
            {
                Assert.True(true);
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "total Count has updated properly");
            } else
            {
                Assert.Fail("Total count is not updated propertly");
            }



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
    //// Test Fixture 2
    [TestFixture]
    class EditDeleteTestScenario    //For Edit and Delete test scenario
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
        public void TC03_01_verifyEditBtn()
        {
            BrowserManagement.test = BrowserManagement.report.StartTest("Test for Edit button");
            customersPage.goToLastPage();
            if(customersPage.editFormWindowTilteCheck())
            {
                Assert.True(true);
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "User navigates to the correct page");
            } else
            {
                Assert.Fail();
                BrowserManagement.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit form title not matched");
            }
        }
        [TearDown]
        public void TestCleanup()
        {
             BrowserManagement.closeBrowser();
        }
        [OneTimeTearDown]
        public void ClassCleanup()
        {
            BrowserManagement.flushReport();
        }
    }
}
