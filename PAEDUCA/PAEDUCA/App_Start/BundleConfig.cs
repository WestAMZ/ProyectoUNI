using System.Web;
using System.Web.Optimization;

namespace PAEDUCA
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css_robust").Include(
                        "~/Public/css/css_robust/bootstrap.min.css",
                        "~/Public/css/css_robust/fonts/icomoon.css",
                        "~/Public/css/css_robust/bootstrap-extended.min.css",
                        "~/Public/css/css_robust/app.min.css",
                        "~/Public/css/css_robust/colors.min.css",
                        "~/Public/css/css_robust/core/menu/menu-types/vertical-menu.css",
                        "~/Public/css/css_robust/core/menu/menu-types/vertical-overlay-menu.css"


                        ));


            //Estilos Personalizados
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Public/css/Estilos.css"));
        }
    }
}
