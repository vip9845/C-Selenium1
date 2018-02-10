using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using SeleniumAutomation.Action;
using SeleniumAutomation.Object;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAutomation
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
       
        [TestInitialize]
        public void MyTestInitialize()
        {
            driver = new ChromeDriver(@"C:\Users\z003uutr\source\repos\IS_Selenium_Automation\packages\Selenium.WebDriver.ChromeDriver.2.33.0\driver\win32");
            driver.Navigate().GoToUrl("https://localhost/#/");
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)this.driver).ExecuteScript(
                "return document.readyState").Equals("complete");
            });
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void MyTestCleanUp()
        {
            driver.Quit();
        }

        #region IS Basic TC
        [TestMethod]
        public void TestMethod2()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            try
            {
                Console.WriteLine("Test Started");
                WaitForMoment(4);
                homePageAct.ClickOnReportsLink();
                WaitForMoment(4);
                homePageAct.ClickOnHomePageLink();
                WaitForMoment(4);
                homePageAct.ClickOnDashboardLink();
                WaitForMoment(4);
                homePageAct.ClickOnHomePageLink();
                WaitForMoment(4);
                homePageAct.ClickOnAdministratonLink();
                WaitForMoment(4);
                homePageAct.ClickOnHomePageLink();
                WaitForMoment(2);

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);               
            }          
        }

        [TestMethod,TestCategory("DashBoard")]
        public void TC01_VerifyingNavigationToDashBoardPage()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            try
            {
                Console.WriteLine("Test Started");

                homePageAct.VerifyingPageTitle("SIMATIC Information Server");
                homePageAct.VerifyHomePageLinks();
                homePageAct.ClickOnDashboardLink();
                WaitForMoment(4);
                homePageAct.VerifyingCreateButton();

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod, TestCategory("Download")]
        public void TC02_VerifyingNavigationToDownloadPage()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            try
            {
                Console.WriteLine("Test Started");

                homePageAct.VerifyingPageTitle("SIMATIC Information Server");
                homePageAct.VerifyHomePageLinks();
                homePageAct.ClickOnDownloadLink();
                WaitForMoment(4);
                homePageAct.VerifyingDownloadLink();

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod, TestCategory("Reporting")]
        public void TC03_VerifyingNavigationToReportsPage()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            try
            {
                Console.WriteLine("Test Started");

                homePageAct.VerifyingPageTitle("SIMATIC Information Server");
                homePageAct.VerifyHomePageLinks();
                homePageAct.ClickOnReportsLink();
                WaitForMoment(4);
                homePageAct.VerifyingReportsTemplate();

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TC04_VerifyingNavigationToAdministrationPage()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            try
            {
                Console.WriteLine("Test Started");

                homePageAct.VerifyingPageTitle("SIMATIC Information Server");
                homePageAct.VerifyHomePageLinks();
                homePageAct.ClickOnAdministratonLink();
                WaitForMoment(4);
                homePageAct.VerifyingConfigurationLink();

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion



        [TestMethod, TestCategory("Reporting")]
        public void TC05_CreateReportForMessageTemplate()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            ReportingAction reportAct = new ReportingAction(driver);
            try
            {
                Console.WriteLine("Test Started");

                WaitForMoment(4);
                homePageAct.ClickOnReportsLink();
                WaitForMoment(4);
                reportAct.ExpandALL();
                reportAct.ExpandALL();
                reportAct.ExpandALL();
                reportAct.ExpandALL();
                reportAct.ClickOnDurationUntilAcknowledgementReport();
                WaitForMoment(4);
                reportAct.ClickOnCreateReportButton();
                WaitForMoment(4);
                reportAct.EnterStartDateTime("11/19/2017 4:37:10 PM");
                WaitForMoment(4);
                reportAct.ClickOnShowPreviewButton();
                WaitForMoment(15);
                reportAct.ClickOnCreateReportButtonAfterPreview();
                WaitForMoment(4);
                reportAct.EnterReportName("IS_Report_"+DateTime.Now.Millisecond);
                WaitForMoment(4);
                reportAct.ClickOnSaveReportButton();
                WaitForMoment(10);

                // Deletes the Created Report
                reportAct.SelectFirstReport();
                WaitForMoment(4);
                reportAct.ClickOnRemoveButton();
                WaitForMoment(4);
                reportAct.ClickOnYesButton();
                WaitForMoment(4);

                Console.WriteLine("Test Finished");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod, TestCategory("DashBoard")]
        public void TC06_CreateReportForDashboard_UsingReportWidget()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            DashboardAction dashboardAct = new DashboardAction(driver);
            ReportingAction reportAct = new ReportingAction(driver);
            Random random = new Random();
            string dashboardReportName = "Test_DashboardChartName_" + random.Next(0, 400);

            try
            {
                Console.WriteLine("Test Started");

                WaitForMoment(4);
                homePageAct.ClickOnDashboardLink();
                WaitForMoment(4);
                dashboardAct.ClickOnCreate();
                WaitForMoment(4);
                dashboardAct.SelectReport(driver);
                WaitForMoment(4);
                dashboardAct.EnterTitle("DashBoardTesting_" + random.Next(800, 1000));
                WaitForMoment(4);
                reportAct.ExpandALL();
                reportAct.ClickOnDurationUntilAcknowledgementReport();
                WaitForMoment(4);
                dashboardAct.ClickOnSetReportParamaeterButton();
                WaitForMoment(4);
                reportAct.EnterStartDateTime("11/19/2017 4:37:10 PM");
                WaitForMoment(4);
                reportAct.ClickOnShowPreviewButton();
                WaitForMoment(15);
                dashboardAct.ClickOnSaveReportButton();
                WaitForMoment(4);
                reportAct.ClickOnSaveReportButton();
                WaitForMoment(20);
                dashboardAct.ClickOnSaveOneReportButton();
                WaitForMoment(4);
                dashboardAct.EnterDashboardReportName(dashboardReportName);
                WaitForMoment(4);
                dashboardAct.ClickOnAddTimeFilterButton();
                WaitForMoment(4);
                dashboardAct.EnterTimefilterName("Timefilter_Name_"+random.Next(400, 800));
                WaitForMoment(4);
                dashboardAct.ClickOnSaveTimeFilterButton();
                WaitForMoment(4);
                reportAct.ClickOnSaveReportButton();
                WaitForMoment(4);
                dashboardAct.SelectTheDashboardReport(driver, dashboardReportName);
                WaitForMoment(4);
                dashboardAct.ClickOnDeleteButton();
                WaitForMoment(4);
                reportAct.ClickOnYesButton();
                WaitForMoment(10);

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod, TestCategory("DashBoard")]
        public void TC06_CreateReportForDashboard_UsingChartWidget()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            DashboardAction dashboardAct = new DashboardAction(driver);
            ReportingAction reportAct = new ReportingAction(driver);
            Random random = new Random();
            string dashboardReportName = "Test_DashboardChartName_" + random.Next(0, 400);

            try
            {
                Console.WriteLine("Test Started");

                WaitForMoment(4);
                homePageAct.ClickOnDashboardLink();
                WaitForMoment(4);
                dashboardAct.ClickOnCreate();
                WaitForMoment(4);
                dashboardAct.SelectChart(driver);
                WaitForMoment(4);
                dashboardAct.ClickOnAddTimeFilterButton();
                WaitForMoment(4);
                reportAct.ExpandALL();
                WaitForMoment(4);
                dashboardAct.ClickOnAlaramItem();
                WaitForMoment(4);
                dashboardAct.ClickOnTotalAlaramCountButton();
                WaitForMoment(4);
                dashboardAct.ClickOnSaveTimeFilterButton();
                WaitForMoment(4);
                reportAct.ClickOnSaveReportButton();
                WaitForMoment(4);
               //dashboardAct.HandleException();
                WaitForMoment(4);
                dashboardAct.ClickOnSaveOneReportButton();
                WaitForMoment(4);
                dashboardAct.EnterDashboardReportName(dashboardReportName);
                WaitForMoment(4);
                dashboardAct.ClickOnAddTimeFilterButton();
                WaitForMoment(4);
                dashboardAct.EnterTimefilterName("Timefilter_Name_" + random.Next(400, 800));
                WaitForMoment(4);
                dashboardAct.ClickOnSaveTimeFilterButton();
                WaitForMoment(4);
                reportAct.ClickOnSaveReportButton();
                WaitForMoment(4);
                dashboardAct.SelectTheDashboardReport(driver,dashboardReportName);
                WaitForMoment(4);
                dashboardAct.ClickOnDeleteButton();
                WaitForMoment(4);
                reportAct.ClickOnYesButton();
                WaitForMoment(10);

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod, TestCategory("DashBoard")]
        public void TC06_ExportDashboardReport()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            DashboardAction dashboardAct = new DashboardAction(driver);
            string fileName=string.Empty;

            try
            {
                Console.WriteLine("Test Started");

                WaitForMoment(5);
                homePageAct.ClickOnDashboardLink();
                dashboardAct.SelectTheDashboardReport11(driver,out fileName);  
                dashboardAct.ClickOnExportButton();
                dashboardAct.CheckFile(fileName+ ".dashboard", @"C:\Users\z003uutr\Downloads");
                dashboardAct.DeleteFiles(@"C:\Users\z003uutr\Downloads");

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod, TestCategory("DashBoard")]
        public void TC06_ImportDashboardReport()
        {
            HomeObject homeObj = new HomeObject(driver);
            HomeAction homePageAct = new HomeAction(driver);
            DashboardAction dashboardAct = new DashboardAction(driver);
            ReportingAction reportAct = new ReportingAction(driver);
            string fileName = string.Empty;

            try
            {
                Console.WriteLine("Test Started");

                WaitForMoment(5);
                homePageAct.ClickOnDashboardLink();
                dashboardAct.SelectTheDashboardReport11(driver, out fileName);
                dashboardAct.ClickOnExportButton();
                dashboardAct.CreateCopyFile(fileName + ".dashboard", @"C:\Users\z003uutr\Downloads");
                dashboardAct.ClickOnImportButton();
                dashboardAct.ClickOnSelectFileAndEnterPath(@"C:\Users\z003uutr\Downloads"+"\\"+ "Copy_" + fileName + ".dashboard");
                reportAct.ClickOnSaveReportButton();
                dashboardAct.SelectTheDashboardReport(driver, fileName);
                dashboardAct.ClickOnDeleteButton();
                reportAct.ClickOnYesButton();
                dashboardAct.DeleteFiles(@"C:\Users\z003uutr\Downloads");

                Console.WriteLine("Test Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WaitForMoment(int value)
        {
            Thread.Sleep(value * 1000);
        }

       
    }
}
