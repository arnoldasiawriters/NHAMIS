using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class NominationAttachment : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string AttachmentUrl { get; set; }
        public int NominationId { get; set; }
        public virtual Nomination Nomination { get; set; }
        public int AttachmentTypeId { get; set; }
        public virtual AttachmentType AttachmentType { get; set; }
    }
}