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
    public class ReportingAction
    {
        ReportingObject reportingObject;
        IWebDriver driver;

        public ReportingAction(IWebDriver driver)
        {
            this.reportingObject = new ReportingObject(driver);
        }

        /// <summary>
        /// Method to Click on the Reports Link
        /// </summary>
        /// <returns></returns>
        public ReportingAction ExpandALL()
        {
            IList<IWebElement> all = reportingObject.expander;
            int count = all.Count;

            foreach (IWebElement item in all)
            {
                if (item.Displayed && item.Enabled)
                {
                    item.Click();
                    Thread.Sleep(2000);
                }
            }                    
            return this;
        }

        public ReportingAction ClickOnDurationUntilAcknowledgementReport()
        {
            reportingObject.durationUntilAcknowledgementReport.Click();
            return this;
        }

        public ReportingAction ClickOnCreateReportButton()
        {
            reportingObject.createReportButton.Click();
            return this;
        }

        public ReportingAction EnterStartDateTime(string value)
        {
            reportingObject.startDateTime.Clear();
            reportingObject.startDateTime.SendKeys(value);
            reportingObject.startDateTime.SendKeys(Keys.Tab);
            return this;
        }

        public ReportingAction ClickOnShowPreviewButton()
        {
            reportingObject.showPreviewButton.Click();
            return this;
        }

        public ReportingAction ClickOnCreateReportButtonAfterPreview()
        {
            reportingObject.createReporttButton.Click();
            return this;
        }

        public ReportingAction EnterReportName(string value)
        {
            reportingObject.reportNameTextField.Clear();
            reportingObject.reportNameTextField.SendKeys(value);
            reportingObject.reportNameTextField.SendKeys(Keys.Tab);
            return this;
        }

        public ReportingAction ClickOnSaveReportButton()
        {
            reportingObject.saveReportButton.Click();
            return this;
        }

        public ReportingAction SelectFirstReport()
        {
            reportingObject.selectFirstRowReport.Click();
            return this;
        }

        public ReportingAction ClickOnRemoveButton()
        {
            reportingObject.removeReporttButton.Click();
            return this;
        }

        public ReportingAction ClickOnYesButton()
        {
            reportingObject.yesButton.Click();
            return this;
        }
    }
}
