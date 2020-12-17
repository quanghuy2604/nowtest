using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        [Display(Name ="Ten san pham: ")]
        [MinLength(5, ErrorMessage = "Tên ít nhất 5 ký tự !")]
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Total => UnitPrice * Quantity;

    }
}
