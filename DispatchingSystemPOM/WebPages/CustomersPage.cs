using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchingSystemPOM.CommonUtilities;
using NUnit.Framework;
using DispatchingSystemPOM.Inputs;
using System.Threading;

namespace DispatchingSystemPOM.WebPages
{
    class CustomersPage
    {
        //Objects:
        string createNewBtnXpath = "//a[text() = 'Create New']";
        string sameAsAboveChkBox = "//input[@id = 'IsSameContact']";

        //Edit Contact form objects
        string firstNameCss = "#FirstName";
        string lastNameCss = "#LastName";
        string phoneCss = "#Phone";
        string saveBtnCss = "input[type='submit'][id = 'submitButton']";

        string editBtnXpath = "//a[text() = 'Edit']"; //getting the first edit button
        string deleteBtnXpath = "//a[text() = 'Delete']";
        string goToFirstPageBtnXpath = "//a[@title = 'Go to the first page']";
        string goToPrevPageBtnXpath = "//a[@title = 'Go to the previous page']";
        string goToNextPageBtnXpath = "//a[@title = 'Go to the next page']";
        string goToLastPageBtnXpath = "//a[@title = 'Go to the last page']";
        string noOfItemListBtnXpath = "//span[@class = 'k-input']";
        string pagerLabelXpath = "//span[@class = 'k-pager-info k-label']";
        string refreshBtnXpath = "//a[@title = 'Refresh']";

        //menu items
        string dashboardMenuXpath = "//a[text() = 'Dashboard']";
        string jobsMenuXpath = "//a[text() = 'Jobs']";
        string usernameDropdownXpath = "//form[@id = 'logoutForm']//a[@class = 'dropdown-toggle']";
        string logOffXpath = "//a[text() = 'Log off']";

        //CreateNew subpage objects
        string nameCss = "#Name";
        string editContactBtnCss = "#EditContactButton";
        string editBillingContactBtnCss = "#EditBillingContactButton";
        string gstCss = "input#GST";
        string submitBtnCss = "#submitButton";


        //Actions:
        public bool CheckCreateNewBtnEnabled()
        {
            return (ExtensionMethods.IsWebelementByXpathEnabled(createNewBtnXpath));

        }

        public string ChkCreateNewPageTitle()
        {
            return (ExtensionMethods.driver.Title);
        }
        public void clickOnCreateNewBtn()
        {
            try
            {
                ExtensionMethods.waitUntilElementLocatedByXpath(createNewBtnXpath, 3);
                if (ExtensionMethods.IsWebelementByXpathEnabled(createNewBtnXpath))
                {
                    ExtensionMethods.clickByXpath(createNewBtnXpath);
                }
            }
            catch (Exception )
            {

                throw;
            }
        }

        public void inputContactDetails()
        {
            try
            {
                ExtensionMethods.sendKeysByCssSelector(nameCss, Resources.name);  //enter Name value from 
                if (ExtensionMethods.IsWebElementByCssselectorEnabled(editContactBtnCss))
                {
                    ExtensionMethods.clickByCssSelector(editContactBtnCss);
                    //Thread.Sleep(2000);
                    ExtensionMethods.driver.SwitchTo().Frame(0);
                    ExtensionMethods.sendKeysByCssSelector(firstNameCss, Resources.firstname);
                    ExtensionMethods.sendKeysByCssSelector(lastNameCss, Resources.lastname);
                    ExtensionMethods.sendKeysByCssSelector(phoneCss, Resources.phone);
                    ExtensionMethods.clickByCssSelector(submitBtnCss);
                    ExtensionMethods.driver.SwitchTo().DefaultContent();
                }
                Thread.Sleep(2000);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void inputBillingContactDetails()
        {
            try
            {
                ExtensionMethods.waitUntilElementLocatedByCss(editBillingContactBtnCss, 6);
                //Thread.Sleep(3000);
                //check if EditBillingContact button is enabled
                if (ExtensionMethods.IsWebElementByCssselectorEnabled(editBillingContactBtnCss))
                {
                    //enter the billing contact details
                    ExtensionMethods.clickByCssSelector(editBillingContactBtnCss);
                    ExtensionMethods.driver.SwitchTo().Frame(0);
                    ExtensionMethods.sendKeysByCssSelector(firstNameCss, Resources.firstname);
                    ExtensionMethods.sendKeysByCssSelector(lastNameCss, Resources.lastname);
                    ExtensionMethods.sendKeysByCssSelector(phoneCss, Resources.phone);
                    ExtensionMethods.clickByCssSelector(submitBtnCss);
                    ExtensionMethods.driver.SwitchTo().DefaultContent();
                }
                Thread.Sleep(2000);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void clickSaveBtn()
        {
            try
            {
                //clickOnCreateNewBtn();
                //inputContactDetails();
                //inputBillingContactDetails();
                ExtensionMethods.clickByCssSelector(saveBtnCss);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void selectCheckBox()
        {
            ExtensionMethods.clickByXpath(sameAsAboveChkBox);
        }
        public bool isBillingContactBtnDisabled()
        {
            return(ExtensionMethods.isWebelementByCssDisabled(editBillingContactBtnCss));
        }
        
    }
}
