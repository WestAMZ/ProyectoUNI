using System.Web;
using System.Web.Optimization;

namespace PAEDUCA
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));


            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css"));

            //Bundle Robust
            bundles.Add(new StyleBundle("~/Content/css_robust").Include(
                        "~/Public/css/css_robust/bootstrap.min.css",
                        "~/Public/css/css_robust/bootstrap-extended.min.css",
                        "~/Public/css/css_robust/app.min.css",
                        "~/Public/css/css_robust/colors.min.css",
                        "~/Public/css/css_robust/core/menu/menu-types/vertical-menu.css"));
            //bundles.Add(new StyleBundle("~/Content/css_robust").IncludeDirectory
            //    ("~/Public/css/css_robust", "*.css", true));


            //Estilos Personalizados
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Public/css/Estilos.css"));
        }
    }
}
