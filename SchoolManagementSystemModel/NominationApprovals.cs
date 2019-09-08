﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class NominationApprovals : NHAMISBaseClass
    {
        public int Id { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApproverId { get; set; }
        public int NominationId { get; set; }
        public virtual Nomination Nomination { get; set; }
        public int ApprovalStagesId { get; set; }
        public virtual ApprovalStages ApprovalStages { get; set; }
        public int MedalId { get; set; }
        public virtual Medal Medal { get; set; }
    }
}
