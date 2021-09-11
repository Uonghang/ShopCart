using ClotherShop.DBase;
using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherShop.Controllers
{
    public class DonhangController : Controller
    {
        // GET: Donhang
        public ActionResult Index(Dictionary<CartModel,ProductModel> model)
        {
            string sql = "select*from [Cart],Product where [Cart].Status='" + 1 + "' " +
                "AND [Cart].ID_Product=[Product].ID  ";
            model = DataBase.Singleton.CartDetail(sql);
            return View(model);
        }
        public void Thanhtoan()
        {
            List<CartModel> model = new List<CartModel>();
            string sql = "select*from [Cart] Product";
            model = DataBase.Singleton.listOder(sql);
            foreach(var item in model)
            {
                if (item.Status == 1)
                {
                    string sql1 = "insert into [Oder](ID_Product,ID_Member,Quantity) " +
                        "Values('"+item.ID_Product+ "','" + item.ID_Member + "','" 
                        + item.Quantity + "')";
                    DataBase.Singleton.Cart(sql1);
                    string remove = "delete [Cart] where ID='" + item.Id + "'";
                    DataBase.Singleton.Cart(remove);
                }
            }
            
        }
    }
}