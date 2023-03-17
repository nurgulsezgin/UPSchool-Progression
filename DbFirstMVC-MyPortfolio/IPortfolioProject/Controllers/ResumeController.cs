using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IPortfolioProject.Models;

namespace IPortfolioProject.Controllers
{
    public class ResumeController : Controller
    {
        DbPortfolioEntities db = new DbPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.v1 = "Resume";
            return View();
        }
        public PartialViewResult EducationPartial()
        {
            ViewBag.v1 = "Education";
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }
        public PartialViewResult ExperiencePartial()
        {
            ViewBag.v1 = "Experience";
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }
        public PartialViewResult SkillsPartial()
        {
            ViewBag.v1 = "My skills";
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
    }
}
