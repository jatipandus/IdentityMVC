using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {

        public class MyModel
        {
            public string JavascriptToRun { get; set; }
        }

        public ActionResult Index()
        {
           return View();
        }

        public ActionResult About(MyModel model)
        {

            if (Session["Id"] != null)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {
                //return Content("<script language='javascript' type='text/javascript'>alert('You Must Login'); window.location.href('Login','Account')</script>");
                return Content("<script language='javascript' type='text/javascript'>alert('You must login...');window.location.href ='/Account/Login';</script>");

            }
        }

        public ActionResult Contact(MyModel model)
        {
            if (Session["Id"] != null)
            {
                
                ViewBag.Message = "Your Contact description page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You must login...');window.location.href ='/Account/Login';</script>");
                //return RedirectToAction("Login", "Account");
            }
        }
    }
}