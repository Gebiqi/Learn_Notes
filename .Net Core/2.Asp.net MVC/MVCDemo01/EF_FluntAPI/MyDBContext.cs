using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF_FluntAPI
{
    class MyDBContext:DbContext
    {
        public MyDBContext() : base("name=connstr")
        {
            Database.SetInitializer<MyDBContext>(null);//去掉DBMigration的sql相关执行
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Configurations.AddFromAssembly(Assembly.LoadFrom("ModelConfig"));
            //modelBuilder.Entity<Person>().ToTable("T_Persons");
            //modelBuilder.Configurations.Add(new PersonConfig());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Dog> Dogs { get; set; }
    }
}
