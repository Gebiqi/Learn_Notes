﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntity
{
    public class Teacher:Person
    {
        public int Salary { get; set; }
        public int Grade { get; set; }
    }
}
