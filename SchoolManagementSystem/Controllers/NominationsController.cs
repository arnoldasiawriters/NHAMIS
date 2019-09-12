using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using NHAMIS;
using NHAMIS.APP.Models;
using SchoolManagementSystem.Models;

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

        // GET: Approve
        public ActionResult Approve()
        {
            var nominations = db.Nominations.Include(n => n.NominatingBody).Include(n => n.NominationPeriod).Include(n => n.Salutation).Include(n => n.Ward);
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            return View(nominations.ToList());
        }


        // GET: Update ROH
        public ActionResult UpdateROH()
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
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            ViewBag.CountyOfBirthId = new SelectList(db.Counties, "CountyName", "CountyName");
            ViewBag.SubCountyId = new SelectList(db.SubCounties, "Id", "SubCountyName");
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName");
            ViewBag.MedalId = new SelectList(db.Medals.OrderBy(o => o.OrderBy), "Id", "Name");
            ViewBag.AcademicQualificationId = new SelectList(db.AcademicQualifications, "Id", "Name");
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
            ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name");
            ViewBag.NationalityId = new SelectList(new List<SelectListItem>
                    {
                        new SelectListItem {Text = "Kenyan", Value = "Kenyan"},
                        new SelectListItem {Text = "Non-Kenyan", Value = "Non-Kenyan"},
                    }, "Value", "Text");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return View();
        }

        // POST: Nominations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NominationsViewModel model)
        {
            var currentUserId = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.GetUserId())
            ? System.Web.HttpContext.Current.User.Identity.GetUserId()
            : "Anonymous";
            model.Nomination.AcademicQualificationId = model.AcademicQualificationId;
            model.Nomination.CountryId = model.CountryId;
            model.Nomination.MedalId = model.MedalId;
            model.Nomination.NominatingBodyId = model.NominationBodyId;
            model.Nomination.NominationPeriodId = model.NominationPeriodId;
            model.Nomination.OccupationId = model.OccupationId;
            model.Nomination.SalutationId = model.SalutationId;
            model.Nomination.CountyOfBirth = model.CountyOfBirthId;

            //model.Nomination = model.RecordTypeId;
            model.Nomination.UserDetailsId = 2;
            model.Nomination.WardId = model.WardId;
            model.Nomination.Nationality = model.NationalityId;

            if (ModelState.IsValid)
            {
                db.Nominations.Add(model.Nomination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToList();
            }

            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            ViewBag.CountyOfBirthId = new SelectList(db.Counties, "Id", "CountyName");
            ViewBag.SubCountyId = new SelectList(db.SubCounties, "Id", "SubCountyName");
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName");
            ViewBag.MedalId = new SelectList(db.Medals.OrderBy(o => o.OrderBy), "Id", "Name");
            ViewBag.AcademicQualificationId = new SelectList(db.AcademicQualifications, "Id", "Name");
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
            ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name");
            return View(model);
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
            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            ViewBag.CountyOfBirthId = new SelectList(db.Counties, "CountyName", "CountyName");
            ViewBag.SubCountyId = new SelectList(db.SubCounties, "Id", "SubCountyName");
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName");
            ViewBag.MedalId = new SelectList(db.Medals.OrderBy(o => o.OrderBy), "Id", "Name");
            ViewBag.AcademicQualificationId = new SelectList(db.AcademicQualifications, "Id", "Name");
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
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
            ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            ViewBag.CountyOfBirthId = new SelectList(db.Counties, "CountyName", "CountyName");
            ViewBag.SubCountyId = new SelectList(db.SubCounties, "Id", "SubCountyName");
            ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName");
            ViewBag.MedalId = new SelectList(db.Medals.OrderBy(o => o.OrderBy), "Id", "Name");
            ViewBag.AcademicQualificationId = new SelectList(db.AcademicQualifications, "Id", "Name");
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
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

        /// <summary>
        /// A function for searching roles from the role of honor.
        /// </summary>
        /// <param name="searchKey"></param>: The parameter to be searched.
        /// <returns></returns>
        public ActionResult SearchRoleOfHonor(string searchKey)
        {
            var roleOfHonor = db.HonorRoles
                                .Where(m => m.Name.Contains(searchKey) || m.IdNumber.Contains(searchKey))
                                .Include(m => m.Medal)
                                .ToList();
            return Json(roleOfHonor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSelectLists()
        {
            var selectlists = new
            {
                NominatingBodies = db.NominatingBodies.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(),
                NominationPeriods = db.NominationPeriods.Select(c => new { c.Id, c.Name, c.Year, c.Month }).OrderByDescending(c => c.Year).OrderByDescending(c => c.Year).ToList(),
                Counties = db.Counties.Select(c => new { c.Id, c.CountyName }).OrderBy(c => c.CountyName).ToList(),
                Countries = db.Countries.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(),
                Salutations = db.Salutations.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(),
                Genders = db.Genders.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(),
                AcademicQualifications = db.AcademicQualifications.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(),
                Medals = db.Medals.Select(c => new { c.Id, c.Name, c.OrderBy }).OrderBy(c => c.OrderBy).ToList(),
                AttachmentTypes = db.AttachmentTypes.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(),
                Occupations = db.Occupations.Select(c => new { c.Id, c.Name })
            };
            return Json(selectlists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubCounties(int countyid)
        {
            var subcounties = db.SubCounties.Where(s => s.CountyId == countyid).ToList();
            return Json(subcounties, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetWards(int subcountyid)
        {
            var wards = db.Wards.Where(w => w.SubCountyId == subcountyid).ToList();
            return Json(wards, JsonRequestBehavior.AllowGet);
        }
    }
}
