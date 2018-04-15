using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
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
using System.Xml;
using System.Xml.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {


            Employee ele3 = CreateEmptyObject<Employee>();

            NewsPapers ele4 = CreateEmptyObject<NewsPapers>();

            ele3.PrintName("");
             ele3.PrintLastName("");


            IWebDriver driver=null;
            try
            {
                List<string> tt = new List<string>();
                IDictionary<string, string> dtt = new Dictionary<string, string>();

                string file = @"C:\Users\Vishnu\Desktop\Testing.xml";

                XDocument xmlDoc = XDocument.Load(file);

                //var q = (from myConfig in xmlDoc.Elements("Template")
                  //       select myConfig.Attribute("Name").Value).First();

                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNodeList elemList = doc.GetElementsByTagName("Template");

                XmlElement elee = doc.GetElementById("1");
                for (int i = 0; i < elemList.Count; i++)
                {
                    string attrVal = elemList[i].Attributes["Name"].Value;

                    if(attrVal== "Template2")
                    {
                        tt.Add(elemList[i].Attributes["Name"].Value);
                        tt.Add(elemList[i].Attributes["StartDate"].Value);
                        tt.Add(elemList[i].Attributes["EndDate"].Value);

                        dtt.Add("Name", elemList[i].Attributes["Name"].Value);
                        dtt.Add("StartDate", elemList[i].Attributes["StartDate"].Value);
                        dtt.Add("EndDate", elemList[i].Attributes["EndDate"].Value);
                    }
                }




                driver = new ChromeDriver(@"C:\Users\Vishnu\Desktop\Python\drivers");

                driver.Navigate().GoToUrl("https://news.google.com/news/headlines?hl=en-IN&ned=in&gl=IN");
                driver.Manage().Window.Maximize();

                IWebElement ele = driver.FindElement(By.XPath(".//*[@id='gb']//span[.='Technology']"));
                IWebElement ele1 = driver.FindElement(By.XPath(".//*[@id='gb']//span[.='India']"));

                Actions builder = new Actions(driver);//simply my webdriver

                int X = ele.Location.X;
                int Y = ele.Location.Y;

                builder.MoveToElement(ele).MoveByOffset(X, Y).Perform();
                Thread.Sleep(4000);
                driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(15);
                builder.MoveToElement(ele1).MoveByOffset(ele1.Location.X, ele1.Location.X).Perform();
                Thread.Sleep(4000);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='gb']//span[.='Technology']")));
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();

                Thread.Sleep(4000);

                //driver.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                driver.Close();
            }
            finally
            {
                driver.Close();
            }

        }

        public static void ManageTimeOut(IWebDriver driver)
        {
            // Manage time out for the web page and controls load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        public static IDictionary<string, string> AddToDict(string templateName)
        {
            IDictionary<string, string> dtt = new Dictionary<string, string>();

            switch (templateName)
            {
                case "Template1":
                    dtt=ReturnDict(templateName);
                    break;
                case "Template2":
                    dtt = ReturnDict(templateName);
                    break;
                default:
                    break;
            }
            return dtt;
        }

        public static IDictionary<string, string> ReturnDict(string templateName)
        {
            IDictionary<string, string> dtt = new Dictionary<string, string>();
            string file = @"C:\Users\Vishnu\Desktop\Testing.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNodeList elemList = doc.GetElementsByTagName("Template");
            for (int i = 0; i < elemList.Count; i++)
            {
                string attrVal = elemList[i].Attributes["Name"].Value;

                if (attrVal == templateName)
                {
                    dtt.Add("Name", elemList[i].Attributes["Name"].Value);
                    dtt.Add("StartDate", elemList[i].Attributes["StartDate"].Value);
                    dtt.Add("EndDate", elemList[i].Attributes["EndDate"].Value);
                }
            }

            return dtt;
        }


        public static T CreateEmptyObject<T>()
        {
            return (T)Activator.CreateInstance(typeof(T)); ;
        }
    }
}
