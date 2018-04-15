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

namespace SeleniumTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IWebDriver chromeDriver = new ChromeDriver(@"C:\Users\Vishnu\Desktop\Python\drivers");
                chromeDriver.Navigate().GoToUrl("http://www.google.com");
                chromeDriver.Manage().Window.Maximize();
                IWebElement txtfield = chromeDriver.FindElement(By.Id("lst-ib"));
                txtfield.SendKeys("Python");
                txtfield.SendKeys(Keys.Tab); 
                IWebElement searchButton = chromeDriver.FindElement(By.Name("btnK"));
                searchButton.Click();
                Thread.Sleep(5000);
                chromeDriver.Close();

                IWebDriver FFDriver = new FirefoxDriver(@"C:\Users\Vishnu\Desktop\Python\drivers");
                FFDriver.Navigate().GoToUrl("http://www.google.com");
                FFDriver.Manage().Window.Maximize();
                FFDriver.FindElement(By.Id("lst-ib")).SendKeys("Python");
                FFDriver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Tab);
                FFDriver.FindElement(By.Name("btnK")).Click();
                Thread.Sleep(5000);
                FFDriver.Close();

                IWebDriver IEDriver = new InternetExplorerDriver(@"C:\Users\Vishnu\Desktop\Python\drivers");
                IEDriver.Navigate().GoToUrl("http://www.google.com");
                IEDriver.Manage().Window.Maximize();
                IEDriver.FindElement(By.Id("lst-ib")).SendKeys("Python");
                IEDriver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Tab);
                IEDriver.FindElement(By.Name("btnK")).Click();
                Thread.Sleep(5000);
                IEDriver.Close();

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            


        }
    }
}
