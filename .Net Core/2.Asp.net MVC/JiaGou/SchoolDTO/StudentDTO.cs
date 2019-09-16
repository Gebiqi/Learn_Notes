﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDTO
{
    /// <summary>
    /// 用户传送Student数据
    /// </summary>
    public class StudentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long MinZuId { get; set; }
        public string MinZuName { get; set; }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
    }
}