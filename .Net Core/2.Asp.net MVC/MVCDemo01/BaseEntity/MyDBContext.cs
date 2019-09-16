using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntity
{
    public class MyDBContext:DbContext
    {
        public MyDBContext():base("name=connstr")
        {
            //Database.SetInitializer<MyDBContext>(null);
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
