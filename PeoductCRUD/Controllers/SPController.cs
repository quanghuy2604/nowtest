using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PeoductCRUD.Models;

namespace PeoductCRUD.Controllers
{
    public class SPController : Controller
    {
        
        public IActionResult Index()
        {
            SPContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.SPContext)) as SPContext;

            return View(context.GetAllAlbums());
        }

        public IActionResult SinglePage(string id)
        {
            
            SPContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.SPContext)) as SPContext;

            return View(context.GetSinhgleSP(id));
        }
        public IActionResult AddtoCart(string id, string sl, string name)
        {
            SPContext context = HttpContext.RequestServices.GetService(typeof(PeoductCRUD.Models.SPContext)) as SPContext;
            context.AddtoCart(id,sl,name);
            return RedirectToAction("Index");

        }
        
    }
}
