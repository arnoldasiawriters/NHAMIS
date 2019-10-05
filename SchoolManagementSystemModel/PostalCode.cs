using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAMIS.APP.Models
{
   public class PostalCode : NHAMISBaseClass
    {
        public int Id { get; set; }
        public int Code { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Town { get; set; }
        public virtual List<UserDetails> UserDetails { get; set; }
    }
}
