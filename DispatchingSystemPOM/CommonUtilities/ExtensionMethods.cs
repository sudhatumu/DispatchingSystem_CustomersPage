using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchingSystemPOM.CommonUtilities
{
    class ExtensionMethods
       
    {
        public static IWebDriver driver = BrowserManagement.driver;

        public static void sendKeysByXpath(string xpath, string text)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);

        }
        public static void sendKeysByCssSelector(string css, string text)
        {
            driver.FindElement(By.CssSelector(css)).SendKeys(text);
        }
        public static void clickByCssSelector(string css)
        {
           
            if (IsWebElementByCssselectorEnabled(css))
            {
                driver.FindElement(By.CssSelector(css)).Click();
            }
        }
        public static void clickByXpath(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }
        public static void sendKeysById(string id, string text)
        {
            driver.FindElement(By.Id(id)).SendKeys(text);
        }
        public static void clickById(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public static bool IsWebElementByCssselectorEnabled(string cssSelector)
        {

            if(driver.FindElement(By.CssSelector(cssSelector)).Enabled)
            {
                return true;
            } else
            {
                Console.WriteLine("Button is not enabled");
                return false;
            }
        }
        //public static bool IsWebElementByCssselectorClickable(string cssSelector)
        //{
        //    if (driver.FindElement(By.CssSelector(cssSelector)).c)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static bool IsWebelementByXpathEnabled(string xpath)
        {
            if(driver.FindElement(By.XPath(xpath)).Enabled)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public static void waitUntilElementLocatedByXpath(String xpath, long timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(c => c.FindElement(By.XPath(xpath)));
           // wait.Until(IsWebelementByXpathEnabled);

        }
        public static void waitUntilElementLocatedByCss(String css, long timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(c => c.FindElement(By.CssSelector(css)));
            
        }
    }
}
