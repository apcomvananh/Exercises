using System.Web.Optimization;

namespace TOEICEssentialWords.Web
{
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/pushy").Include(
                      "~/Scripts/metisMenu.js",
                      "~/Scripts/pushy.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/pushy.css",
                      "~/Content/metisMenu.css",
                      "~/css/font-awesome.css",
                      "~/Content/Style.css"));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/metisMenu.css",
                      "~/Content/admin/sb-admin-2.css",
                      "~/Content/admin/Admin.css",
                      "~/css/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.min.js",
                      "~/Scripts/metisMenu.js",
                      "~/Scripts/admin/sb-admin-2.js",
                      "~/Scripts/common.js",
                      "~/Scripts/admin/admin.js"));
        }
    }
}