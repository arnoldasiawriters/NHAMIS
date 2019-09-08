using System;
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
            return View(userDetails);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");

            UserDetailsViewModel model = new UserDetailsViewModel()
            {
               
            };

            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDetailsViewModel model)
        {
            model.RegisterViewModel.Email = model.UserDetails.EmailAddress;
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser();
                user.UserName = model.RegisterViewModel.UserName;
                user.Email = model.UserDetails.EmailAddress;
                UserManager.Create(user, model.RegisterViewModel.Password);
                var rolename = roleManager.FindById(model.RoleId);
                UserManager.AddToRole(user.Id, rolename.Name);

                model.UserDetails.NominatingBodyId = model.NominatingBodyId;
                db.UserDetails.Add(model.UserDetails);
                db.SaveChanges();
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
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name", userDetails.NominatingBodyId);
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Surname,OtherNames,Designation,PostalAddress,PostalCode,Town,EmailAddress,MobileNo,OtherNo,UserId,UserStatus,NominatingBodyId,CreateBy,CreateDate,ModifyBy,ModifyDate")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name", userDetails.NominatingBodyId);
            return View(userDetails);
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
