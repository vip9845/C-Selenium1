using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MSUnitTest
{
    [TestClass]
    public class UnitTest1:DriverTestFixtureBase
    {
        IWebDriver driver;
        static string folderPath = ConfigurationManager.AppSettings["FolderPath"];
        string driverPath = ConfigurationManager.AppSettings["DriverPath"];
        string imageFormat = ConfigurationManager.AppSettings["imageformat"];
        static string logFileFolderPath = folderPath + "\\Logs\\";
        static string logFilePath;
        string ssPath1 = folderPath+ "\\Errors\\";

        private static string pathStringfolder = System.IO.Path.Combine(System.IO.Path.Combine("C:\\MIDILog\\", DateTime.Today.ToShortDateString().Replace('/', '_')), "SanityTests" + DateTime.Now.ToFileTimeUtc());

        [ClassInitialize]
        public static void MyClassInitialize(TestContext context)
        {
            logFilePath = logFileFolderPath + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + "_Log_" + System.DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_FFF") + "." + "txt";
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            WriteLog("\n****************************************************************************");
            Console.WriteLine("Step-1: Entered Test Initialize \n");
            //WriteLog("Step-1: Entered Test Initialize \n");
            driver = new ChromeDriver(driverPath);
            driver.Navigate().GoToUrl("https://image.online-convert.com/convert-to-jpg");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Step-2: Test Initialize Completed \n");
            //WriteLog("Step-2: Test Initialize Completed \n");
        }
      
        [TestMethod, TestCategory("Administraton"), Owner("VIP")]
        public void TC10004_TestMethod_Home()
        {
            //logFilePath = logFileFolderPath + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7)+ "_Log_" + System.DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_FFF") + "." + "txt";

            try
            {
                #region
                /*
                Console.WriteLine("Automation Started");
                
                driver.Navigate().GoToUrl("http://localhost");
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Manage().Window.Maximize();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                string pageTitle = driver.Title;
                
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("//a[@id='Reporting']")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath(".//*[@class='nav nav-stacked navigation']//a[@href='/#Home']")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath("//a[@id='Dashboard']")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath(".//*[@class='nav nav-stacked navigation']//a[@href='/#Home']")).Click();

                Thread.Sleep(5000);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath("//a[@id='Administration']")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath(".//*[@class='nav nav-stacked navigation']//a[@href='/#Home']")).Click();

                Console.WriteLine(pageTitle);
                */
                #endregion
                
                WriteLog("Started : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7)+" Log");

                Console.WriteLine("Step-3: Entered Test Method");
                WriteLog("Step-3: Entered Test Method \n");
                IWebElement fileInput = driver.FindElement(By.Id("file"));
                fileInput.Click();

                string[] pdfFiles = Directory.GetFiles(folderPath, imageFormat).Select(Path.GetFileName).ToArray();

                string path = Path.Combine(folderPath, pdfFiles[0]);

                Thread.Sleep(2000);
                SendKeys.SendWait(path);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//select[@id='quality']/option[contains(.,'Best')]")).Click();
                Thread.Sleep(2000);
                IWebElement shrapenCheckbox = driver.FindElement(By.XPath("(//input[@type='checkbox'])[2]"));
                if (!shrapenCheckbox.Selected)
                {
                    shrapenCheckbox.Click();
                }
                IWebElement normalizeCheckbox = driver.FindElement(By.XPath("(//input[@type='checkbox'])[4]"));
                if (!normalizeCheckbox.Selected)
                {
                    normalizeCheckbox.Click();
                }
                Thread.Sleep(2000);

                Assert.Inconclusive("Method that does not return a value");

                Console.WriteLine("Step-4: Test Method Completed \n");
                WriteLog("Step-4: Test Method Completed \n");
            }
            catch (NoSuchElementException ex)
            {
                string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5,7);
                CaptureScreenShot(driver, folderPath, pathString);
                WriteLog(Environment.NewLine +ex.Message + Environment.NewLine + ex.StackTrace);
                Assert.Fail(ex.Message);
                WriteLog(ex.Message);
            }
            catch (Exception ex)
            {
                string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5, 7);
                CaptureScreenShot(driver, folderPath, pathString);
                WriteLog(Environment.NewLine + "TestCase Id: " + MethodInfo.GetCurrentMethod().ToString().Substring(5) + Environment.NewLine +
                ex.Message + Environment.NewLine + ex.StackTrace);
                Assert.Fail(ex.Message);
                WriteLog(ex.Message);
            }
        }

        [TestMethod, TestCategory("Administraton"), Owner("VIP")]
        public void TC10005_TestMethod_Hall()
        {
            //logFilePath = logFilePath + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + "_Log_" + System.DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_FFF") + "." + "txt";

            try
            {
                WriteLog("Started : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7)+ " Log "+ Environment.NewLine);

                Console.WriteLine("Step-3: Entered Test Method \n");
                WriteLog("Step-3: Entered Test Method \n");
                IWebElement fileInput = driver.FindElement(By.Id("file"));
                fileInput.Click();

                string[] pdfFiles = Directory.GetFiles(folderPath, imageFormat).Select(Path.GetFileName).ToArray();

                string path = Path.Combine(folderPath, pdfFiles[0]);

                Thread.Sleep(2000);
                SendKeys.SendWait(path);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//select[@id='quality']/option[contains(.,'Best')]")).Click();
                Thread.Sleep(2000);
                IWebElement shrapenCheckbox = driver.FindElement(By.XPath("(//input[@type='checkbox'])[2]"));
                if (!shrapenCheckbox.Selected)
                {
                    shrapenCheckbox.Click();
                }
                IWebElement normalizeCheckbox = driver.FindElement(By.XPath("(//input[@type='checkbox'])[4]"));
                if (!normalizeCheckbox.Selected)
                {
                    normalizeCheckbox.Click();
                }
                Thread.Sleep(2000);

                Console.WriteLine("Step-4: Test Method Completed \n");
                WriteLog("Step-4: Test Method Completed \n");
            }
            catch (NoSuchElementException ex)
            {
                string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5, 7);
                CaptureScreenShot(driver, folderPath, pathString);
                WriteLog(Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                Assert.Fail(ex.Message);
                WriteLog(ex.Message);
                WriteLog("Ended : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5, 7);
                CaptureScreenShot(driver, folderPath, pathString);
                WriteLog(Environment.NewLine + "TestCase Id: " + MethodInfo.GetCurrentMethod().ToString().Substring(5) + Environment.NewLine +
                ex.Message + Environment.NewLine + ex.StackTrace);
                Assert.Fail(ex.Message);
                WriteLog(ex.Message);
                WriteLog("Ended : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + Environment.NewLine + Environment.NewLine);
            }
        }

        [TestMethod, TestCategory("Administraton"), Owner("VIP")]
        public void TC10006_TestMethod_Kitchen()
        {
            //logFilePath = logFilePath + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + "_Log_" + System.DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_FFF") + "." + "txt";

            try
            {
                WriteLog("Started : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + " Log " + Environment.NewLine);

                Console.WriteLine("Step-3: Entered Test Method \n");
                WriteLog("Step-3: Entered Test Method \n");
                IWebElement fileInput = driver.FindElement(By.Id("file"));
                fileInput.Click();

                string[] pdfFiles = Directory.GetFiles(folderPath, imageFormat).Select(Path.GetFileName).ToArray();

                string path = Path.Combine(folderPath, pdfFiles[0]);

                Thread.Sleep(2000);
                SendKeys.SendWait(path);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//select[@id='quality']/option[contains(.,'Best')]")).Click();
                Thread.Sleep(2000);
                IWebElement shrapenCheckbox = driver.FindElement(By.XPath("(//input[@type='checkbox'])[2]"));
                if (!shrapenCheckbox.Selected)
                {
                    shrapenCheckbox.Click();
                }
                IWebElement normalizeCheckbox = driver.FindElement(By.XPath("(//input[@type='checkbox'])[4]"));
                if (!normalizeCheckbox.Selected)
                {
                    normalizeCheckbox.Click();
                }
                Thread.Sleep(2000);

                Console.WriteLine("Step-4: Test Method Completed \n");
                WriteLog("Step-4: Test Method Completed \n");
            }
            catch (NoSuchElementException ex)
            {
                string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5, 7);
                CaptureScreenShot(driver, folderPath, pathString);
                WriteLog(Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                Assert.Fail(ex.Message);
                WriteLog(ex.Message);
                WriteLog("Ended : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                string pathString = MethodInfo.GetCurrentMethod().ToString().Substring(5, 7);
                CaptureScreenShot(driver, folderPath, pathString);
                WriteLog(Environment.NewLine + "TestCase Id: " + MethodInfo.GetCurrentMethod().ToString().Substring(5) + Environment.NewLine +
                ex.Message + Environment.NewLine + ex.StackTrace);
                Assert.Fail(ex.Message);
                WriteLog(ex.Message);
                WriteLog("Ended : " + MethodInfo.GetCurrentMethod().ToString().Substring(5, 7) + Environment.NewLine + Environment.NewLine);
            }
        }

        [TestCleanup]
        public void MyTestCleanUp()
        {
            Console.WriteLine("Step-5: Entered Test Cleanup \n");
            WriteLog("Step-5: Entered Test Cleanup \n");
            driver.Quit();
            Thread.Sleep(2000);
            Console.WriteLine("Step-6: Test Cleanup Completed \n");
            WriteLog("Step-6: Test Cleanup Completed \n");
            WriteLog("**************************************************************************** \n \n");
            WriteLog(Environment.NewLine);
        }


        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;
           
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logFileInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }

        public static string CaptureScreenShot(IWebDriver driver, string filePath, string tcName)
        {
            string scrrenshotPath = filePath + @"\\Failed_TC_Screenshots\\";
            if (!Directory.Exists(scrrenshotPath))
                Directory.CreateDirectory(scrrenshotPath);

            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            String fp = scrrenshotPath + "IS2018_"+ tcName + "_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt") + ".png";
            screenshot.SaveAsFile(fp, ScreenshotImageFormat.Png);
            return fp;
        }


    }

  
}
