using System.Web.Mvc;
using System.Web.Routing;

namespace Transactions_ADO.NET
{
    public class RouteConfig
    {
        public static void RegisterRoutes (RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}"
                , new { controller = "Cliente", action = "ListarClientes", id = UrlParameter.Optional });
        }
    }
}
