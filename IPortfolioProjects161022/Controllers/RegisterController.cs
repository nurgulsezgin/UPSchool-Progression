using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class RegisterController : Controller
    {

        string _control = "";

        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Yeni Üyelik Formu";
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            if (!ModelState.IsValid)
            {
                p.MemberPassword = HashSHA256.EncryptPassword(p.MemberPassword);
                db.TblMembers.Add(p);
                db.SaveChanges();
                // System.Threading.Thread.Sleep(3000);

                //return RedirectToAction("index", "Login");
            }

            //RabbitMQ

            //wait js operation

            // return View();
            return JavaScript("<script>nurguljs()</script>");

        }

        //[HttpPost]
        //public string FirstAjax()
        //{
        //    JsonResult json = Json("chamara", JsonRequestBehavior.AllowGet);
        //    string result = json.Data.ToString();
        //    _control = result;
        //    return result;
        //}

        //[HttpGet]
        //public ActionResult Index2()
        //{
        //    @ViewBag.Title = "Nurgül";
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index2(TblMember p)
        //{
        //    if (Request.Form["submit"] != null)
        //    {
        //        return RedirectToAction("Index", "Register");

        //    }
        //    if (!string.IsNullOrEmpty(submit))
        //    {
        //        return RedirectToAction("Index", "Register");
        //    }
        //    return JavaScript("alert('TempData[\"Message\"]')");
        //}
    }

}
