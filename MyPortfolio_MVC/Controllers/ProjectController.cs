using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyPortfolio_MVC.Controllers
{
    public class ProjectController : Controller
    {
       myProfileEntities db=new myProfileEntities();
        private void CategoryDropDown()
        {

            var categorylist = db.TblCategories.ToList();
            List<SelectListItem> categories = (from x in categorylist
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Categoryid.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }
        public ActionResult Index()
        {
            var projects=db.TblProjects.ToList();
            return View(projects);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
          CategoryDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProjects model)
        {
        CategoryDropDown(); 

            if (!ModelState.IsValid)
            {
                    return View(model);
            }
            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value=db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {

            var value=db.TblProjects.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProjects model)
        {
         

            CategoryDropDown();
            var value = db.TblProjects.Find(model.Projectid);
            value.Name = model.Name;
            value.Description = model.Description;
            value.ImageUrl = model.ImageUrl;
            value.Categoryid = model.Categoryid;
            value.GitHubUrl = model.GitHubUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}