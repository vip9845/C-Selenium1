using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTesting.Object;

namespace UnitTesting.Action
{
    public class LoginPageAction
    {
        LoginPageObject loginPageObject;
        IWebDriver driver;

        public LoginPageAction(IWebDriver driver)
        {
            this.loginPageObject = new LoginPageObject(driver);
        }

        public void EnterEmaild(string emailid)
        {
            loginPageObject.emailid.SendKeys(emailid);
        }

        /// <summary>
        /// Method to Click on the Reports Link
        /// </summary>
        /// <returns></returns>
        public void EnterPassword()
        {
            loginPageObject.password.SendKeys("mprakashnaidu");
        }

        public void ClickOnNext()
        {
            loginPageObject.Next.Click();
        }

        public void ClickOnNext2()
        {
            loginPageObject.Next2.Click();
        }

        public void ClickOnLogOut()
        {
            loginPageObject.logoutimage.Click();
            Thread.Sleep(2000);
            loginPageObject.logout.Click();
        }
    }
}
