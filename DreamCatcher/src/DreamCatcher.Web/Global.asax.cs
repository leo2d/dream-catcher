using Autofac;
using Autofac.Integration.Mvc;
using DreamCatcher.Infra.CrossCutting.IoC.Autofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DreamCatcher.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ResolveDI();

        }

        private void ResolveDI()
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterContainer();
            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}
