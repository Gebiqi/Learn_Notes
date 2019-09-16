using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_AND_EF
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual Class Class { get; set; }
        public virtual MinZu MinZu { get; set; }
    }
}
