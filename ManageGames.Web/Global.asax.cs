using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ManageGames.Web.MapperProfile;

namespace ManageGames.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(cfg=>cfg.AddProfile<AutomapperProfile>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
