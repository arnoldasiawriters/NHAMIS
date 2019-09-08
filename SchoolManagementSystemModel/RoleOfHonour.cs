using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class RoleOfHonour : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string SurName { get; set; }
        public string OtherNames { get; set; }
        public DateTime DateConferred { get; set; }
        public int MedalId { get; set; }
        public virtual Medal Medal { get; set; }
    }
}
