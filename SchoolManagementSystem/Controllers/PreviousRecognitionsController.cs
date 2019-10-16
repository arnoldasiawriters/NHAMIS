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
    public class PreviousRecognitionsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: PreviousRecognitions
        public ActionResult Index()
        {
            var previousRecognitions = db.PreviousRecognitions.Include(p => p.Nomination);
            return View(previousRecognitions.ToList());
        }

        // GET: PreviousRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviousRecognition previousRecognition = db.PreviousRecognitions.Find(id);
            if (previousRecognition == null)
            {
                return HttpNotFound();
            }
            return View(previousRecognition);
        }

        // GET: PreviousRecognitions/Create
        public ActionResult Create()
        {
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber");
            return View();
        }

        // POST: PreviousRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecognizingInstitution,AchievementTitle,Award,AwardDate,NominationId,CreateBy,CreateDate,ModifyBy,ModifyDate")] PreviousRecognition previousRecognition)
        {
            if (ModelState.IsValid)
            {
                db.PreviousRecognitions.Add(previousRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", previousRecognition.NominationId);
            return View(previousRecognition);
        }

        // GET: PreviousRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviousRecognition previousRecognition = db.PreviousRecognitions.Find(id);
            if (previousRecognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", previousRecognition.NominationId);
            return View(previousRecognition);
        }

        // POST: PreviousRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecognizingInstitution,AchievementTitle,Award,AwardDate,NominationId,CreateBy,CreateDate,ModifyBy,ModifyDate")] PreviousRecognition previousRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previousRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", previousRecognition.NominationId);
            return View(previousRecognition);
        }

        // GET: PreviousRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviousRecognition previousRecognition = db.PreviousRecognitions.Find(id);
            if (previousRecognition == null)
            {
                return HttpNotFound();
            }
            return View(previousRecognition);
        }

        // POST: PreviousRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreviousRecognition previousRecognition = db.PreviousRecognitions.Find(id);
            db.PreviousRecognitions.Remove(previousRecognition);
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
