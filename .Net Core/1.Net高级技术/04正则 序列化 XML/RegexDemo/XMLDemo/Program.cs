using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ////XML文件的生成
            //Person[] persons = new Person[]
            //{
            //    new Person(1, "AAA", 12),
            //    new Person(2, "CCC", 36),
            //    new Person(3, "DDD", 25),
            //};
            //XmlDocument doc = new XmlDocument();//创建XML文档对象
            //XmlElement ePersons = doc.CreateElement("Persons");//创建根节点
            //doc.AppendChild(ePersons);
            //foreach (Person person in persons)
            //{
            //    XmlElement ePerson=doc.CreateElement("Person");
            //    ePerson.SetAttribute("ID", person.Id.ToString());
            //    XmlElement name = doc.CreateElement("Name");
            //    name.InnerText = person.Name;
            //    XmlElement age = doc.CreateElement("Age");
            //    age.InnerText = person.Age.ToString();
            //    ePerson.AppendChild(name);
            //    ePerson.AppendChild(age);
            //    ePersons.AppendChild(ePerson);
            //}
            //doc.Save(AppDomain.CurrentDomain.BaseDirectory+"person.xml");
            //Console.WriteLine("XML生成成功");

            //XML读取
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory+"person.xml");
            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                XmlElement ePerson = (XmlElement)node;
                Person p = new Person();
                p.Id = Convert.ToInt32(ePerson.GetAttribute("ID"));
                p.Name = ePerson.SelectSingleNode("Name").InnerText;
                p.Age = Convert.ToInt32(ePerson.SelectSingleNode("Age").InnerText);
                Console.WriteLine($"Id：{p.Id}姓名： {p.Name}年龄：{p.Age}");
            }
            Console.ReadLine();
        }
    }


}
