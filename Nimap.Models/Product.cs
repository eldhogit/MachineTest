﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap.Models
{
    public class Product 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public long CategoryId { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; }
        //public Category category { get; set; }

    }
}
