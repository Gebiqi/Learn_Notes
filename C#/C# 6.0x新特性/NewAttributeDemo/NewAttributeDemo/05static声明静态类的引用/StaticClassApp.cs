using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace NewAttributeDemo
{
    class StaticClassApp
    {
        /// <summary>
        /// 老的静态类使用
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int AddABS(int a,int b)
        {
            return Math.Abs(a) + Math.Abs(b);
        }

        /// <summary>
        /// 新的静态类使用
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int AddABSNew(int a, int b) => Abs(a) + Abs(b);
    }
}
