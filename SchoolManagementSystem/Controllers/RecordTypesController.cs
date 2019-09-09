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
    public class RecordTypesController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: RecordTypes
        public ActionResult Index()
        {
            return View(db.RecordTypes.ToList());
        }

        // GET: RecordTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecordType recordType = db.RecordTypes.Find(id);
            if (recordType == null)
            {
                return HttpNotFound();
            }
            return View(recordType);
        }

        // GET: RecordTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecordTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreateBy,CreateDate,ModifyBy,ModifyDate")] RecordType recordType)
        {
            if (ModelState.IsValid)
            {
                db.RecordTypes.Add(recordType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recordType);
        }

        // GET: RecordTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecordType recordType = db.RecordTypes.Find(id);
            if (recordType == null)
            {
                return HttpNotFound();
            }
            return View(recordType);
        }

        // POST: RecordTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreateBy,CreateDate,ModifyBy,ModifyDate")] RecordType recordType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recordType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recordType);
        }

        // GET: RecordTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecordType recordType = db.RecordTypes.Find(id);
            if (recordType == null)
            {
                return HttpNotFound();
            }
            return View(recordType);
        }

        // POST: RecordTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecordType recordType = db.RecordTypes.Find(id);
            db.RecordTypes.Remove(recordType);
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
