using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using UnitTesting.Action;
using System.Threading;
using Microsoft.Expression.Encoder.ScreenCapture;
using System.IO;

namespace UnitTesting
{

    [DeploymentItem("ProjectName/Folder/SubFolder/file.xml", "Folder/Subfolder")]
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        ScreenCaptureJob scj;
        public TestContext TestContext { get; set; }
        string testMethodName;
        Recorder rec;
        static bool _testFailed;
        public static string _testVideoFileName;

        [TestInitialize]
        public void MyTestInitialize()
        {
            _testVideoFileName = TestContext.TestName + "_"+ISO_Date();
            rec = new Recorder(new RecorderParams(@"C:\Users\Vishnu\Desktop\VM testing\" + _testVideoFileName + ".avi", 2, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));

            //// Create a instance of ScreenCaptureJob
            //scj = new ScreenCaptureJob();
            //// Specify the path & file name in which you want to save         
            //scj.OutputScreenCaptureFileName = @"C:\Users\Vishnu\Desktop\VM testing\ScreenRecording.wmv";
            //// Start the Screen Capture Job
            //scj.Start();

            driver = new ChromeDriver(@"C:\Users\Vishnu\Desktop\Python\drivers");
            driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/sl/pwd?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)this.driver).ExecuteScript(
                "return document.readyState").Equals("complete");
            });
            driver.Manage().Window.Maximize();
        }

        static string ISO_Date()
        {
            return DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");
        }

        [TestCleanup]
        public void MyTestCleanUp()
        {
            driver.Quit();
            //Stop the Screen Captureing
            //scj.Stop();

            //FileInfo file = new FileInfo(@"C:\Users\Vishnu\Desktop\VM testing\ScreenRecording.wmv");
            //utility.Rename(file, testMethodName+ ".wmv");
            
            if (TestContext.CurrentTestOutcome==UnitTestOutcome.Failed)
            {
                rec.Dispose();
                _testFailed = true;
            }
            else
            {
                rec.StopRecordingVideo(@"C:\Users\Vishnu\Desktop\VM testing\"+ _testVideoFileName + ".avi");
                _testFailed = false;
            }
            Console.WriteLine(TestContext.CurrentTestOutcome);
            Console.WriteLine(_testFailed);
            
        }

        [TestMethod]
        public void ValidCredentialsTest()
        {
            LoginPageAction la = new LoginPageAction(driver);
            testMethodName = TestContext.TestName;

            try
            {
                la.EnterEmaild("ammayi9845");
                Thread.Sleep(2000);
                la.ClickOnNext();
                Thread.Sleep(2000);
                la.EnterPassword();
                Thread.Sleep(2000);
                la.ClickOnNext2();
                Thread.Sleep(8000);
                la.ClickOnLogOut();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Assert.Fail(ex.Message);
            }
            
        }

        [TestMethod]
        public void InValidCredentialsTest()
        {
            LoginPageAction la = new LoginPageAction(driver);
            testMethodName = TestContext.TestName;

            try
            {
                la.EnterEmaild("ammayi99");
                Thread.Sleep(2000);
                la.ClickOnNext();
                Thread.Sleep(2000);
                la.EnterPassword();
                Thread.Sleep(2000);
                la.ClickOnNext2();
                Thread.Sleep(8000);
                la.ClickOnLogOut();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                Assert.Fail(ex.Message);
                //scj.Stop();



                //FileInfo file = new FileInfo(@"C:\Users\Vishnu\Desktop\VM testing\ScreenRecording.wmv");
                //utility.Rename(file, testMethodName + ".wmv");
            }

        }

    }
}
