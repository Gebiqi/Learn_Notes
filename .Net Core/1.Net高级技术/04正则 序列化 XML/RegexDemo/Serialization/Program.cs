using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //序列化
            //Person p1 = new Person("ABC", 18);
            //BinaryFormatter bf = new BinaryFormatter();
            //using (FileStream fs = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory+@"\1.person"))
            //{
            //    bf.Serialize(fs, p1);
            //}
            //Console.WriteLine("p1序列化完成");

            //反序列化
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + @"\1.person"))
            {
                Person p1 = (Person)bf.Deserialize(fs);
                Console.WriteLine($"姓名:{p1.Name}    年龄:{p1.Age}");
            }

            Console.ReadLine();

//            注意，不同程序集中的相同类，不能互相序列化和反序列化

//*** 自定义类、字段,内部成员类,父类等都需要被标记为可序列化[serializable]

//一旦类有改变，则之前序列化的数据尽量不要反序列化使用了，有可能会报错


//应用：ASP.net中进程外Session要求对象可序列化，内部通过序列化实现的


//另外还有xml序列化和json序列化等不同格式的序列化方式
        }
    }
}
