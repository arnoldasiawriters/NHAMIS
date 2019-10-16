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
    public class SalutationsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: Salutations
        public ActionResult Index()
        {
            return View(db.Salutations.ToList());
        }

        // GET: Salutations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salutation salutation = db.Salutations.Find(id);
            if (salutation == null)
            {
                return HttpNotFound();
            }
            return View(salutation);
        }

        // GET: Salutations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salutations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Order,CreateBy,CreateDate,ModifyBy,ModifyDate")] Salutation salutation)
        {
            if (ModelState.IsValid)
            {
                db.Salutations.Add(salutation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salutation);
        }

        // GET: Salutations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salutation salutation = db.Salutations.Find(id);
            if (salutation == null)
            {
                return HttpNotFound();
            }
            return View(salutation);
        }

        // POST: Salutations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Order,CreateBy,CreateDate,ModifyBy,ModifyDate")] Salutation salutation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salutation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salutation);
        }

        // GET: Salutations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salutation salutation = db.Salutations.Find(id);
            if (salutation == null)
            {
                return HttpNotFound();
            }
            return View(salutation);
        }

        // POST: Salutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salutation salutation = db.Salutations.Find(id);
            db.Salutations.Remove(salutation);
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
