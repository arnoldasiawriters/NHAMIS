using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class HonorRole : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string SerialNo { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string Medal { get; set; }
        public string Rank { get; set; }
        public DateTime? ConfirementDate { get; set; }
        public string Nationality { get; set; }
    }
}