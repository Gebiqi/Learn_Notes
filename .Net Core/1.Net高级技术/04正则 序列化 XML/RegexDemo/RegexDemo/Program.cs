using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Regex.IsMatch("123", @"^\d{1,3}$"));
            Match match = Regex.Match("2018-02-3",@"^(\d{4})-(\d{1,2})-(\d{1,2})$");
            if (match.Success)
            {
                string s1 = match.Groups[1].ToString();
                string s2 = match.Groups[2].ToString();
                string s3 = match.Groups[3].ToString();
                Console.WriteLine(s1+"年"+s2+"月"+s3+"日");
            }
            Console.ReadLine();
        }
    }
}
