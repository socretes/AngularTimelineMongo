using System.Web;
using System.Web.Optimization;

namespace AngularServiceStackMongo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/browser-support").Include(
                        "~/scripts/modernizr-{version}.js",
                        "~/scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/common-scripts").Include(
                        "~/scripts/jquery-{version}.js",
                        "~/scripts/moment.js",
                        "~/scripts/angular.js",
                        "~/scripts/angular-route.js",
                        "~/scripts/angular-resource.js",
                        "~/scripts/angular-ui/ui-bootstrap.js",
                        "~/scripts/spin.js",
                        "~/scripts/angular-spinner.js",
                        "~/scripts/toastr.js",
                        "~/scripts/app/app.js",
                //"~/scripts/app/filters/*.js",
                        "~/scripts/app/directives/*.js",
                        "~/scripts/app/services/*.js",
                        "~/scripts/app/controllers/*.js"
                        //"~/scripts/pickadate/*.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/content/bootstrap.css",
                      "~/content/toastr.css",
                      "~/content/styles.css",
                      "~/content/responsivemobilemenu.css",
                      "~/content/bootstrap-switch.css"
                      //"~/content/app/app.css"
                      ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
