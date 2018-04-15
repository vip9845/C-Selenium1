using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Object
{
    public class LoginPageObject
    {
        private IWebDriver driver;

        public LoginPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)this.driver).ExecuteScript(
                "return document.readyState").Equals("complete");
            });

            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.XPath, Using = ".//a[.='Sign In']")]
        public IWebElement signInLink;

        

        [FindsBy(How = How.XPath, Using = ".//*[@id='identifierId']")]
        public IWebElement emailid;

        [FindsBy(How = How.XPath, Using = ".//*[@id='password']/div[1]/div/div[1]/input")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = ".//span[.='Next']")]
        public IWebElement Next;

        [FindsBy(How = How.XPath, Using = ".//*[@id='passwordNext']/content/span")]
        public IWebElement Next2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gb']/div[1]/div[1]/div[2]/div[5]/div[1]/a/span")]
        public IWebElement logoutimage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gb_71']")]
        public IWebElement logout;

        
    }
}
