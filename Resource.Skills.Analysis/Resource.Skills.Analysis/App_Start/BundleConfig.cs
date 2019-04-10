using System.Web;
using System.Web.Optimization;

namespace Resource.Skills.Analysis
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/style/styleSheet").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery",
                "~/Scripts/jquery/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap",
                "~/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular",
                "~/Scripts/angular/angular-1.6.2.js",
                "~/Scripts/angular/angular-route.js",
                "~/Scripts/angular/angular-resource.js",
                "~/Scripts/angular/angular-animate.js",
                "~/Scripts/angular/angular-aria.js",
                "~/Scripts/angular/angular-locale_pt-br.js",
                "~/Scripts/angular/angular-cookies.js",
                "~/Scripts/angular/angular-sanitize.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/shared").Include("~/Scripts/Shared/app.js",
                 "~/Scripts/Services/helperService.js"));
            bundles.Add(new ScriptBundle("~/bundles/routing-debug").Include("~/Scripts/Shared/rotas-debug.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include("~/Scripts/Home/homeController.js"));
            bundles.Add(new ScriptBundle("~/bundles/produto").Include("~/Scripts/Produto/produtoController.js"));
            bundles.Add(new ScriptBundle("~/bundles/usuario").Include("~/Scripts/Usuario/usuarioController.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
