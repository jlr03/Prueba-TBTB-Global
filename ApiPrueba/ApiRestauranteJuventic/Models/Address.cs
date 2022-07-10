using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Models
{
    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string suit { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string lat { get; set; }
        public string longi { get; set; }
    }
}
