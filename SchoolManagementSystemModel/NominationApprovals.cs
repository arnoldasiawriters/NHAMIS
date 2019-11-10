using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class NominationApprovals : NHAMISBaseClass
    {
        public int Id { get; set; }
        public DateTime? ApprovalDate { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ApproverId { get; set; }
        public int NominationId { get; set; }
        public virtual Nomination Nomination { get; set; }
        public int ApprovalStagesId { get; set; }
        public virtual ApprovalStages ApprovalStages { get; set; }
        public int MedalId { get; set; }
        public virtual Medal Medal { get; set; }
        public bool Status { get; set; }
        public bool? Forwarded { get; set; }
    }
}
