using DispatchingSystemPOM.Inputs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchingSystemPOM.CommonUtilities
{
    class BrowserManagement
    {
        //Declaring the webdriver and ExtentReports variables
        public static IWebDriver driver { get; set; }
        public static ExtentReports report;
        public static ExtentTest test;

        //Initialize and launching the site
        public static void openBrowser()
        {
            string browserName = Resources.browser;

            if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
            } else if(browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }else if(browserName.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }

            driver.Navigate().GoToUrl(Resources.url); 
            driver.Manage().Window.Maximize();
               

        }
        public static void InitExtentReport()
        {
            report = new ExtentReports("C:/Users/538067/source/repos/DispatchingSystemPOM/DispatchingSystemPOM/Reports/ReportPage.html", false, DisplayOrder.OldestFirst);
            report.LoadConfig("C:/Users/538067/source/repos/DispatchingSystemPOM/DispatchingSystemPOM/Reports/ExtentConfig.xml");
        }
        public static void closeBrowser()
        {
            driver.Close();
        }
        public static void flushReport()
        {
            report.EndTest(test);
            report.Flush();
        }
        public static void updateReportTestName(string testName)
        {
            test = report.StartTest(testName);  //writing test name to the report
        }
        public static void passLog(string passMsg)
        {
            test.Log(LogStatus.Pass, passMsg);  //updating the message to the report, when test passed
        }
        public static void failLog(string failMsg)
        {
            test.Log(LogStatus.Fail, failMsg);  //updating the message to the report, when test failed
        }
    }
}
