using NHAMIS.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class NominationsViewModel
    {
        public Nomination Nomination { get; set; }
        public County MyProperty { get; set; }
        public List<Nomination> Nominations { get; set; }
        public int NominationBodyId { get; set; }
        public int NominationPeriodId { get; set; }
        public string CountyOfBirthId { get; set; }
        public int CountryId { get; set; }
        public int CountyId { get; set; }
        public int SubCountyId { get; set; }
        public int WardId { get; set; }
        public int SalutationId { get; set; }
        public  int AcademicQualificationId { get; set; }
        public int OccupationId { get; set; }
        public int MedalId { get; set; }
        public int RecordTypeId { get; set; }
        public int AttachmentTypeId { get; set; }
        public string NationalityId { get; set; }
    }
}