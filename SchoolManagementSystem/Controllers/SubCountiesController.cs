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
    public class SubCountiesController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: SubCounties
        public ActionResult Index()
        {
            var subCounties = db.SubCounties.Include(s => s.County);
            return View(subCounties.ToList());
        }

        // GET: SubCounties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCounty subCounty = db.SubCounties.Find(id);
            if (subCounty == null)
            {
                return HttpNotFound();
            }
            return View(subCounty);
        }

        // GET: SubCounties/Create
        public ActionResult Create()
        {
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            return View();
        }

        // POST: SubCounties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubCountyName,SubCountyCode,CountyId,CreateBy,CreateDate,ModifyBy,ModifyDate")] SubCounty subCounty)
        {
            if (ModelState.IsValid)
            {
                db.SubCounties.Add(subCounty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName", subCounty.CountyId);
            return View(subCounty);
        }

        // GET: SubCounties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCounty subCounty = db.SubCounties.Find(id);
            if (subCounty == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName", subCounty.CountyId);
            return View(subCounty);
        }

        // POST: SubCounties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubCountyName,SubCountyCode,CountyId,CreateBy,CreateDate,ModifyBy,ModifyDate")] SubCounty subCounty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCounty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName", subCounty.CountyId);
            return View(subCounty);
        }

        // GET: SubCounties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCounty subCounty = db.SubCounties.Find(id);
            if (subCounty == null)
            {
                return HttpNotFound();
            }
            return View(subCounty);
        }

        // POST: SubCounties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCounty subCounty = db.SubCounties.Find(id);
            db.SubCounties.Remove(subCounty);
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
