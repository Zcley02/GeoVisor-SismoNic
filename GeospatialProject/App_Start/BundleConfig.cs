using System.Web;
using System.Web.Optimization;

namespace GeospatialProject
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/leafletv").Include(
                "~/Scripts/leaflet.js",
                "~/Scripts/leaflet.js.map",
                "~/Scripts/L.TileLayer.BetterWMS.js",
                "~/Scripts/leaflet-panel-layers.min.js",
                "~/Scripts/leaflet-providers.js",
                "~/Scripts/leaflet-src.esm.js",
                "~/Scripts/leaflet-src.esm.js.map",
                "~/Scripts/leaflet.groupedlayercontrol.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/leaflet-panel-layers.min.css",
                      "~/Content/leaflet.css",
                      "~/Content/leaflet.groupedlayercontrol.min.css",
                      "~/Content/style.css",
                      "~/Content/jquery.dataTables.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/jquery.dataTables.js"
                ));

        }
    }
}
