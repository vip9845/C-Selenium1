using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumAutomation.Action
{
    public class DashboardAction
    {
        DashboardObject dashboardObject;
        //IWebDriver driver;

        public DashboardAction(IWebDriver driver)
        {
            this.dashboardObject = new DashboardObject(driver);
        }

        public DashboardAction ClickOnCreate()
        {
            dashboardObject.createDashBoard.Click();
            return this;
        }

        public DashboardAction SelectReport(IWebDriver driver)
        {
            DragCardFromColumnToColumn(driver, dashboardObject.reportTemplate, dashboardObject.dropLocation);
            return this;
        }

        internal void DragCardFromColumnToColumn(IWebDriver driver, IWebElement src, IWebElement dst)
        {
            Actions builder = new Actions(driver);

            IAction dragAndDrop = builder.ClickAndHold(src)
               .MoveToElement(dst)
               .Release(dst)
               .Build();

            dragAndDrop.Perform();
        }

        public DashboardAction EnterTitle(string value)
        {
            dashboardObject.dashboardTitleTextField.Clear();
            dashboardObject.dashboardTitleTextField.SendKeys(value);
            dashboardObject.dashboardTitleTextField.SendKeys(OpenQA.Selenium.Keys.Tab);
            return this;
        }

        public DashboardAction ClickOnSetReportParamaeterButton()
        {
            dashboardObject.setReportParamaeterButton.Click();
            return this;
        }

        public DashboardAction ClickOnSaveReportButton()
        {
            dashboardObject.saveReportButton.Click();
            return this;
        }
        public DashboardAction ClickOnDeleteDashboardReportButton()
        {
            dashboardObject.deleteDashboardReporttButton.Click();
            return this;
        }

        public DashboardAction ClickOnSaveOneReportButton()
        {
            dashboardObject.save1ReportButton.Click();
            return this;
        }

        public DashboardAction EnterDashboardReportName(string value)
        {
            dashboardObject.reportNameTextField.Clear();
            dashboardObject.reportNameTextField.SendKeys(value);
            dashboardObject.reportNameTextField.SendKeys(OpenQA.Selenium.Keys.Tab);
            return this;
        }

        public DashboardAction ClickOnAddTimeFilterButton()
        {
            dashboardObject.addTimeFilterButton.Click();
            return this;
        }

        public DashboardAction EnterTimefilterName(string value)
        {
            dashboardObject.timeFilterNameTextField.Clear();
            dashboardObject.timeFilterNameTextField.SendKeys(value);
            dashboardObject.timeFilterNameTextField.SendKeys(OpenQA.Selenium.Keys.Tab);
            return this;
        }

        public DashboardAction ClickOnSaveTimeFilterButton()
        {
            dashboardObject.saveTimefilterReportButton.Click();
            return this;
        }

        public DashboardAction SelectChart(IWebDriver driver)
        {
            DragCardFromColumnToColumn(driver, dashboardObject.chartTemplate, dashboardObject.dropLocation);
            return this;
        }

        public DashboardAction ClickOnAlaramItem()
        {
            dashboardObject.alaramOption.Click();
            return this;
        }

        public DashboardAction ClickOnTotalAlaramCountButton()
        {
            dashboardObject.addTotalAlaramsButton.Click();
            return this;
        }

        public DashboardAction HandleException()
        {
            bool aa = dashboardObject.exceptionPopUp.Displayed;
            if (dashboardObject.exceptionPopUp.Displayed)
            {
                dashboardObject.yesButton.Click();
            }

            return this;
        }

        public DashboardAction SelectTheDashboardReport(IWebDriver driver, string dashboardReportName)
        {
            try
            {
                Thread.Sleep(2000);
                string xpath = ".//div[.='" + dashboardReportName + "']/..";
                IWebElement dashBoardReportImg = driver.FindElement(By.XPath(xpath));
                dashBoardReportImg.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return this;
        }

        public DashboardAction ClickOnDeleteButton()
        {
            Thread.Sleep(1000);
            dashboardObject.deleteButton.Click();
            return this;
        }

        public DashboardAction SelectTheDashboardReport11(IWebDriver driver,out string fileName)
        {
            List<IWebElement> dashBoardReportImg=null;
            try
            {
                //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                //var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(".//*[@class='dashboardList k-widget k-listview k-selectable']/li//div[1]")));
                Thread.Sleep(5000);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string xpath = ".//*[@class='dashboardList k-widget k-listview k-selectable']/li//div[1]";
                dashBoardReportImg = driver.FindElements(By.XPath(xpath)).ToList();                
                dashBoardReportImg[1].Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            fileName = dashBoardReportImg[1].Text;
            return this;
        }

        public DashboardAction ClickOnExportButton()
        {
            dashboardObject.exportButton.Click();
            return this;
        }

        public DashboardAction ClickOnImportButton()
        {
            dashboardObject.importButton.Click();
            return this;
        }

        public DashboardAction ClickOnSelectFileAndEnterPath(string filePath)
        {
            Thread.Sleep(2000);
            dashboardObject.selectFileButton.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait(filePath);
            Thread.Sleep(2000);
            SendKeys.SendWait(@"{Enter}");
            return this;
        }

        public void CheckFile(string fineName, string filePath)
        {
            Thread.Sleep(2000);
            bool result = false;
            string[] fileEntries = Directory.GetFiles(filePath);
            List<string> listItemsName = new List<string>();
            for (int i = 0; i < fileEntries.Length; i++)
            {
                string[] split = fileEntries[i].Split('\\');
                listItemsName.Add(split.Last());
            }
           
            result = listItemsName.Contains(fineName) ? true : false;
            Assert.IsTrue(result, "The expected files are not present.");
        }

        public void CreateCopyFile(string fileName, string filePath)
        {
            Thread.Sleep(2000);
            bool result = false;
            string[] fileEntries = Directory.GetFiles(filePath);
            List<string> listItemsName = new List<string>();
            for (int i = 0; i < fileEntries.Length; i++)
            {
                string[] split = fileEntries[i].Split('\\');
                listItemsName.Add(split.Last());
            }

            result = listItemsName.Contains(fileName) ? true : false;
            if(result)
            { 
                File.Copy(filePath + "\\" + fileName, filePath + "\\" + "Copy_" + fileName);
            }
            Assert.IsTrue(result, "The expected files are not present.");
        }

        public void DeleteFiles(string filePath)
        {
            Thread.Sleep(2000);
            string[] filePaths = System.IO.Directory.GetFiles(filePath, "*.dashboard");
            foreach (string fp in filePaths)
                System.IO.File.Delete(fp);
        }
    }
}
