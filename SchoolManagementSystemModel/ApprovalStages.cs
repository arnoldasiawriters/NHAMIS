using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class ApprovalStages: NHAMISBaseClass
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<NominationApprovals> NominationApprovals { get; set; }
    }
}
