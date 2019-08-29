using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Helper
    {
        public static bool IsEmail(this string s)
        {
            return s.Contains("@");
        }

        public static string Repeat(this string s,int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += s+" ";
            }
            return result;
        }
    }
}
