using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NHAMIS;
using NHAMIS.APP.Models;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    [SessionExpire]
    public class HonorRolesController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: HonorRoles
        public ActionResult Index()
        {
            var honorRoles = db.HonorRoles.Include(h => h.Medal).Include(h => h.Salutation);
            return View(honorRoles.ToList());
        }

        // GET: HonorRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HonorRole honorRole = db.HonorRoles.Find(id);
            if (honorRole == null)
            {
                return HttpNotFound();
            }
            return View(honorRole);
        }

        // GET: HonorRoles/Create
        public ActionResult Create()
        {
            ViewBag.MedalId = new SelectList(db.Medals, "Id", "Name");
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name");
            return View();
        }

        // POST: HonorRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SerialNo,IdNumber,ConfirementDate,Nationality,SalutationId,MedalId,CreateBy,CreateDate,ModifyBy,ModifyDate")] HonorRole honorRole)
        {
            if (ModelState.IsValid)
            {
                db.HonorRoles.Add(honorRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedalId = new SelectList(db.Medals, "Id", "Name", honorRole.MedalId);
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name", honorRole.SalutationId);
            return View(honorRole);
        }

        // GET: HonorRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HonorRole honorRole = db.HonorRoles.Find(id);
            if (honorRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedalId = new SelectList(db.Medals, "Id", "Name", honorRole.MedalId);
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name", honorRole.SalutationId);
            return View(honorRole);
        }

        // POST: HonorRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SerialNo,IdNumber,ConfirementDate,Nationality,SalutationId,MedalId,CreateBy,CreateDate,ModifyBy,ModifyDate")] HonorRole honorRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honorRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedalId = new SelectList(db.Medals, "Id", "Name", honorRole.MedalId);
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name", honorRole.SalutationId);
            return View(honorRole);
        }

        // GET: HonorRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HonorRole honorRole = db.HonorRoles.Find(id);
            if (honorRole == null)
            {
                return HttpNotFound();
            }
            return View(honorRole);
        }

        // POST: HonorRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HonorRole honorRole = db.HonorRoles.Find(id);
            db.HonorRoles.Remove(honorRole);
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
