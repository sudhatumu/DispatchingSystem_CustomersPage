using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchingSystemPOM.CommonUtilities;

namespace DispatchingSystemPOM.WebPages
{
    class DashboardPage
    {
        //Objects:
        string adminXpath = "//a[contains(text(),'Administration ')]";
        string customersXpath = "//a[text() = 'Customers']";

        //Actions:
        public CustomersPage navigateToCustomersPage()
        {
            try
            {
                ExtensionMethods.clickByXpath(adminXpath);
                ExtensionMethods.clickByXpath(customersXpath);
                return new CustomersPage();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
