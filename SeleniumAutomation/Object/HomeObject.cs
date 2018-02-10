using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Object
{
    public class HomeObject
    {
        private IWebDriver driver;

        public HomeObject(IWebDriver driver)
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

        internal string PageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@id='Reporting']")]
        public IWebElement reports;

        [FindsBy(How = How.XPath, Using = ".//a[@id='Dashboard']")]
        public IWebElement dashboards;

        [FindsBy(How = How.XPath, Using = ".//a[@id='Administration']")]
        public IWebElement administration;

        [FindsBy(How = How.XPath, Using = ".//a[@id='Download']")]
        public IWebElement download;

        [FindsBy(How = How.XPath, Using = ".//*[@class='breadcrumbNavigation navbar navbar-default']//a[@href='https://localhost/#/']")]//".//*[@class='nav nav-stacked navigation']//a[@href='/#Home']")]
        public IWebElement homePage;


        #region Elements Inside Page

        [FindsBy(How = How.XPath, Using = "(.//div[@class='btn-group']/button[contains(@class,'createDashboard')])[1]")]
        public IWebElement createButton;

        [FindsBy(How = How.XPath, Using = ".//a[@class='convertDownloadLink']")]
        public IWebElement downloadLink;

        [FindsBy(How = How.XPath, Using = ".//span[text()='Report templates']")]
        public IWebElement reportsTemplates;

        [FindsBy(How = How.XPath, Using = ".//a[@href='/#Administration/Configuration']")]
        public IWebElement configurationLink;


        #endregion
        public string GetPageTitle()
        {           
            return driver.Title;
        }


    }
}
