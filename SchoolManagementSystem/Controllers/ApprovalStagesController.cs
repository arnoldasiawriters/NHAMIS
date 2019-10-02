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
    public class ApprovalStagesController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: ApprovalStages
        public ActionResult Index()
        {
            return View(db.ApprovalStages.ToList());
        }

        // GET: ApprovalStages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalStages approvalStages = db.ApprovalStages.Find(id);
            if (approvalStages == null)
            {
                return HttpNotFound();
            }
            return View(approvalStages);
        }

        // GET: ApprovalStages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovalStages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Order,CreateBy,CreateDate,ModifyBy,ModifyDate")] ApprovalStages approvalStages)
        {
            if (ModelState.IsValid)
            {
                db.ApprovalStages.Add(approvalStages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(approvalStages);
        }

        // GET: ApprovalStages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalStages approvalStages = db.ApprovalStages.Find(id);
            if (approvalStages == null)
            {
                return HttpNotFound();
            }
            return View(approvalStages);
        }

        // POST: ApprovalStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Order,CreateBy,CreateDate,ModifyBy,ModifyDate")] ApprovalStages approvalStages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvalStages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approvalStages);
        }

        // GET: ApprovalStages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalStages approvalStages = db.ApprovalStages.Find(id);
            if (approvalStages == null)
            {
                return HttpNotFound();
            }
            return View(approvalStages);
        }

        // POST: ApprovalStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApprovalStages approvalStages = db.ApprovalStages.Find(id);
            db.ApprovalStages.Remove(approvalStages);
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
