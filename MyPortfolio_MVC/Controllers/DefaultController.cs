﻿using Microsoft.Ajax.Utilities;
using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
      myProfileEntities db=new myProfileEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult DefaultBanner()
        {
            var values=db.TblBanner.Where(x=>x.IsShown==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExpertise()
        {
            var value=db.TblExpertises.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultExperience()
        {
            var value= db.TblExperiences.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultEducation() { 
            var value =db.TblEducations.ToList();   
            return PartialView(value);
        
        }

        public PartialViewResult DefaultProject()
        {

            var value=db.TblProjects.ToList();
            return PartialView(value);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessages model)
        {
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult DefaultAbout()
        {
            var values=db.TblAbouts.ToList();
            return PartialView(values);
        }
    }
}