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
    public class NominatingBodyCategoriesController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: NominatingBodyCategories
        public ActionResult Index()
        {
            return View(db.NominatingBodyCategories.ToList());
        }

        // GET: NominatingBodyCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominatingBodyCategory nominatingBodyCategory = db.NominatingBodyCategories.Find(id);
            if (nominatingBodyCategory == null)
            {
                return HttpNotFound();
            }
            return View(nominatingBodyCategory);
        }

        // GET: NominatingBodyCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NominatingBodyCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreateBy,CreateDate,ModifyBy,ModifyDate")] NominatingBodyCategory nominatingBodyCategory)
        {
            if (ModelState.IsValid)
            {
                db.NominatingBodyCategories.Add(nominatingBodyCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominatingBodyCategory);
        }

        // GET: NominatingBodyCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominatingBodyCategory nominatingBodyCategory = db.NominatingBodyCategories.Find(id);
            if (nominatingBodyCategory == null)
            {
                return HttpNotFound();
            }
            return View(nominatingBodyCategory);
        }

        // POST: NominatingBodyCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreateBy,CreateDate,ModifyBy,ModifyDate")] NominatingBodyCategory nominatingBodyCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominatingBodyCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominatingBodyCategory);
        }

        // GET: NominatingBodyCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominatingBodyCategory nominatingBodyCategory = db.NominatingBodyCategories.Find(id);
            if (nominatingBodyCategory == null)
            {
                return HttpNotFound();
            }
            return View(nominatingBodyCategory);
        }

        // POST: NominatingBodyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NominatingBodyCategory nominatingBodyCategory = db.NominatingBodyCategories.Find(id);
            db.NominatingBodyCategories.Remove(nominatingBodyCategory);
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
