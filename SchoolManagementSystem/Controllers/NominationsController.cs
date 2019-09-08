using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NHAMIS;
using NHAMIS.APP.Models;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class NominationsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: Nominations
        public ActionResult Index()
        {
            var nominations = db.Nominations.Include(n => n.NominatingBody).Include(n => n.NominationPeriod).Include(n => n.Salutation).Include(n => n.Ward);
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            return View(nominations.ToList());
        }

        // GET: Nominations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomination nomination = db.Nominations.Find(id);
            if (nomination == null)
            {
                return HttpNotFound();
            }
            return View(nomination);
        }

        // GET: Nominations/Create
        public ActionResult Create()
        {
            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name");
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            ViewBag.SubCountyId = new SelectList(db.SubCounties, "Id", "SubCountyName");
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName");
            ViewBag.MedalId = new SelectList(db.Medals.OrderBy(o => o.OrderBy), "Id", "Name");
            ViewBag.AcademicQualificationId = new SelectList(db.AcademicQualifications, "Id", "Name");
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "Id", "Name");
            return View();
        }

        // POST: Nominations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdNumber,Surname,OtherNames,DateOfBirth,Nationality,CountyOfBirth,Address,EmailAddress,MobileNumber,Location,SubLocation,Village,Occupation,PublicServiceRecords,Status,WardId,SalutationId,NominationPeriodId,NominationBodyId,CreateBy,CreateDate,ModifyBy,ModifyDate")] Nomination nomination)
        {
            if (ModelState.IsValid)
            {
                db.Nominations.Add(nomination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Title", nomination.NominatingBody);
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "CreateBy", nomination.NominationPeriodId);
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name", nomination.SalutationId);
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName", nomination.WardId);
            ViewBag.MedalId = new SelectList(db.Medals, "Id", "Name", nomination.MedalId);
            return View(nomination);
        }

        // GET: Nominations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomination nomination = db.Nominations.Find(id);
            if (nomination == null)
            {
                return HttpNotFound();
            }
            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Title", nomination.NominatingBodyId);
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "CreateBy", nomination.NominationPeriodId);
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name", nomination.SalutationId);
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName", nomination.WardId);
            return View(nomination);
        }

        // POST: Nominations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdNumber,Surname,OtherNames,DateOfBirth,Nationality,CountyOfBirth,Address,EmailAddress,MobileNumber,Location,SubLocation,Village,Occupation,PublicServiceRecords,Status,WardId,SalutationId,NominationPeriodId,NominationBodyId,CreateBy,CreateDate,ModifyBy,ModifyDate")] Nomination nomination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Title", nomination.NominatingBodyId);
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "CreateBy", nomination.NominationPeriodId);
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name", nomination.SalutationId);
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName", nomination.WardId);
            return View(nomination);
        }

        // GET: Nominations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomination nomination = db.Nominations.Find(id);
            if (nomination == null)
            {
                return HttpNotFound();
            }
            return View(nomination);
        }

        // POST: Nominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomination nomination = db.Nominations.Find(id);
            db.Nominations.Remove(nomination);
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
