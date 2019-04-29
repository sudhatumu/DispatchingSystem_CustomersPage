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

        string lastCustomerRecordName = "//table[@role = 'grid']/tbody/tr[last()]/td[2]";  //last record from the customer table page
        string totalRecordsXpath = "//table//tr[@class = 'k-footer-template']/td[2]";
        //string editBtnXpath = "//a[text() = 'Edit']"; //getting the first edit button
        string editBtnXpath = "//table//tr[last()]//td/a[contains(text(), 'Edit')]"; // Edit button xpath of the last record in the table
        string editBtnFormTitle = "//span[@id = 'detailWindow_wnd_title']"; // Title of the Edit form
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

                ExtensionMethods.clickByCssSelector(saveBtnCss);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void createNewRecord()
        {
            //create new record 
            try
            {
                clickOnCreateNewBtn();
                inputContactDetails();
                inputBillingContactDetails();
                clickSaveBtn();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void selectCheckBox()
        {
            try
            {
                ExtensionMethods.clickByXpath(sameAsAboveChkBox); // select the 'SameAsAbove' check box
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool isBillingContactBtnDisabled()
        {
            //EditBillingContact button will be disabled when we select the SameAsAbove checkbox
            return(ExtensionMethods.isWebelementByCssDisabled(editBillingContactBtnCss));
        }
        public void goToLastPage()
        {
            try
            {
                ExtensionMethods.waitUntilElementLocatedByXpath(goToLastPageBtnXpath, 4);
                Thread.Sleep(3000);
                ExtensionMethods.clickByXpath(goToLastPageBtnXpath);  //go to the last page
            }
            catch (Exception)
            {

                throw;
            } 
        }
        public bool checkLastRowName()
        {
            try
            {
                //return true, if our record name is present at the last row of customer records 
                ExtensionMethods.waitUntilElementLocatedByXpath(lastCustomerRecordName, 5);
                if ((ExtensionMethods.getWebelementTextByXpath(lastCustomerRecordName)) == Resources.name)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int getTotalRecordCount()
        {
            //get the total number of records before creating new record
            
            Thread.Sleep(2000);
            ExtensionMethods.waitUntilElementLocatedByXpath(totalRecordsXpath, 7);
            String totalNumText = ExtensionMethods.getWebelementTextByXpath(totalRecordsXpath);
            String valueTotalStr = totalNumText.Substring(7, 3);
            int valueTotalInt = int.Parse(valueTotalStr);
            return valueTotalInt;
            //create a new record

        }
        public bool editFormWindowTilteCheck()
        {
            //check for the last record

            //if the Edit button is enabled, click on it and return the title of the Edit form
            try
            {
                if (ExtensionMethods.IsWebelementByXpathEnabled(editBtnXpath))
                {
                    ExtensionMethods.clickByXpath(editBtnXpath);
                   // ExtensionMethods.driver.SwitchTo().Frame(0);
                    if (ExtensionMethods.getWebelementTextByXpath(editBtnFormTitle) == Resources.editformtitle)
                    {
                        return true;
                    }
                    else
                        return false;

                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
    }
}
