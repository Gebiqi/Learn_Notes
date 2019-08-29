using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWhere
{
    static class JiHeExt
    {
        //对集合实现一个MyWhere扩展方法
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> data,Func<T,bool> func)
        {
            List<T> result = new List<T>();
            foreach (T item in data)
            {
                if (func(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
