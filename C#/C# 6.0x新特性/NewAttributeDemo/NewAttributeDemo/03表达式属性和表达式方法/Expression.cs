using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    public class Expression
    {
        #region 表达式属性
        public DateTime Birthday { get; set; } = Convert.ToDateTime("1999-9-9");

        //传统写法
        //public int Age
        //{
        //    get { return DateTime.Now.Year - Birthday.Year; }
        //}

        //新写法：
        public int Age => DateTime.Now.Year - Birthday.Year;
        #endregion

        #region 表达式方法
        //传统方法
        //public int Add(int a,int b)
        //{
        //    return a + b;
        //}

        //新写法：
        public int Add(int a, int b) => a + b;
        #endregion

    }
}
