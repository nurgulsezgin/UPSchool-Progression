using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Services.Description;
using IPortfolioProject.Models;
using NLog.Targets;
using NLog;
using System.Data.Entity.Core.Metadata.Edm;
using System.Xml.Linq;

namespace IPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        DbPortfolioEntities db = new DbPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.v1 = "Contact";
            ViewBag.v2 = "Contact Form";
            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Index(TblMessage m)
        {
            try
            {
                m.MessageDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.TblMessage.Add(m);
                    db.SaveChanges();
                    SendEmail(m.EmailAdress, m.FullName, m.MessageContent);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public void SendEmail(string senderMail, string senderName, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.outlook.com",
                        Port = 587,
                        EnableSsl = true,
                        Credentials = new NetworkCredential("devrim.karaca@windowslive.com", "liketry34")//Your mail , password
                    };
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("devrim.karaca@windowslive.com", "Devrim Karaca");//Your mail , your fullname
                    mail.To.Add("nurgul_sezgin@hotmail.com");
                    mail.Subject = "IPortfolioProject";
                    mail.IsBodyHtml = true;
                    mail.Body = $@"<h1> Sayın, Nurgül Sezgin </h1> <br />
                                    <h2>{DateTime.Now.ToString()}  Tarihinde Iportfolio isimli siteden gelen mesajınız bulunmaktadır.<h2/>
                                    <br/>
                                    <p>Gönderen : {senderName}<p/>
                                    <br/>
                                    <p>Gönderenin mail adresi : {senderMail}<p/>
                                    <br/>
                                    <p>Mesajınız : {message}</p>";
                    smtp.Send(mail);


                    Logger logger = LogManager.GetLogger("Example");
                    ViewBag.Alert = ("Your e-mail has been sent successfully.");
                    ViewData["AlertMessage"] = string.Format("Hello {0}.\\nCurrent Date and Time: {1}", senderName, DateTime.Now.ToString());
                    logger.Debug("log message");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
            }
        }

    }
}
