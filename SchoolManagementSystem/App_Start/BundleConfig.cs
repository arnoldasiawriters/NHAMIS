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
                //"~/admin-lte/js/pages/dashboard2.js",
                "~/admin-lte/js/adminlte.js",
                "~/admin-lte/js/app.js"));

            // AngularJs Files
            bundles.Add(new ScriptBundle("~/Scripts/AngularJs").Include(
               "~/Scripts/AngularJs/angular.min.js",
               "~/Scripts/AngularJs/lodash.min.js",
               "~/Scripts/AngularJs/Services.js",
               "~/Scripts/AngularJs/App.js"));

            // jquery datatables js files
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.min.js"));

            // jquery datatables css file
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css"));
        }
    }
}
