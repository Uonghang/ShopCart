using ClotherShop.DBase;
using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(List<ProductModel> model)
        {
            Session["Member"] = null;
            model = new List<ProductModel>();
            string sql = "select*from [Product]";
            model = DataBase.Singleton.Product(sql);
            ViewBag.ProductModel = new ProductModel();

            return View(model);
           
        }
      

        
    }
}