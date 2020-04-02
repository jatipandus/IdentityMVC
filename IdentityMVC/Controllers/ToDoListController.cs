using IdentityMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //[Authorize]
        public ActionResult Index()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            
            //if (currentUser != null)
            //{
            //    var todoItems = db.ToDoListItems.Where(k => k.ApplicationUserID == currentUser.Id);
            //    if (todoItems != null)
            //    {
            //        ViewBag.ToDoListItems = todoItems;                    
            //    }
            //}
            //else
            //{
            //    return Redirect("/");
            //}
            var currentUser = db.Users.Where(k => k.Email == User.Identity.Name).FirstOrDefault();

            if (currentUser != null)
            {
                string currentUsersId = User.Identity.GetUserId();
                ApplicationUser currentusers = db.Users.FirstOrDefault(x => x.Email == currentUsersId);
                return View(db.ToDoListItems.ToList().Where(x => x.ApplicationUserID == currentUsersId));
            }
            else
            {
                //return Content("<script language='javascript' type='text/javascript'>alert('You Must Login'); window.location.href('Login','Account')</script>");
                return Content("<script language='javascript' type='text/javascript'>alert('You must login...');window.location.href ='/Account/Login';</script>");
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] ToDoListItem todolistitem)
        {
            try
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                todolistitem.ApplicationUserID = currentUserId;
                db.ToDoListItems.Add(todolistitem);
                db.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {

            return View(db.ToDoListItems.Where(x => x.ID == id).FirstOrDefault());

        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ToDoListItem todolistitem)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(todolistitem).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}