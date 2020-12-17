using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class Account
    {
        [Display(Name = "User name")]
        [Required(ErrorMessage = "Điền tên đang nhập.")]
        public string user { get; set; }
        [Display(Name = "PassWord")]
        [Required(ErrorMessage = "Điền mật khẩu")]
        [MinLength(8, ErrorMessage ="Mật khẩu ít nhất có 8 kí tự.")]
        [DataType(DataType.Password)]
        public string pass { get; set; }
        [Display(Name = "Nhap lai Password")]
        [Required(ErrorMessage = "Nhập lại mật khẩu")]
        [Compare("pass")]
        [DataType(DataType.Password)]
        public string re_pass { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên")]
        public string Ten { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nhập địa chỉ Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Dia chi")]
        [Required(ErrorMessage = "Nhập địa chỉ giao hàng")]
        public string dia_chi { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Nhập số điện thoại liên hệ")]
        [DataType(DataType.PhoneNumber)]
        public string sdt { get; set; }

    }
}
