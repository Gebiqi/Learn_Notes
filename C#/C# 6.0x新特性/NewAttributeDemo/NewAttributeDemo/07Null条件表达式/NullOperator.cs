using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    //Null操作符简化空值的检查
    class NullOperator
    {
        string[] arrays = new string[] {"abc","swer",null,null,"dfdaf",null };

        //老方法
        public void OldMethod()
        {
            foreach (string item in arrays)
            {
                var length = item == null ? 0 : item.Length;
                Console.WriteLine(length);
            }
            Console.WriteLine("----------");
        }

        //新方法
        public void NewMethod()
        {
            foreach (var item in arrays)
            {
                var length = item?.Length;//如果为null则输出null
                Console.WriteLine(length);
            }
            Console.WriteLine("---------------");
            foreach (var item in arrays)
            {
                var length = item?.Length ?? 0;//如果为null则输出0;
                Console.WriteLine(length);
            }
            Console.WriteLine("---------------");
        }
    }
}
