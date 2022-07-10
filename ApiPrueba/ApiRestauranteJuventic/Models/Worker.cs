﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Worker
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int addressId { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public int companyId { get; set; }
    }
}
