using ClotherShop.DBase;
using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index(Dictionary<CartModel,ProductModel> model)
        {
             model = new Dictionary<CartModel, ProductModel>();
            MemberModel m = (MemberModel)Session["Member"];
            string sql = "select*from [Cart],[Product] Where [Cart].ID_Product=[Product].ID AND Cart.ID_Member='"+m.Id+"'";
            model = DataBase.Singleton.CartDetail(sql);
            return View(model);
        }
        public bool RemoveCart(int id)
        {
            string sql = "delete [Cart] Where ID='" + id + "'";
            Boolean result = DataBase.Singleton.Cart(sql);
            return true;
        }
        public void StatusCart(bool check,int id)
        {
            string sql = "";
            if (check)
            {
                sql = "update [Cart] set Status='" + 1 + "' Where ID='" + id + "'";
            }
            else
            {
                sql = "update [Cart] set Status='" + 0 + "' Where ID='" + id + "'";
            }
            DataBase.Singleton.Cart(sql);
        }
        public void StatusAllCart(bool check)
        {
            string sql = "";
            if (check)
            {
                sql = "update [Cart] set Status='" + 1 + "'";
            }
            else
            {
                sql = "update [Cart] set Status='" + 0 + "'";
            }
            DataBase.Singleton.Cart(sql);
        }
        public void TangQuantity(int id)
        {
            string sql = "update [Cart] set Quantity=Quantity+1 Where ID='" + id + "'";
            DataBase.Singleton.Cart(sql);
        }
        public void GiamQuantity(int id)
        {
            string sql = "update [Cart] set Quantity=Quantity-1 Where ID='" + id + "'";
            DataBase.Singleton.Cart(sql);
        }
    }
}