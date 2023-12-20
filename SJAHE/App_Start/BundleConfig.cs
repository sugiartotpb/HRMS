using System.Web;
using System.Web.Optimization;


    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/admin-lte/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js",
                      "~/Content/admin-lte/js/bootstrap.min.js",
                      "~/Content/admin-lte/js/adminlte.min.js",
                      "~/Content/admin-lte/js/icheck.min.js",
                      "~/Script/toastr.min.js"));

        bundles.Add(new ScriptBundle("~/bundles/HelperJS").Include(
                  "~/assets/plugins/dataTables/jquery.dataTables.min.js",
                  "~/assets/plugins/dataTables/dataTables.bootstrap.min.js"));

        bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/site.css",
                      "~/Content/admin-lte/css/bootstrap.min.css",
                      "~/Content/admin-lte/css/font-awesome.min.css",
                      //"~/Content/admin-lte/css/ionicons.min.css",
                      "~/Content/admin-lte/css/AdminLTE.min.css",
                      "~/Content/admin-lte/css/skin-blue.min.css",
                      "~/Content/admin-lte/css/blue.css",
                      "~/assets/plugins/dataTables/dataTables.bootstrap.css",
                      "~/Content/toastr.min.css"));
        }
    }

