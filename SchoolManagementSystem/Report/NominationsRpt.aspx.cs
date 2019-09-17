using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Report
{
    public partial class NominationsRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            string uname = WebConfigurationManager.AppSettings["RSeverUNAME"];
            string pword = WebConfigurationManager.AppSettings["RSeverPWORD"] + "123$";
            //string pword = WebConfigurationManager.AppSettings["RSeverPWORD"];
            string server = WebConfigurationManager.AppSettings["RSever"];
            ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(uname, pword, server);

        }
    }
}