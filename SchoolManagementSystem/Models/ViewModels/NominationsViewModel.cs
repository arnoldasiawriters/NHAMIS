using NHAMIS.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class NominationsViewModel
    {
        public int NominationId { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string CountyOfBirth { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string Town { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Village { get; set; }
        public int GenderId { get; set; }
        public string Status { get; set; }
        public int WardId { get; set; }
        public int SalutationId { get; set; }
        public int NominationPeriodId { get; set; }
        public int UserDetailsId { get; set; }
        public int AcademicQualificationId { get; set; }
        public int MedalId { get; set; }
        public int NominatingBodyId { get; set; }
        public int OccupationId { get; set; }
        public int CountryId { get; set; }
        public List<CitationAchievement> CitationAchievements { get; set; }
        public List<PreviousRecognition> PreviousRecognitions { get; set; }
        public List<NominationAttachment> NominationAttachments { get; set; }
    }
}