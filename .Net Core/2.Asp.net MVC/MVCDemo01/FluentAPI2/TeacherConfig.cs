using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2
{
    class TeacherConfig:EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            ToTable("T_Teachers");
            Property(t => t.Name).IsRequired().HasMaxLength(30);
            //配置实体间多对多关系
            this.HasMany(t => t.Students).WithMany(s => s.Teachers).Map(m => m.ToTable("T_TeacherStudentRelations").MapLeftKey("TeacherId").MapRightKey("StudentId"));
        }
    }
}
