using ClotherShop.DBase;
using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductDetail(int id)
        {
            ProductModel model = new ProductModel();
            string sql = "select*from [Product] where ID='" + id + "'";
            model = DataBase.Singleton.ProductDetail(sql);
            return View(model);
        }
        public int AddToCart(int Id,int quantity)
        {
            List<CartModel> model = new List<CartModel>();
            string sql_cart = "select*from [Cart]";
            model = DataBase.Singleton.listCart(sql_cart);
            Boolean result = false;
            int id_product = Id;
            int id_member = ((MemberModel)Session["Member"]).Id;
            CartModel cart = new CartModel(quantity, id_product, id_member);
            int count = model.Count();
            foreach (CartModel item in model)
            {
                if (item.ID_Product == id_product)
                {
                    int Quantity = item.Quantity + quantity;
                    string sql = "Update [Cart] Set Quantity='" + Quantity + "' where ID_Product='" + id_product + "'";
                    result = DataBase.Singleton.Cart(sql);

                }
            }

            if (!result)
            {

                string sql = "insert into [Cart](ID_Product,ID_Member,Quantity) values('" + cart.ID_Product + "','" + cart.ID_Member + "','" + quantity + "')";
                result = DataBase.Singleton.Cart(sql);
                count++;
            }


            return count;
        }

    }
}