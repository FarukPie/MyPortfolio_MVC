using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class MessageController : Controller
    {
       myProfileEntities db=new myProfileEntities();
        public ActionResult Index()
        {
            var value=db.TblMessages.Where(m=>m.IsRead==false).ToList();
            return View(value);
        }
        public PartialViewResult MessageDetail(int id)
        {
            var value = db.TblMessages.Find(id);    
            value.IsRead = true;
            db.SaveChanges();
            return PartialView();
        }
    }
}