using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_AND_EF.EntityConfig
{
    public class MinZuConfig:EntityTypeConfiguration<MinZu>
    {
        public MinZuConfig()
        {
            ToTable("T_MinZus");
            this.Property(m => m.Name).IsRequired().HasMaxLength(20);
        }
    }
}
