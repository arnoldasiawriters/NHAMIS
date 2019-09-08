using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class NominatingBody : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ministry { get; set; }
        public int Order { get; set; }
        public string Category { get; set; }
        public virtual List <UserDetails> UserDetails { get; set; }
        public virtual List<Nomination> Nominations { get; set; }
    }
}