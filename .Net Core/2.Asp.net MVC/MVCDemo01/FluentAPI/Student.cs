using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long ClassId { get; set; }//将学生和班级建立关联关系
        public virtual Class Class { get; set; } //注意这种关联使用的属性，设置为virtual
        public long XZClassId { get; set; }
        public virtual Class XZClass { get; set; }
    }
}
