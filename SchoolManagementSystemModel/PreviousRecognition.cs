using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class PreviousRecognition : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string RecognizingInstitution { get; set; }
        public string AchievementTitle { get; set; }
        public string Award { get; set; }
        public DateTime? AwardDate { get; set; }
        public int NominationId { get; set; }
        public Nomination Nomination { get; set; }
    }
}
