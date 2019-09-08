using NHAMIS.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class NominationsViewModel
    {
        public  Nomination Nomination { get; set; }
        public County MyProperty { get; set; }
        public NomineeRecords NomineeRecords { get; set; }
        public List<Nomination> Nominations { get; set; }
    }
}