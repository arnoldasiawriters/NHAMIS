using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class Occupation: NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Nomination> Nominations { get; set;  }
    }
}
