using Microsoft.AspNet.Identity;
using NHAMIS;
using NHAMIS.APP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class NominationsController : Controller
    {
        private NHAMISContext db = new NHAMISContext();

        // GET: Nominations
        public ActionResult Index()
        {
            var nominations = db.Nominations.Include(n => n.NominatingBody).Include(n => n.NominationPeriod).Include(n => n.Salutation).Include(n => n.Ward).Include(o => o.Occupation);
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            return View(nominations.ToList());
        }

        // GET: Approve
        public ActionResult Approve()
        {
            var nominations = db.Nominations
                .Include(n => n.NominatingBody)
                .Include(n => n.NominationPeriod)
                .Include(n => n.Salutation)
                .Include(n => n.Ward)
                .Include(o => o.Occupation)
                .Include(o => o.NominationApprovals);
            ViewBag.NominatingBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            ViewBag.ApprovalStageId = new SelectList(db.ApprovalStages, "Id", "Name");
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
            //ViewBag.NominationBodyId = new SelectList(db.NominatingBodies, "Id", "Name");
            //ViewBag.NominationPeriodId = new SelectList(db.NominationPeriods, "Id", "Name");
            //ViewBag.SalutationId = new SelectList(db.Salutations, "Id", "Name");
            //ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            //ViewBag.CountyId = new SelectList(db.Counties, "Id", "CountyName");
            //ViewBag.CountyOfBirthId = new SelectList(db.Counties, "CountyName", "CountyName");
            //ViewBag.SubCountyId = new SelectList(db.SubCounties, "Id", "SubCountyName");
            //ViewBag.WardId = new SelectList(db.Wards, "Id", "WardName");
            //ViewBag.MedalId = new SelectList(db.Medals.OrderBy(o => o.OrderBy), "Id", "Name");
            //ViewBag.AcademicQualificationId = new SelectList(db.AcademicQualifications, "Id", "Name");
            //ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
            //ViewBag.AttachmentTypeId = new SelectList(db.AttachmentTypes, "Id", "Name");
            //ViewBag.NationalityId = new SelectList(new List<SelectListItem>
            //        {
            //            new SelectListItem {Text = "Kenyan", Value = "Kenyan"},
            //            new SelectListItem {Text = "Non-Kenyan", Value = "Non-Kenyan"},
            //        }, "Value", "Text");
            //ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return View();
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

        [HttpPost]
        public ActionResult PostNominationForm(Nomination model)
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var user = User.IsInRole("Admin");

            if (ModelState.IsValid)
            {
                var userDetails = db.UserDetails.Where(m => m.UserId == userId).FirstOrDefault();
                model.UserDetailsId = userDetails.Id;
                model.Status = "Pending";
                db.Nominations.Add(model);
                db.SaveChanges();
                int nominationId = model.Id;

                foreach (var achv in model.CitationAchievements)
                {
                    achv.NominationId = nominationId;
                    db.CitationAchievements.Add(achv);
                }

                foreach (var prevRec in model.PreviousRecognitions)
                {
                    prevRec.NominationId = nominationId;
                    db.PreviousRecognitions.Add(prevRec);
                }
                db.SaveChanges();

                ApprovalStages approvalStage = db.ApprovalStages.OrderBy(o => o.Order).FirstOrDefault();
                NominationApprovals nominationApproval = new NominationApprovals();
                nominationApproval.ApprovalStagesId = approvalStage.Id;
                nominationApproval.MedalId = model.MedalId;
                nominationApproval.NominationId = nominationId;
                nominationApproval.Status = false;
                db.NominationApprovals.Add(nominationApproval);
                db.SaveChanges();
                return RedirectToAction("Index", "Nominations");
            }
            return RedirectToAction("Create", "Nominations");
        }

        public ActionResult PostAttachmentForms(HttpPostedFileBase file)
        {
            return null;
        }

        public ActionResult GetApprovalsSelectLists()
        {
            var selectlists = new
            {
                NominationPeriods = db.NominationPeriods.Select(c => new { c.Id, c.Name, c.Year, c.Month }).OrderByDescending(c => c.Year).OrderByDescending(c => c.Year).ToList(),
                ApprovalStages = db.ApprovalStages.Select(c => new { c.Id, c.Name, c.Order }).OrderBy(c => c.Order).ToList(),
                Medals = db.Medals.Select(c => new { c.Id, c.Name, c.OrderBy }).OrderBy(c => c.OrderBy).ToList()
            };
            return Json(selectlists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchNominationApprovals(string periodId, string stageId)
        {
            NominationPeriod period = db.NominationPeriods.Find(int.Parse(periodId));
            ApprovalStages approval = db.ApprovalStages.Find(int.Parse(stageId));

            var result = db.NominationApprovals
                .Where(a => a.ApprovalStagesId == approval.Id && a.Nomination.NominationPeriodId == period.Id)
                .Select(c => new
                {
                    c.Id,
                    NominatingBody = new { c.Nomination.NominatingBody.Id, c.Nomination.NominatingBody.Name, c.Nomination.NominatingBody.Order },
                    SalutationName = c.Nomination.Salutation.Name,
                    c.Nomination.Surname,
                    c.Nomination.OtherNames,
                    c.Nomination.Nationality,
                    c.Nomination.CountyOfBirth,
                    Medal = new { c.Medal.Id, c.Medal.Name },
                    c.Status,
                    ApprovalStage = new { c.ApprovalStages.Id, c.ApprovalStages.Name, c.ApprovalStages.DisableMedalSelection }
                })
                .OrderBy(d => d.NominatingBody.Order)
                .ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ApprovalStages GetNextApproval(int currentstageid)
        {
            var currentstage = db.ApprovalStages.Find(currentstageid);
            int nextstageorder = currentstage.Order + 1;
            var nextstage = db.ApprovalStages.Where(o => o.Order == nextstageorder).FirstOrDefault();
            return nextstage;
        }

        [HttpPost]
        public ActionResult PostNominationApprovals(List<ApprovalViewModel> model)
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            foreach (var item in model)
            {
                var currNomStage = db.NominationApprovals.Find(item.Id);
                currNomStage.ApproverId = userId;
                currNomStage.MedalId = item.MedalId;
                currNomStage.Status = item.Status;
                currNomStage.ApprovalDate = DateTime.Now;
                db.Entry(currNomStage).State = EntityState.Modified;
                db.SaveChanges();

                var nextApprovalLevel = GetNextApproval(currNomStage.ApprovalStagesId);
                if (nextApprovalLevel != null)
                {
                    NominationApprovals approval = new NominationApprovals();
                    approval.ApprovalStagesId = nextApprovalLevel.Id;
                    approval.MedalId = currNomStage.MedalId;
                    approval.NominationId = currNomStage.NominationId;
                    approval.Status = false;
                    db.NominationApprovals.Add(approval);
                    db.SaveChanges();
                } else
                {
                    Nomination nomination = db.Nominations.Find(currNomStage.NominationId);
                    nomination.Status = "Approved";
                    db.Entry(nomination).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Approve", "Nominations");
        }
    }
}
