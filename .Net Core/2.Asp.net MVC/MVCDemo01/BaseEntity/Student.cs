using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntity
{
    public class Student:Person
    {
        public string StuNo { get; set; }
        public Class Class { get; set; }
    }
}
