using System.Web;
using System.Web.Optimization;

namespace SchoolManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/admin-lte/css/AdminLTE.css",
                      "~/admin-lte/css/skins/skin-blue.css"));

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                "~/admin-lte/plugins/fastclick/fastclick.js",
                "~/admin-lte/js/pages/dashboard2.js",
                "~/admin-lte/js/adminlte.js",
                "~/admin-lte/js/app.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));


            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new ScriptBundle("~/Scripts/js").Include(
            //    "~/Content/AdminLTE/plugins/fastclick/fastclick.min.js",
            //    "~/Content/AdminLTE/dist/js/adminlte.js",
            //    "~/Content/AdminLTE/plugins/sparkline/jquery.sparkline.min.js",
            //    "~/Content/AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
            //    "~/Content/AdminLTE/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
            //    "~/Content/AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js",
            //    "~/Content/AdminLTE/plugins/chartjs/Chart.min.js",
            //    "~/Content/AdminLTE/dist/js/demo.js",
            //    "~/Scripts/jquery-ui-1.12.1.min.js",
            //    //"~/Scripts/chosen.jquery.min.js",
            //    //"~/Scripts/chosen.proto.min.js",
            //    "~/Scripts/bootbox.min.js",
            //    "~/Scripts/select2.min.js",
            //    "~/Scripts/custom.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/AdminLTE/bootstrap/css/bootstrap.min.css",
            //          "~/Content/font-awesome.min.css",
            //          "~/Content/AdminLTE/bootstrap/css/font-awesome.min.css",
            //          "~/Content/AdminLTE/bootstrap/css/ionicons.min.css",
            //          "~/Content/AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
            //          "~/Content/AdminLTE/dist/css/AdminLTE.min.css",
            //          "~/Content/AdminLTE/dist/css/skins/_all-skins.min.css",
            //          "~/Content/AdminLTE/plugins/iCheck/square/blue.css",
            //          "~/Content/themes/base/jquery-ui.min.css",
            //          //"~/Content/chosen.min.css",
            //           "~/Content/css/select2.min.css",
            //          "~/Content/Site.css"));

            // jquery datataables js files
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.min.js"));

            // jquery datatables css file
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css"));
        }
    }
}
