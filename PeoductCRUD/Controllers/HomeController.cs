using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeoductCRUD.Models;

namespace PeoductCRUD.Controllers
{

    public class HomeController : Controller
    {
        private Account account = new Account();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(Account account)
        {
            
            LoginContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.LoginContext)) as LoginContext;
            Account acc = context.Login(account.user, account.pass);
            if (acc.Ten != null)
            {
                HttpContext.Session.SetString("KhachHang", acc.Ten);
            }
            else
            {
                TempData["AlertType"] = "alert-danger";
                TempData["AlertMessage"] = "Sai mat khau hoac ten dang nhap";
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("Index", "Home");

        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Account account)
        {
            AcountContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.AcountContext)) as AcountContext;
             if (context.SignUp(account))
            return RedirectToAction("Login", "Home");
             else
                return RedirectToAction("SignUp", "Home");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("KhachHang");
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
