using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class NomineeRecords: NHAMISBaseClass
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Organisation { get; set; }
        [DataType(DataType.MultilineText)]
        public string Narration { get; set; }
        public int RecordTypeId { get; set; }
        public virtual RecordType RecordType { get; set; }
        public int NomineeId { get; set; }
        public virtual Nomination nomination { get; set; }
    }
}
