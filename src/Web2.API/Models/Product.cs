﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static List<Product> products = new List<Product>();
    }
}