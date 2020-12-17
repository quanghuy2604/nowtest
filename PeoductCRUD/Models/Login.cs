using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class Login
    {
        public class LoginViewModel
        {
            [Display(Name = "Mã khách hàng")]
            [MaxLength(50)]
            public string MaKH { get; set; }
            [Display(Name = "Mật khẩu")]
            [MaxLength(50)]
            [DataType(DataType.Password)]
            public string MatKhau { get; set; }
        }
    }
}
