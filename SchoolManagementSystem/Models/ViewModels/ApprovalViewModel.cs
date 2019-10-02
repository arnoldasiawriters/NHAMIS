using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class ApprovalViewModel
    {
        public int Id { get; set; }
        public int MedalId { get; set; }
        public bool Status { get; set; }
    }
}