using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class EducationController : Controller
    {
       myProfileEntities db=new myProfileEntities();
        public ActionResult Index()
        {
            var education = db.TblEducations.ToList();
            return View(education);
        }
        public ActionResult DeleteEducation(int id) {

            var value = db.TblEducations.Find(id);
            db.TblEducations.Remove(value);
            db.SaveChanges();
           return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(TblEducations model)
        {
            db.TblEducations.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = db.TblEducations.Find(id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducations model)
        {
                var value=db.TblEducations.Find(model.Educationid);
                value.SchoolName = model.SchoolName;
                value.Description=model.Description;
                value.StartDate = model.StartDate;  
                value.EndDate = model.EndDate;
                value.Department=model.Department;
                value.Degree = model.Degree;
                db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}