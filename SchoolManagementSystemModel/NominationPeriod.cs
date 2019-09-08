using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class NominationPeriod : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime NominationDate { get; set; }
        public virtual List<Nomination> Nominations { get; set; }
    }
}