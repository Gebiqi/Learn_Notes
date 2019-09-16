using MVC_AND_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest1
{
    public class HomeIndexModel
    {
        public Class Class { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}