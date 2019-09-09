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
    public class MedalsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: Medals
        public ActionResult Index()
        {
            return View(db.Medals.ToList());
        }

        // GET: Medals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medal medal = db.Medals.Find(id);
            if (medal == null)
            {
                return HttpNotFound();
            }
            return View(medal);
        }

        // GET: Medals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abbreviation,Quantity,OrderBy,CreateBy,CreateDate,ModifyBy,ModifyDate")] Medal medal)
        {
            if (ModelState.IsValid)
            {
                db.Medals.Add(medal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medal);
        }

        // GET: Medals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medal medal = db.Medals.Find(id);
            if (medal == null)
            {
                return HttpNotFound();
            }
            return View(medal);
        }

        // POST: Medals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abbreviation,Quantity,OrderBy,CreateBy,CreateDate,ModifyBy,ModifyDate")] Medal medal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medal);
        }

        // GET: Medals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medal medal = db.Medals.Find(id);
            if (medal == null)
            {
                return HttpNotFound();
            }
            return View(medal);
        }

        // POST: Medals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medal medal = db.Medals.Find(id);
            db.Medals.Remove(medal);
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
