using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class CitationAchievement : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string PositionHeld { get; set; }
        public string Project { get; set; }
        public string Role { get; set; }
        [DataType(DataType.MultilineText)]
        public string Achivement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NominationId {get; set; }
        public Nomination Nomination { get; set; }
    }
}
