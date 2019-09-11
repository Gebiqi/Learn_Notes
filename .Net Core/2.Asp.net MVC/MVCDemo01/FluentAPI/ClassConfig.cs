using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            this.ToTable("T_Classes");
            //this.HasMany(c => c.Students).WithRequired().HasForeignKey(s => s.ClassId);
        }
    }
}
