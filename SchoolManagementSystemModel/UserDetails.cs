using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class UserDetails : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Designation { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string Town { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string OtherNo { get; set; }
        public string UserId { get; set; }
        public bool UserStatus { get; set; }
        public int NominatingBodyId { get; set; }
        public virtual NominatingBody NominatingBody { get; set; }
        public virtual List<Nomination> Nominations { get; set; }        
    }
}
