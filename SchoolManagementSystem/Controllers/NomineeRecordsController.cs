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
    public class NomineeRecordsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: NomineeRecords
        public ActionResult Index()
        {
            var nomineeRecords = db.NomineeRecords.Include(n => n.RecordType);
            return View(nomineeRecords.ToList());
        }

        // GET: NomineeRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NomineeRecords nomineeRecords = db.NomineeRecords.Find(id);
            if (nomineeRecords == null)
            {
                return HttpNotFound();
            }
            return View(nomineeRecords);
        }

        // GET: NomineeRecords/Create
        public ActionResult Create()
        {
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "Id", "Name");
            return View();
        }

        // POST: NomineeRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Name,Organisation,Narration,RecordTypeId,NomineeId,CreateBy,CreateDate,ModifyBy,ModifyDate")] NomineeRecords nomineeRecords)
        {
            if (ModelState.IsValid)
            {
                db.NomineeRecords.Add(nomineeRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "Id", "Name", nomineeRecords.RecordTypeId);
            return View(nomineeRecords);
        }

        // GET: NomineeRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NomineeRecords nomineeRecords = db.NomineeRecords.Find(id);
            if (nomineeRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "Id", "Name", nomineeRecords.RecordTypeId);
            return View(nomineeRecords);
        }

        // POST: NomineeRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Name,Organisation,Narration,RecordTypeId,NomineeId,CreateBy,CreateDate,ModifyBy,ModifyDate")] NomineeRecords nomineeRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomineeRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "Id", "Name", nomineeRecords.RecordTypeId);
            return View(nomineeRecords);
        }

        // GET: NomineeRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NomineeRecords nomineeRecords = db.NomineeRecords.Find(id);
            if (nomineeRecords == null)
            {
                return HttpNotFound();
            }
            return View(nomineeRecords);
        }

        // POST: NomineeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NomineeRecords nomineeRecords = db.NomineeRecords.Find(id);
            db.NomineeRecords.Remove(nomineeRecords);
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
