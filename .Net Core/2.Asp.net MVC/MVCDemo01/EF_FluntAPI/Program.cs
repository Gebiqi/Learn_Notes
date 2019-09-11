using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FluntAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                //ctx.Database.Log = (sql) => { Console.WriteLine("****************log**************" + sql); };
                //Person p = new Person();
                //p.Name = "人儿";
                //p.Age = 11;
                //ctx.Persons.Add(p);
                //Console.WriteLine(p.Id);
                //ctx.SaveChanges();
                //Console.WriteLine(p.Id);
                //Console.WriteLine("增加成功");
                //Dog d = new Dog();
                //d.Name = "小狗";
                //ctx.Dogs.Add(d);//等价于ctx.Set<Dog>().Add(d);
                //Console.WriteLine(d.Id);
                //ctx.SaveChanges();
                //Console.WriteLine(d.Id);//***savechange后会自动给对象中自动增长的主键赋值***
                //Console.WriteLine("增加成功");

                ////EF直接执行SQL数据库数据更改
                //ctx.Database.ExecuteSqlCommand("insert into T_Persons(Name,Age) values({0},{1})","Tom",123);

                ////EF直接执行SQL查询
                //var result = ctx.Database.SqlQuery<groupByAge>("select age,count(*) cnt from [T_Persons] group by age order by age");
                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.age+","+item.cnt);
                //}

                ////EF执行ExecuteScalar
                //int r = ctx.Database.SqlQuery<int>("select count(*) from T_Persons").SingleOrDefault();

                //Console.WriteLine($"总人数：{r}人");


                ////EF也不是所有的语法都支持
                ////Person pp = ctx.Persons.Where(a=>Convert.ToString(a.Id)=="3").SingleOrDefault();

                ////EF状态管理
                //Person p1 = new Person() { Age=10, Name="aaaaaaa" };
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Entry(p1).State = System.Data.Entity.EntityState.Added;
                ////等价于ctx.Persons.Add(p1);
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.SaveChanges();
                //Console.WriteLine(ctx.Entry(p1).State);


                //Person p1 = new Person() { Id = 1 };
                //ctx.Persons.Attach(p1);
                //Console.WriteLine(ctx.Entry(p1).State);
                //p1.Age++;
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.SaveChanges();
                ////***其实p1的属性值是和数据库中记录的并不相同，只是根据id将age更新到了数据库，其他都没改变
                //Console.WriteLine(ctx.Entry(p1).State);

                //将首条记录删除并添加到最后一条
                //Person p1 = ctx.Persons.First();
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Entry(p1).State = System.Data.Entity.EntityState.Deleted;
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.SaveChanges();
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Entry(p1).State = System.Data.Entity.EntityState.Added;
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.SaveChanges();
                //Console.WriteLine(ctx.Entry(p1).State);

                ////另一种修改记录的方法
                //Person p1 = new Person() {  Id=3,Name="ccc" };
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Persons.Attach(p1);
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Entry(p1).Property(a => a.Name).IsModified = true;
                //Console.WriteLine(ctx.Entry(p1).State);
                //ctx.SaveChanges();
                //Console.WriteLine(ctx.Entry(p1).State);

                ////以下方式并不会删除所有Age=11的记录
                //Person p1 = new Person() { Age = 11 };
                //ctx.Persons.Attach(p1);
                //ctx.Entry(p1).State = System.Data.Entity.EntityState.Deleted;
                //ctx.SaveChanges();

                //var p1 = ctx.Persons.Where(p => p.Age == 11).FirstOrDefault();
                //Console.WriteLine(ctx.Entry(p1).State);

                //var p2 = ctx.Persons.AsNoTracking().Where(p => p.Age == 11).FirstOrDefault();
                //Console.WriteLine(ctx.Entry(p2).State);
                //p2.Age++;
                //Console.WriteLine(ctx.Entry(p2).State);

                var p3 = ctx.Persons.AsNoTracking().First();
                Console.WriteLine(ctx.Entry(p3).State);          
                ctx.Entry(p3).State = System.Data.Entity.EntityState.Unchanged;
                p3.Name = "rrr";
                Console.WriteLine("*"+ctx.Entry(p3).State);
                ctx.SaveChanges();
                Console.WriteLine("**"+ctx.Entry(p3).State);




                Console.ReadLine();

            }

            

        }

        class groupByAge
        {
            public int age { get; set; }
            public int cnt { get; set; }
        }
    }
}
