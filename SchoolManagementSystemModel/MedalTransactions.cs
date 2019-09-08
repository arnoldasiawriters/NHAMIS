using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
    public class MedalTransactions : NHAMISBaseClass
    {
        public int Id { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionBy { get; set; }
        public int Quantity { get; set; }
        public int MedalId { get; set; }
        public virtual Medal Medal { get; set; }
    }
}
