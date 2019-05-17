using Autofac;
using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.DreamAgg.Services;

namespace DreamCatcher.Infra.CrossCutting.IoC
{
    public static class AutofacConfiguration
    {

        public static void RegisterContainer(this ContainerBuilder builder)
        {
            //Domain services
            builder.RegisterType<DreamService>().As<IDreamService>().InstancePerRequest();

        }
    }
}
