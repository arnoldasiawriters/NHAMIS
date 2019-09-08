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
    public class NominatingBodiesController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: NominatingBodies
        public ActionResult Index()
        {
            return View(db.NominatingBodies.ToList());
        }

        // GET: NominatingBodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominatingBody nominatingBody = db.NominatingBodies.Find(id);
            if (nominatingBody == null)
            {
                return HttpNotFound();
            }
            return View(nominatingBody);
        }

        // GET: NominatingBodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NominatingBodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Ministry,Order,Category,CreateBy,CreateDate,ModifyBy,ModifyDate")] NominatingBody nominatingBody)
        {
            if (ModelState.IsValid)
            {
                db.NominatingBodies.Add(nominatingBody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominatingBody);
        }

        // GET: NominatingBodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominatingBody nominatingBody = db.NominatingBodies.Find(id);
            if (nominatingBody == null)
            {
                return HttpNotFound();
            }
            return View(nominatingBody);
        }

        // POST: NominatingBodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Ministry,Order,Category,CreateBy,CreateDate,ModifyBy,ModifyDate")] NominatingBody nominatingBody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominatingBody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominatingBody);
        }

        // GET: NominatingBodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominatingBody nominatingBody = db.NominatingBodies.Find(id);
            if (nominatingBody == null)
            {
                return HttpNotFound();
            }
            return View(nominatingBody);
        }

        // POST: NominatingBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NominatingBody nominatingBody = db.NominatingBodies.Find(id);
            db.NominatingBodies.Remove(nominatingBody);
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
