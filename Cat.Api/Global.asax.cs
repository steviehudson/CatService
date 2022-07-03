using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Cat.Data.Repositories;
using Cat.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.API
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(IServiceCollection services)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            services
                .AddTransient<ICatService, CatService>()
                .AddTransient<ICatRepository, CatRepository>();

        }
    }
}