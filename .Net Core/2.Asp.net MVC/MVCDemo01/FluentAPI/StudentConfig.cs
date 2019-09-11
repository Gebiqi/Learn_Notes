using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            this.ToTable("T_Students");
            this.HasRequired(s => s.Class).WithMany().HasForeignKey(s => s.ClassId);
        }
    }
}
