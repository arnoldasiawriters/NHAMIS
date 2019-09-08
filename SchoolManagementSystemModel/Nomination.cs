using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class Nomination : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
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
        public string Status { get; set; }
        public string CountryOfBirth { get; set; }
        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }
        public int SalutationId { get; set; }
        public virtual Salutation Salutation { get; set; }
        public int NominationPeriodId { get; set; }
        public virtual NominationPeriod NominationPeriod { get; set; }
        public int UserDetailsId { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public int AcademicQualificationId { get; set; }
        public virtual AcademicQualification AcademicQualification { get; set; }
        public int MedalId { get; set; }
        public virtual Medal Medal { get; set; }
        public int NominatingBodyId { get; set; }
        public virtual NominatingBody NominatingBody { get; set; }
        public virtual ICollection<NominationApprovals> NominationApprovals { get; set; }
        public int OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }
        
    }
}