using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo01.Models
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [CNPhoneNum]
        public string Tel { get; set; }
        [QQNumber]
        public string QQ { get; set; }
    }
}