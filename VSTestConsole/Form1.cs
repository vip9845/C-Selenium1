using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSTestConsole
{
    public partial class Form1 : Form
    {
        string assemblyDllPath = string.Empty;
        string filterText = string.Empty;
        static List<string> output1 = new List<string>();
        static List<string> output2 = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            assemblyDllPath = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            output1 = FindTestNames(assemblyDllPath);
            lblCount.Text = output1.Count.ToString();
            listBox1.DataSource = output1;
        }

        private static List<string> FindTestNames(string path)
        {
            Assembly assem = Assembly.LoadFrom(path);

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

            return tm;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            filterText = txtFilter.Text;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            output1 = FindMatchingTestNames(filterText);
            lblCount.Text = output1.Count.ToString();
            listBox1.DataSource = output1;
        }

        private static List<string> FindMatchingTestNames(string filterText)
        {
            List<string> tm = new List<string>();

            for (int i = 0; i < output1.Count; i++)
            {
                if (output1[i].Contains(filterText))
                    tm.Add(output1[i]);
            }

            return tm;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            List<string> output3 = new List<string>();

            output3.AddRange(output2);

            string selected = listBox1.GetItemText(listBox1.SelectedValue);

            if(!output3.Contains(selected))
            {
                output3.Add(selected);

                output2.Clear();

                output2.AddRange(output3);

                listBox2.DataSource = output3;
            }
            else
            {
                string message = string.Format("Already this {0} TestMethod Added!!!!", selected);
                MessageBox.Show(message);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string selected = listBox2.GetItemText(listBox2.SelectedValue);

            output2.Remove(selected);
            if(output2.Count>0)
            {
                listBox2.DataSource = output2;
            }
            else
            {
                output2.Clear();
                listBox2.DataSource= new BindingSource(output2, null);
            }
            

        }
    }
}
