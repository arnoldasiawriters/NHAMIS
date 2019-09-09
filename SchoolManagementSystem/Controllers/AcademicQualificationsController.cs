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
    public class AcademicQualificationsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: AcademicQualifications
        public ActionResult Index()
        {
            return View(db.AcademicQualifications.ToList());
        }

        // GET: AcademicQualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicQualification academicQualification = db.AcademicQualifications.Find(id);
            if (academicQualification == null)
            {
                return HttpNotFound();
            }
            return View(academicQualification);
        }

        // GET: AcademicQualifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicQualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreateBy,CreateDate,ModifyBy,ModifyDate")] AcademicQualification academicQualification)
        {
            if (ModelState.IsValid)
            {
                db.AcademicQualifications.Add(academicQualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicQualification);
        }

        // GET: AcademicQualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicQualification academicQualification = db.AcademicQualifications.Find(id);
            if (academicQualification == null)
            {
                return HttpNotFound();
            }
            return View(academicQualification);
        }

        // POST: AcademicQualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreateBy,CreateDate,ModifyBy,ModifyDate")] AcademicQualification academicQualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicQualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicQualification);
        }

        // GET: AcademicQualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicQualification academicQualification = db.AcademicQualifications.Find(id);
            if (academicQualification == null)
            {
                return HttpNotFound();
            }
            return View(academicQualification);
        }

        // POST: AcademicQualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicQualification academicQualification = db.AcademicQualifications.Find(id);
            db.AcademicQualifications.Remove(academicQualification);
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
