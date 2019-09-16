using MVC_AND_EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            ToTable("T_Classes");
        }
    }
}
