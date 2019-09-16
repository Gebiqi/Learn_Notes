using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntity
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? DeleteTime { get; set; }
    }
}
