using MVC_AND_EF;
using SchoolDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class MinZuService
    {
        public IEnumerable<MinZuDTO> GetAll()
        {
            List<MinZuDTO> mzDTO = new List<MinZuDTO>();
            using (MyDBContext ctx = new MyDBContext())
            {
                foreach (var item in ctx.MinZus)
                {
                    mzDTO.Add(
                    new MinZuDTO()
                    {
                        Name = item.Name,
                        Id = item.Id
                    }
                    );
                }
            }
            return mzDTO;
        }
    }
}
