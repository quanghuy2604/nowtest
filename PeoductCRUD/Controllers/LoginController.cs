using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static PeoductCRUD.Models.Login;

namespace PeoductCRUD.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //Kiểm tra xem mã người dùng có hợp lệ không?
            if (model.MaKH.Length > 5 && model.MatKhau.Length > 5)
            {
                LoginViewModel kh = new LoginViewModel
                {
                    MaKH = model.MaKH,
                    MatKhau = model.MatKhau

                };
                HttpContext.Session.SetString("KhachHang", model.MaKH );
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("KhachHang");
            return RedirectToAction("Index", "Home");
        }
    }
}
