using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    static class ExtendMethod
    {
        public static int GetSum(this int num)
        {
            int result = 0;
            for (int i = 0; i < num; i++)
            {
                result += i;
            }
            return result;
        }

        public static string Welcome(this string name)
        {
            string result = $"您好，{name}";
            return result;
        }

        //为密封类添加扩展方法
        public static string ShowStuInfo(this Student objStudent)
        {
            string info = string.Format("姓名：{0},年龄：{1}",objStudent.StudentName,objStudent.Age);
            return info;
        }
        
        public static string ShowStuInfo(this Student objStudent,int cSharp,int database)
        {
            string info = string.Format("姓名：{0},年龄：{1},平均成绩：{2}", objStudent.StudentName, objStudent.Age, (cSharp+ database)/2);
            return info;
        }
    }
}
