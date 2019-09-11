using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    class MyDbContext:DbContext
    {
        public MyDbContext() : base("name=connstr")
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
