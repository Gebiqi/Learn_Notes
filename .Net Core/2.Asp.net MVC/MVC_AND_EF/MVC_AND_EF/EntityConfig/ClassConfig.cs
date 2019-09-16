using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_AND_EF.EntityConfig
{
    class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            ToTable("T_Classes");
            this.Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }
}
