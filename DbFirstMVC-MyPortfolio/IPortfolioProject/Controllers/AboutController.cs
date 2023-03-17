using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IPortfolioProject.Models;

namespace IPortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        DbPortfolioEntities db=new DbPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        //[ChildActionOnly]
        public PartialViewResult AboutPartial()
        {
            ViewBag.v1 = "About Me";
            var value = db.TblAbout.Find(1);
            return PartialView(value);
        }
        public PartialViewResult ServicesPartial()
        {
            ViewBag.v1 = "What i'm doing";
            var values = db.TblServices.ToList();
            return PartialView(values);
        }
        public PartialViewResult Testimonials()
        {
            ViewBag.v1 = "Testimonials";
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult TestimonialsModal()
        {
            return PartialView();
        }
        public PartialViewResult Clients()
        {
            ViewBag.v1 = "Clients";
            var values = db.TblClients.ToList();
            return PartialView(values);
        }
    }
}
