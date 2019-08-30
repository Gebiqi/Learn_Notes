using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyTestAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "ABC";
            p1.Age = 11;
            Type type = p1.GetType();
            object[] objattrs = type.GetCustomAttributes(typeof(ObsoleteAttribute), false);
            if (objattrs.Length>0)
            {
                Console.WriteLine("这个方法已经过时");
            }
            else
            {
                Console.WriteLine("这个方法没有过时");
            }
            foreach (PropertyInfo item in type.GetProperties())
            {
                string propName = item.Name;
                object propValue = item.GetValue(p1);

                object[] objs= item.GetCustomAttributes(typeof(DisplayNameAttribute),false);
                string displayName = "";
                string displayJapanName = "";
                if (objs.Length>0)
                {
                    DisplayNameAttribute dattr = (DisplayNameAttribute)objs[0];
                    displayName = "(" + dattr.DisplayName + ")";
                }
                DisplayJapaneseNameAttribute displayjanpanNameAttr = (DisplayJapaneseNameAttribute)item.GetCustomAttribute(typeof(DisplayJapaneseNameAttribute));
                if (displayjanpanNameAttr!=null)
                {
                    displayJapanName = "(" + displayjanpanNameAttr.Name + ")";
                }
                Console.WriteLine(propName+displayName+displayJapanName+"="+propValue);

            }


            Console.ReadLine();
        }
        [Obsolete]
        public class Person
        {
            [DisplayName("姓名")]
            [DisplayJapaneseName("XingMing")]
            public string Name { get; set; }
            [DisplayName("年龄")]
            public int Age { get; set; }
        }
    }
}
