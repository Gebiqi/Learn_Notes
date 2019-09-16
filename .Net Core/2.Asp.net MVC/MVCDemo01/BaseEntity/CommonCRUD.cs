using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntity
{
    public class CommonCRUD<T> where T : BaseEntity
    {
        private MyDBContext ctx;
        public CommonCRUD(MyDBContext ctx)
        {
            this.ctx = ctx;
        }
        public void MarkDeleted(long Id)
        {
            T item = ctx.Set<T>().Where(t => t.Id == Id).SingleOrDefault();
            if (item==null)
            {
                throw new ArgumentException($"找不到Id={Id}的数据");
            }
            item.IsDeleted = true;
            item.DeleteTime = DateTime.Now;
            ctx.SaveChanges();
        }
        public T GetById(long Id)
        {
            T item = ctx.Set<T>().Where(t => t.Id == Id).SingleOrDefault();
            return item;
        }
        public IQueryable<T> GetAll(int start,int cnt)
        {
            return ctx.Set<T>()
                .Where(t=>t.IsDeleted==false)
                .OrderBy(t => t.CreateTime)
                .Skip(start)
                .Take(cnt);
        }
        public long GetTotalCount()
        {
            return ctx.Set<T>().Where(t=>t.IsDeleted==false).Count();
        }
    }
}
