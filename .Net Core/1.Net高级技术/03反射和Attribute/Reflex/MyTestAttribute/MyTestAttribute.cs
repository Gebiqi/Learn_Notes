using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestAttribute
{
    [AttributeUsage(AttributeTargets.All)]
    class DisplayJapaneseNameAttribute : Attribute
    {
        public string Name { get; set; }
        public DisplayJapaneseNameAttribute(string value)
        {
            this.Name = value;
        }
    }
}
