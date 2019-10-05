using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class ApprovalStages : NHAMISBaseClass
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual ICollection<NominationApprovals> NominationApprovals { get; set; }
        public bool DisableMedalSelection { get; set; }
        public string RoleId { get; set; }
    }
}