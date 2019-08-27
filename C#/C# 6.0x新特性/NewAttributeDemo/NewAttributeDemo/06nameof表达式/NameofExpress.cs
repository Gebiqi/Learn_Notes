using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    class NameofExpress
    {
        /// <summary>
        /// 老方法
        /// </summary>
        /// <param name="account"></param>
        public void OldMethod(int account)
        {
            if (account<100)
            {
                Console.WriteLine("参数account的值不能小于100元");
            }
        }
        //当参数变化时，会在引用的地方同步变化，避免硬编码
        //nameof中可以是类名、方法名、属性名、参数名
        public void NewMethod(int account)
        {
            if (account<100)
            {
                Console.WriteLine($"参数{nameof(account)}的值不能小于100元");
            }
        }
    }
}
