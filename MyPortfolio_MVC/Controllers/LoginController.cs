using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        myProfileEntities db = new myProfileEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            var value = db.TblAdmin.FirstOrDefault(x => x.Email == model.Email & x.Password == model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "E-mail ya da şifre hatalı");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(value.Email, false);
            Session["Email"] = value.Email;
            return RedirectToAction("Index", "Categoy");

        }

    }
}