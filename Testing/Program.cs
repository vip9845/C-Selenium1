using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            string filePath= @"C:\Users\Vishnu\Desktop\Files\";
            bool aaa = Directory.Exists(filePath + @"\\Failed_TC_Screenshots");

            string[] pdfFiles = Directory.GetFiles(@"C:\Users\Vishnu\Desktop\Files\Reports").Select(Path.GetFileName).ToArray();

            if (!Directory.Exists(filePath + @"\\Failed_TC_Screenshots"))
                Directory.CreateDirectory(filePath + @"\\Failed_TC_Screenshots");

            string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5, 4);

            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings = false;
            //driver = new InternetExplorerDriver(@"C:\Users\vmadmin\Documents\visual studio 2015\Projects\Testing\packages\Selenium.WebDriver.IEDriver.3.6.0\driver", options);
            //driver = new InternetExplorerDriver();
            string folderPath = ConfigurationManager.AppSettings["FolderPath"];
            string aa = DateTime.Now.Millisecond.ToString() ;
            try
            {

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\z003uutr\source\repos\IS_Selenium_Automation\Testing\drivers\");
                service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; 
                driver = new FirefoxDriver(service);
                driver.Navigate().GoToUrl("http://google.com");

                ///driver.Navigate().GoToUrl("http://localhost");

                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                // string title = driver.Title;


                //IJavaScriptExecutor Executor = ((IJavaScriptExecutor)driver);
                //Executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//a[@id='Reporting']")));

                //string Script = "javascript:document.getElementById('Reporting').click();";
                //((IJavaScriptExecutor)driver).ExecuteScript(Script);

                //string Script1 = "javascript:document.getElementById('Dashboard').click();";
                //((IJavaScriptExecutor)driver).ExecuteScript(Script1);

                //string resource = "javascript:document.getElementByClassName('resource').click();";
                //((IJavaScriptExecutor)driver).ExecuteScript(resource);


                //ManageTimeOut(driver);



                //ReadOnlyCollection<IWebElement> elementRepots = driver.FindElements(By.XPath("//a[@id='Reporting']"));
                //elementRepots[0].Click();

                //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//div"));
                driver.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //driver.Quit();
            }
            
        }

        public static void ManageTimeOut(IWebDriver driver)
        {
            // Manage time out for the web page and controls load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }
    }
}
