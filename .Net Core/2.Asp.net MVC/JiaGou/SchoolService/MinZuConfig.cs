﻿using MVC_AND_EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    class MinZuConfig:EntityTypeConfiguration<MinZu>
    {
        public MinZuConfig()
        {
            ToTable("T_MinZus");
        }
    }
}
