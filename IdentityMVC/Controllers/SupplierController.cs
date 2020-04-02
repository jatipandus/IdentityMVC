using IdentityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        connect conn = new connect();
        //Iden conn = new IdentityMVC();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(conn.Suppliers.ToList());
        }
        
        public ActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }

        // POST: Supplier/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
