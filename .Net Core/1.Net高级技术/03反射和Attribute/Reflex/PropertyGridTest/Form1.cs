using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyGridTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p1 = new Person();
            p1.Name = "HuHu";
            p1.Age = 18;
            propertyGrid1.SelectedObject = p1;
        }
    }
    public class Person
    {
        public Person()
        {

        }
        public Person(string name)
        {
            this.Name = name;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public void SayHi()
        {
            Console.WriteLine($"大家好，我的姓名是{this.Name},我的年龄是{this.Age}.");
        }
        public void SayHi(string s)
        {
            Console.WriteLine($"{s}，我的姓名是{this.Name},我的年龄是{this.Age}.");
        }
    }
}
