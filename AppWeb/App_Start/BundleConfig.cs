using System.Web;
using System.Web.Optimization;

namespace AppWeb
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
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/ScriptsGlobales").Include(
                "~/Scripts/ScriptsGlobales/Jquery.js",
                "~/Scripts/ScriptsGlobales/JQueryDataTable.js",
                "~/Scripts/ScriptsGlobales/Knockout.js",
                "~/Scripts/ScriptsGlobales/UtilitariosAJAX.js",
                "~/Scripts/ScriptsGlobales/Notify.js"));
            bundles.Add(new ScriptBundle("~/bundles/FormularioDeUsuario").Include(
                "~/Scripts/ViewModels/Usuario/FormularioUsuario.js",
                "~/Scripts/ViewModels/Usuario/UsuarioBinding.js"));


            //optimiza los archivos de scripts y de css. los minifica, sin embargo es recomendable para produccion no para desarrollo
            //BundleTable.EnableOptimizations = true;
        }
    }
}
