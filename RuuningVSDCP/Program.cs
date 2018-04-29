using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuuningVSDCP
{
    class Program
    {
        static void Main(string[] args)
        {
            //tttt();
            var assemblyName = "TestSolution.dll";
            var assemblypath = Path.Combine(@"C:\Users\Vishnu\Source\Repos\SeleniumFrameworkDesign\TestSolution\bin\Debug", assemblyName);
            //Get the Assembly
            Assembly assem = Assembly.LoadFrom(@"C:\Users\Vishnu\Source\Repos\SeleniumFrameworkDesign\TestSolution\bin\Debug\TestSolution.dll");

            List<string> arrl = new List<string>();
            List<string> tm = new List<string>();
            //Get a list of the Classes
            Type[] types = assem.GetTypes();

            //Get a list of the Methods
            foreach (Type cls in types)
            {
                try
                {
                    MemberInfo[] methodName = cls.GetMethods();
                    foreach (MemberInfo method in methodName)
                    {
                        object attribute = method.GetCustomAttributes(typeof(TestMethodAttribute), true).FirstOrDefault();

                        if (attribute != null)
                        {
                            tm.Add(method.Name);
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("Error msg");
                }
            }
        }
      
    }
}

