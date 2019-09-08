using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class Ward: NHAMISBaseClass
    {
        public int Id { get; set; }
        public string WardName { get; set; }
        public string WardCode { get; set; }
        public int SubCountyId { get; set; }
        public virtual SubCounty Subcounty { get; set; }
    }
}