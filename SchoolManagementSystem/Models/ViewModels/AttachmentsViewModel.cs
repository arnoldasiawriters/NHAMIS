using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models.ViewModels
{
    public class AttachmentsViewModel
    {
        public List<HttpPostedFileBase> HttpPostedFiles { get; set; }
    }
}