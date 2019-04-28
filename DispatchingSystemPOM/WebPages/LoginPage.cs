using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchingSystemPOM.CommonUtilities;
using DispatchingSystemPOM.Inputs;

namespace DispatchingSystemPOM.WebPages
{
    class LoginPage
    {
        // Elements:
        string userNameId = "UserName";
        string passwordId = "Password";

        string loginBtnXpath = "//input[@type='submit']";

        //Actions:
        public DashboardPage loginMethod()
        {
            try
            {
                ExtensionMethods.sendKeysById(userNameId, Resources.username);
                ExtensionMethods.sendKeysById(passwordId, Resources.password);

                ExtensionMethods.clickByXpath(loginBtnXpath);
                return new DashboardPage();
            }
            catch (Exception)
            {
              throw;
            }
        }

    }
}
