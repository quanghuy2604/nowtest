using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PeoductCRUD.Models;
using PayPal;
using Microsoft.AspNetCore.Http;

namespace PeoductCRUD.Controllers
{
    
    public class CartController : Controller
    {
        private readonly string _clientId;
        private readonly string _secretKey;

        public double Tygia = 23321;
        public CartController(IConfiguration config)
        {
            _clientId = config["PaypalSetting:ClientId"];
            _secretKey = config["PaypalSetting:SecrectKey"];
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Cart()
        {
            var user = HttpContext.Session.GetString("KhachHang");
            CartContext contexts = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.CartContext)) as CartContext;

            return View(contexts.GetCarts(user));
        }
        public IActionResult XoaCart(string id, string name)
        {
            CartContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.CartContext)) as CartContext;
            context.XoaCart(id, name);
            return RedirectToAction("Cart");


        }

        public IActionResult Tangsl(string id, string name, string sl)
        {
            CartContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.CartContext)) as CartContext;
            context.Tangsl(id, name, sl);
            return RedirectToAction("Cart");

        }
        public IActionResult Giamsl(string id, string name, string sl)
        {
            CartContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.CartContext)) as CartContext;
            context.Giamsl(id, name,sl);
            return RedirectToAction("Cart");

        }
        

    }
}
