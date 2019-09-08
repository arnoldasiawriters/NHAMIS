﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class RecordType: NHAMISBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<NomineeRecords> NomineeRecords { get; set; }
    }
}
