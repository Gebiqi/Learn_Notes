using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    public class Student
    {
        #region 以前的写法
        //public Student()
        //{
        //    StudentId = 1001;
        //    StudentName = "HuHu";
        //    Age = 30;
        //}
        //public int StudentId { get; set; }
        //public string StudentName { get; set; }
        //public int Age { get; set; }
        //private readonly string gender = "男";
        //public string Gender
        //{
        //    get { return gender; }
        //}
        #endregion
        #region 新特性写法
        public int StudentId { get; set; } = 1001;
        public string StudentName { get; set; } = "HuHu";
        public int Age { get; set; } = 30;
        public string Gender { get; } = "男";
        #endregion

    }
}
