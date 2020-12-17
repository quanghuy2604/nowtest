using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
   
    public class Cart
    {
        public string id { get; set; }
        public string ten { get; set; }
        public int sl { get; set; }
        public string img { get; set; }

        public string id_user { get; set; }
        public int gia { get; set; }
        public double total => gia * sl;
    }
}
