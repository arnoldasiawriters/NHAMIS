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
    public class CitationAchievementsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: CitationAchievements
        public ActionResult Index()
        {
            var citationAchievements = db.CitationAchievements.Include(c => c.Nomination);
            return View(citationAchievements.ToList());
        }

        // GET: CitationAchievements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitationAchievement citationAchievement = db.CitationAchievements.Find(id);
            if (citationAchievement == null)
            {
                return HttpNotFound();
            }
            return View(citationAchievement);
        }

        // GET: CitationAchievements/Create
        public ActionResult Create()
        {
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber");
            return View();
        }

        // POST: CitationAchievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PositionHeld,Project,Role,Achivement,StartDate,EndDate,NominationId,CreateBy,CreateDate,ModifyBy,ModifyDate")] CitationAchievement citationAchievement)
        {
            if (ModelState.IsValid)
            {
                db.CitationAchievements.Add(citationAchievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", citationAchievement.NominationId);
            return View(citationAchievement);
        }

        // GET: CitationAchievements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitationAchievement citationAchievement = db.CitationAchievements.Find(id);
            if (citationAchievement == null)
            {
                return HttpNotFound();
            }
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", citationAchievement.NominationId);
            return View(citationAchievement);
        }

        // POST: CitationAchievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PositionHeld,Project,Role,Achivement,StartDate,EndDate,NominationId,CreateBy,CreateDate,ModifyBy,ModifyDate")] CitationAchievement citationAchievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citationAchievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", citationAchievement.NominationId);
            return View(citationAchievement);
        }

        // GET: CitationAchievements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitationAchievement citationAchievement = db.CitationAchievements.Find(id);
            if (citationAchievement == null)
            {
                return HttpNotFound();
            }
            return View(citationAchievement);
        }

        // POST: CitationAchievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CitationAchievement citationAchievement = db.CitationAchievements.Find(id);
            db.CitationAchievements.Remove(citationAchievement);
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
