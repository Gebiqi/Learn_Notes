using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_AND_EF.EntityConfig
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            ToTable("T_Students");
            this.Property(s => s.Name).IsRequired().HasMaxLength(20);
            this.Property(s => s.Age).IsRequired();
            this.HasRequired(s => s.Class).WithMany();
            this.HasRequired(s => s.MinZu).WithMany();
        }
    }
}
