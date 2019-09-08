using NHAMIS.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class UserDetailsViewModel
    {
        public UserDetails UserDetails { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public string RoleId { get; set; }
        public int NominatingBodyId {get; set; }
    }
}