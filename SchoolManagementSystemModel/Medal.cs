using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class Medal : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Quantity { get; set; }
        public int OrderBy { get; set; }
        public virtual List<NominationApprovals> NominationApprovals { get; set; }
        public virtual List<MedalTransactions> MedalTransactions { get; set; }
        public virtual List<Nomination> Nominations { get; set; }
    }
}