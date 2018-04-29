using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverCorrection
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement ele = driver.FindElement(By.Id("lst-ib"));
            ele.SendKeys("Python ");
            Thread.Sleep(10000);
            driver.Close();

            //IWebDriver driver1 = new FirefoxDriver();
            //driver1.Navigate().GoToUrl("http://www.google.com");
            //IWebElement ele1 = driver1.FindElement(By.Id("lst-ib"));
            //ele1.SendKeys("Python ");
            //Thread.Sleep(10000);
            //driver1.Close();


            //IWebDriver driver2 = new InternetExplorerDriver();
            //driver2.Navigate().GoToUrl("http://www.google.com");
            //IWebElement ele2 = driver2.FindElement(By.Id("lst-ib"));
            //ele2.SendKeys("Python ");
            //Thread.Sleep(10000);
            //driver2.Close();

        }
    }
}
