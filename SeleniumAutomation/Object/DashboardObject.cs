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
    public class DashboardObject
    {
        private IWebDriver driver;
        public DashboardObject(IWebDriver driver)
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

        [FindsBy(How = How.XPath, Using = "(.//span[text()='Create'])[2]")]
        public IWebElement createDashBoard;

        #region Elements Inside Page

        [FindsBy(How = How.XPath, Using = ".//span[text()='Report']/..//img")]
        public IWebElement reportTemplate;


        [FindsBy(How = How.XPath, Using = ".//div[@class='dynamicTemplate gridster']")]
        public IWebElement dropLocation;

        [FindsBy(How = How.Id, Using = "RDLWidgetConfig_control_1")]
        public IWebElement dashboardTitleTextField;

        [FindsBy(How = How.XPath, Using = "//*[@class='fullSize btn btn-default']")]
        public IWebElement setReportParamaeterButton;

        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-default btn-primary saveButton']")]
        public IWebElement saveReportButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-default widgetDelete']")]
        public IWebElement deleteDashboardReporttButton;

        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-primary resource save']")]
        public IWebElement save1ReportButton;

        [FindsBy(How = How.Id, Using = "DynamicDashboardViewModel_control_3")]
        public IWebElement reportNameTextField;

        [FindsBy(How = How.XPath, Using = "(//*[@class='btn btn-default navbar-btn'])[3]")]
        public IWebElement addTimeFilterButton;

        [FindsBy(How = How.Id, Using = "Collection_EditItem_filters_RelAndListDateTimeEntryViewModel_control_1")]
        public IWebElement timeFilterNameTextField;

        [FindsBy(How = How.XPath, Using = "(.//button[@class='btn btn-primary'])[2]")]
        public IWebElement saveTimefilterReportButton;

        [FindsBy(How = How.XPath, Using = ".//span[text()='Chart']/..//img")]
        public IWebElement chartTemplate;

        [FindsBy(How = How.XPath, Using = ".//span[.='ALARM']")]
        public IWebElement alaramOption;

        [FindsBy(How = How.XPath, Using = ".//table[@class='k-selectable']//*[@class='btn btn-default']")]
        public IWebElement addTotalAlaramsButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='app-alert danger']")]
        public IWebElement exceptionPopUp;

        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-primary']")]
        public IWebElement yesButton;

        [FindsBy(How = How.XPath, Using = "(.//button[@class='btn btn-default navbar-btn buttonForOneDashboardSelected deleteSelectedDashboard'])[2]")]
        public IWebElement deleteButton;

        [FindsBy(How = How.XPath, Using = ".//*[@class='dashboardList k-widget k-listview k-selectable']/li//div[1]")]
        public IWebElement reportList;

        [FindsBy(How = How.XPath, Using = "(.//button[@class='btn btn-default navbar-btn buttonForOneDashboardSelected exportSelectedDashboard'])[2]")]
        public IWebElement exportButton;

        [FindsBy(How = How.XPath, Using = "(.//button[@class='btn btn-default navbar-btn importDashboard buttonForFolderSelected'])[2]")]
        public IWebElement importButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-default uploadButton']")]
        public IWebElement selectFileButton;

        #endregion
        public string GetPageTitle()
        {           
            return driver.Title;
        }


    }
}
