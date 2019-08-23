using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    public class NewCollectionInitMethod
    {
        public Dictionary<string,int> OldInitMethod()
        {
            Dictionary<string, int> student = new Dictionary<string, int>();
            student.Add("A", 20);
            student.Add("B", 21);
            student.Add("C", 22);
            student.Add("D", 23);
            return student;
        }
        public Dictionary<string, int> NewInitMethod()
        {
            Dictionary<string, int> student = new Dictionary<string, int>() {
                ["A"] = 20,
                ["B"] = 21,
                ["C"] = 22,
                ["D"] = 23,
            };
            return student;
        }
    }
}
