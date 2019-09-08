using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class HonorRole : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string IdNumber { get; set; }
        public DateTime ConfirementDate { get; set; }
        public string Nationality { get; set; }
        public int SalutationId { get; set; }
        public virtual Salutation Salutation { get; set; }
        public int MedalId { get; set; }
        public virtual Medal Medal { get; set; }
    }
}