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
    public class ReportingObject
    {
        private IWebDriver driver;
        public ReportingObject(IWebDriver driver)
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

        [FindsBy(How = How.XPath, Using = ".//span[text()='Duration until acknowledgment']")]
        public IWebElement durationUntilAcknowledgementReport;

        [FindsByAll]
        [FindsBy(How = How.XPath, Using = ".//*[@class='k-icon k-plus']")]
        public IList<IWebElement> expander;


        #region Elements Inside Page

        [FindsBy(How = How.Id, Using = "createReportButton")]
        public IWebElement createReportButton;

        [FindsBy(How = How.XPath, Using = "(.//input[@class='fullSize k-input'])[1]")]
        public IWebElement startDateTime;

        [FindsBy(How = How.XPath, Using = "(.//input[@class='fullSize k-input'])[2]")]
        public IWebElement endDateTime;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Show preview']")]
        public IWebElement showPreviewButton;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Create report']")]
        public IWebElement createReporttButton;

        [FindsBy(How = How.Id, Using = "SaveReport_control_1")]
        public IWebElement reportNameTextField;

        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-primary']")]
        public IWebElement saveReportButton;

        [FindsBy(How = How.XPath, Using = "(.//table[@class='k-selectable'])[1]//tr[1]//td[1]/img")]
        public IWebElement selectFirstRowReport;

        [FindsBy(How = How.XPath, Using = ".//button[@id='removeReportButton']")]
        public IWebElement removeReporttButton;

        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-primary']")]
        public IWebElement yesButton;
        //
        //
        #endregion
        public string GetPageTitle()
        {           
            return driver.Title;
        }


    }
}
