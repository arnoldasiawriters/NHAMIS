﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NHAMIS;
using NHAMIS.APP.Models;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    [SessionExpire]
    public class UserDetailsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: UserDetails
        public ActionResult Index()
        {
            var userDetails = db.UserDetails.Include(u => u.NominatingBody);
            return View(userDetails.ToList());
        }

        // GET: UserDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.PostalCodeId = new SelectList(db.PostalCodes, "Id", "Town");
            return View(userDetails);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.PostalCodeId = new SelectList(db.PostalCodes, "Id", "Town");
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDetailsViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            model.RegisterViewModel.Email = model.UserDetails.EmailAddress;
            var userInDb = UserManager.FindByName(model.RegisterViewModel.UserName);
            if (ModelState.IsValid && userInDb == null)
            {
                userInDb = new ApplicationUser();
                userInDb.UserName = model.RegisterViewModel.UserName;
                userInDb.Email = model.UserDetails.EmailAddress;
                UserManager.Create(userInDb, model.RegisterViewModel.Password);

                var rolename = roleManager.FindById(model.RoleId);

                var userInRole = UserManager.IsInRole(userInDb.Id, rolename.Name);
                if (!userInRole)
                {
                    UserManager.AddToRole(userInDb.Id, rolename.Name);
                }

                model.UserDetails.NominatingBodyId = model.NominatingBodyId;
                model.UserDetails.PostalCodeId = model.PostalCodeId;
                model.UserDetails.UserId = userInDb.Id;
                db.UserDetails.Add(model.UserDetails);
                db.SaveChanges();
                TempData["UserMessage"] = new MessageVM() { CssClassName = "alert-success", Title = "Success!", Message = "User added successfully." };
                return RedirectToAction("Index");
            }
            else
            {
                var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToList();
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name", model.UserDetails.NominatingBodyId);
            ViewBag.PostalCodeId = new SelectList(db.PostalCodes, "Id", "Town");
            TempData["UserMessage"] = new MessageVM() { CssClassName = "alert-error", Title = "Error!", Message = "UserName or Email already exists in the database." };
            return View(model);
        }

        // GET: UserDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }

            var user = db.Users.Where(u => u.Id == userDetails.UserId).FirstOrDefault();
            
            UserDetailsViewModel vm = new UserDetailsViewModel();
            vm.RoleId = db.UserRoles.Where(u=>u.UserId == userDetails.UserId).FirstOrDefault().RoleId;
            vm.PostalCodeId = userDetails.PostalCodeId;
            vm.NominatingBodyId = userDetails.NominatingBodyId;
            vm.UserDetails = userDetails;
            vm.RegisterViewModel = new RegisterViewModel();
            vm.RegisterViewModel.UserName = user.UserName;
            vm.RegisterViewModel.Email = user.Email;
            vm.RegisterViewModel.PFNumber = userDetails.PFNumber;

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", vm.RoleId);
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name", userDetails.NominatingBodyId);
            ViewBag.PostalCodeId = new SelectList(db.PostalCodes, "Id", "Town", userDetails.PostalCodeId);
            return View(vm);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDetailsViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(model.UserDetails.UserId);
            if (ModelState.IsValid || user != null)
            {
                if(model.RegisterViewModel.ResetPassword )
                {
                    UserManager.RemovePassword(user.Id);
                    UserManager.AddPassword(user.Id, "User@123");
                }

                var curRole = db.UserRoles.Where(n => n.UserId == user.Id).FirstOrDefault();
                var rolename = roleManager.FindById(model.RoleId);
                

                if (curRole.RoleId != model.RoleId)
                {
                    UserManager.RemoveFromRole(user.Id, curRole.RoleId);
                }

                var userInRole = UserManager.IsInRole(user.Id, rolename.Name);
                if (!userInRole)
                {
                    UserManager.AddToRole(user.Id, rolename.Name);
                }
                model.UserDetails.NominatingBodyId = model.NominatingBodyId;
                model.UserDetails.PostalCodeId = model.PostalCodeId;
                model.UserDetails.PFNumber = model.RegisterViewModel.PFNumber;
                db.Entry(model.UserDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            UserDetails userDetails = db.UserDetails.Find(user.Id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }

            UserDetailsViewModel vm = new UserDetailsViewModel();
            vm.RoleId = db.UserRoles.Where(u => u.UserId == userDetails.UserId).FirstOrDefault().RoleId;
            vm.PostalCodeId = userDetails.PostalCodeId;
            vm.NominatingBodyId = userDetails.NominatingBodyId;
            vm.UserDetails = userDetails;
            vm.RegisterViewModel = new RegisterViewModel();
            vm.RegisterViewModel.UserName = user.UserName;
            vm.RegisterViewModel.Email = user.Email;
            vm.RegisterViewModel.PFNumber = userDetails.PFNumber;

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", vm.RoleId);
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name", userDetails.NominatingBodyId);
            ViewBag.PostalCodeId = new SelectList(db.PostalCodes, "Id", "Town", userDetails.PostalCodeId);
            return View(vm);
        }

        // GET: UserDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetails userDetails = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
