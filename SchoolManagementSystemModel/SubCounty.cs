using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class SubCounty : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string SubCountyName { get; set; }
        public string SubCountyCode { get; set; }
        public int CountyId { get; set; }
        public virtual County County { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }        
    }
}