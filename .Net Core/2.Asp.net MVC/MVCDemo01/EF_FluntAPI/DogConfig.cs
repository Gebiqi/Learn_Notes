using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FluntAPI
{
    class DogConfig:EntityTypeConfiguration<Dog>
    {
        public DogConfig()
        {
            this.ToTable("T_Dogs");
        }
    }
}
