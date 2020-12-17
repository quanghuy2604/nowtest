using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.ClientNotification;
using PeoductCRUD.Models;

namespace PeoductCRUD.Controllers
{
    public class ProductController : Controller
    {
        private static List<Products> Products = new List<Products>();

        public IActionResult Index()
        {
            return View(Products);
        }
        public IActionResult Create()
        {
            return View();
        }
    [HttpPost]
        public IActionResult Create(Products product)
        {
            var _product = Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (_product == null)
            {
                //da ton tai
                Products.Add(product);
            }
                //them vao list
             
            //chi huong den action index de show danh sach
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductID == id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public IActionResult Edit(Products product)
        {
            var _product = Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.UnitPrice = product.UnitPrice;
                _product.Quantity = product.Quantity;
                
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var _product = Products.FirstOrDefault(p => p.ProductID == id);
            if (_product != null)
            {
                

                Products.Remove(_product);
            }

            return RedirectToAction("Index");
        }

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            TempData["notification"] = msg;
        }
    }
}
