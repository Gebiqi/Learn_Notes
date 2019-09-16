using MVC_AND_EF;
using SchoolDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class StudentService
    {
        /// <summary>
        /// 新增学员信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="minzuId"></param>
        /// <param name="classId"></param>
        public void AddNew(string name, int age, long minzuId, long classId)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                Student stu = new Student()
                {
                    Name = name
                    ,
                    Age = age
                    ,
                    MinZu = ctx.MinZus.Where(mz => mz.Id == minzuId).FirstOrDefault()
                    ,
                    Class = ctx.Classes.Where(c => c.Id == classId).FirstOrDefault()
                };
                ctx.Students.Add(stu);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                //Student stu =  ctx.Students.SingleOrDefault(s => s.Id == id);
                //if (stu!=null)
                //{
                //    ctx.Students.Remove(stu);
                //    ctx.SaveChanges();
                //}
                //else
                //{
                //    throw new ArgumentException($"没有Id={id}的数据");
                //}
                Student stu = new Student();
                stu.Id = id;
                ctx.Entry(stu).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 通过学生Id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentDTO GetStudentById(long id)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                Student stu = ctx.Students.AsNoTracking().Include(s => s.MinZu).Include(s => s.Class).SingleOrDefault(s => s.Id == id);
                if (stu != null)
                {
                    return ToDTO(stu);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 通过班级Id查询所有学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<StudentDTO> GetStudentByClassId(long classId)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                var stus = ctx.Students.AsNoTracking().Include(s=>s.MinZu).Include(s=>s.Class).Where(s => s.Class.Id == classId);
                List<StudentDTO> stuDTOs = new List<StudentDTO>();
                foreach (Student item in stus)
                {
                    stuDTOs.Add(ToDTO(item));
                }
                return stuDTOs;
            }
        }

        /// <summary>
        /// 将Student对象转换为数据传输对象StudentDTO
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private StudentDTO ToDTO(Student s)
        {
            StudentDTO stuDTO = new StudentDTO()
            {
                Age = s.Age,
                ClassId = s.Class.Id,
                ClassName = s.Class.Name,
                Id = s.Id,
                MinZuId = s.MinZu.Id,
                MinZuName = s.MinZu.Name,
                Name = s.Name
            };
            return stuDTO;
        }


    }
}
