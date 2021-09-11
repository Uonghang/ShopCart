using ClotherShop.DBase;
using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherShop.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Session["Member"] = null;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MemberModel model)
        {
            MemberModel m = new MemberModel();
            string sql = "select * from [Member] Where Email='" + model.Email + "' AND Password='" + model.Password + "'";
            m = DataBase.Singleton.SelectLogin(sql);

            if (m.Id != 0 && ModelState.IsValid)
            {
                Session["Member"] = m;
                return RedirectToAction("Index", "HomeMember");

            }
            else
            {
                ModelState.AddModelError("", "Thong tin dang nhap sai");
            }
            return View(model);
        }
    }
}