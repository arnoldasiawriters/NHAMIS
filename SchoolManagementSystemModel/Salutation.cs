using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHAMIS.APP.Models
{
    public class Salutation : NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Nomination> Nominations { get; set; }
    }
}