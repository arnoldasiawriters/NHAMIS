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
    public class NominationAttachmentsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: NominationAttachments
        public ActionResult Index()
        {
            var nominationAttachments = db.NominationAttachments.Include(n => n.AttachmentType).Include(n => n.Nomination);
            return View(nominationAttachments.ToList());
        }

        // GET: NominationAttachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationAttachment nominationAttachment = db.NominationAttachments.Find(id);
            if (nominationAttachment == null)
            {
                return HttpNotFound();
            }
            return View(nominationAttachment);
        }

        // GET: NominationAttachments/Create
        public ActionResult Create()
        {
            ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name");
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber");
            return View();
        }

        // POST: NominationAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AttachmentUrl,NominationId,AttachmentTypeId,CreateBy,CreateDate,ModifyBy,ModifyDate")] NominationAttachment nominationAttachment)
        {
            if (ModelState.IsValid)
            {
                db.NominationAttachments.Add(nominationAttachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name", nominationAttachment.AttachmentTypeId);
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", nominationAttachment.NominationId);
            return View(nominationAttachment);
        }

        // GET: NominationAttachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationAttachment nominationAttachment = db.NominationAttachments.Find(id);
            if (nominationAttachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name", nominationAttachment.AttachmentTypeId);
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", nominationAttachment.NominationId);
            return View(nominationAttachment);
        }

        // POST: NominationAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AttachmentUrl,NominationId,AttachmentTypeId,CreateBy,CreateDate,ModifyBy,ModifyDate")] NominationAttachment nominationAttachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominationAttachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name", nominationAttachment.AttachmentTypeId);
            ViewBag.NominationId = new SelectList(db.Nominations, "Id", "IdNumber", nominationAttachment.NominationId);
            return View(nominationAttachment);
        }

        // GET: NominationAttachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationAttachment nominationAttachment = db.NominationAttachments.Find(id);
            if (nominationAttachment == null)
            {
                return HttpNotFound();
            }
            return View(nominationAttachment);
        }

        // POST: NominationAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NominationAttachment nominationAttachment = db.NominationAttachments.Find(id);
            db.NominationAttachments.Remove(nominationAttachment);
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
