using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.Action
{
    public class HomeAction
    {
        HomeObject homeObject;
        IWebDriver driver;

        public HomeAction(IWebDriver driver)
        {
            this.homeObject = new HomeObject(driver);
        }

        /// <summary>
        /// Method to Click on the Reports Link
        /// </summary>
        /// <returns></returns>
        public HomeAction ClickOnReportsLink()
        {
            homeObject.reports.Click();
            return this;
        }

        public HomeAction ClickOnDashboardLink()
        {
            homeObject.dashboards.Click();
            return this;
        }

        public HomeAction ClickOnDownloadLink()
        {
            homeObject.download.Click();
            return this;
        }

        public HomeAction ClickOnAdministratonLink()
        {
            homeObject.administration.Click();
            return this;
        }

        public HomeAction ClickOnHomePageLink()
        {
            homeObject.homePage.Click();
            return this;
        }

        public HomeAction VerifyingPageTitle(string title)
        {
            Assert.AreEqual(title, homeObject.GetPageTitle(), "Page Title is not matching");
            return this;
        }

        public HomeAction VerifyHomePageLinks()
        {
            Assert.IsTrue(homeObject.reports.Displayed, "Reports Link is not present in the home page");
            Assert.IsTrue(homeObject.dashboards.Displayed, "Dashboards Link is not present in the home page");
            Assert.IsTrue(homeObject.administration.Displayed, "Administration Link is not present in the home page");
            Assert.IsTrue(homeObject.download.Displayed, "Download Link is not present in the home page");

            return this;
        }

        public HomeAction VerifyingCreateButton()
        {
            Assert.IsTrue(homeObject.createButton.Displayed, "Create Button is not present");
            return this;
        }

        public HomeAction VerifyingDownloadLink()
        {
            Assert.IsTrue(homeObject.downloadLink.Displayed, "DownloadLink is not present");
            return this;
        }

        public HomeAction VerifyingReportsTemplate()
        {
            Assert.IsTrue(homeObject.reportsTemplates.Displayed, "Report Template Folder is not present");
            return this;
        }

        public HomeAction VerifyingConfigurationLink()
        {
            Assert.IsTrue(homeObject.configurationLink.Displayed, "Configuration Link is not present");
            return this;
        }

        public void WaitForMoment(int value)
        {
            Thread.Sleep(value * 1000);
        }

    }
}
