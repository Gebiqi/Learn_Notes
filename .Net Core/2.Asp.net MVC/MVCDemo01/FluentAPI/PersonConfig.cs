using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class PersonConfig:EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            this.ToTable("T_Persons");
            ////this.HasKey(p=>p.Id);
            ////设置字段最大长度
            //this.Property(e => e.Name).HasMaxLength(30);
            //this.Property(e => e.Name).IsRequired();
            ////this.Property(e => e.Age).IsOptional();一般不会使用，鸡肋
            //this.Ignore(e=>e.Age2);//在数据库中忽略该属性
            //this.Property(e => e.Name).IsFixedLength();//固定长度
            //this.Property(e => e.Name).IsUnicode(false);//非Unicode类型：varchar或char
            ////this.Property(e => e.Name).IsUnicode(true);//Unicode类型：nvarchar或nchar 
            ////PS:
            ////varchar(4) 可以输入4个字线，也可以输入两个汉字
            ////nvarchar(4)可以输四个汉字，也可以输4个字母，但最多四个
            this.Property(e => e.Age).HasColumnName("NianLing");
            this.Property(e => e.Name).HasMaxLength(30).IsRequired().IsUnicode(true);
        }
    }
}
