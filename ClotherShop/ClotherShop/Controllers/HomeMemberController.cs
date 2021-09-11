using ClotherShop.DBase;
using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherShop.Controllers
{
    public class HomeMemberController : Controller
    {
        // GET: HomeMember
        public ActionResult Index(List<ProductModel> model)
        {
            dynamic mymodel = new ExpandoObject();
            if (Session["Member"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model = new List<ProductModel>();
                string sql = "select*from [Product]";
                model = DataBase.Singleton.Product(sql);
                string sql1 = "SELECT COUNT(*) FROM Cart";
                int count =DataBase.Singleton.Count(sql1);
                mymodel.count = count;
                mymodel.model = model;
                
                
            }
           
            return View(mymodel);

        }
        public int AddToCart(int Id)
        {
            List<CartModel> model = new List<CartModel>();
            string sql_cart = "select*from [Cart]";
            model = DataBase.Singleton.listCart(sql_cart);
            Boolean result = false;
            int id_product = Id;
            int id_member = ((MemberModel)Session["Member"]).Id;
            int quantity = 1;
            CartModel cart = new CartModel(quantity, id_product, id_member);
            int count = model.Count();
            foreach (CartModel item in model)
            {
                if (item.ID_Product == id_product)
                {
                    quantity = item.Quantity + 1;
                    string sql = "Update [Cart] Set Quantity='" + quantity + "' where ID_Product='" + id_product + "'";
                    result = DataBase.Singleton.Cart(sql);
                    
                }
            }

            if (!result)
            {

                string sql = "insert into [Cart](ID_Product,ID_Member,Quantity) values('" + cart.ID_Product + "','" + cart.ID_Member + "','" + cart.Quantity + "')";
                result = DataBase.Singleton.Cart(sql);
                count++;
            }


            return count;
            
        }
    }
}