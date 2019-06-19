using Autofac;
using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.DreamAgg.Services;
using DreamCatcher.Domain.UserAgg.Contracts;
using DreamCatcher.Domain.UserAgg.Services;
using DreamCatcher.Infra.Data.Config;
using DreamCatcher.Infra.Data.Repositories;

namespace DreamCatcher.Infra.CrossCutting.IoC.Autofac
{
    public static class AutofacConfiguration
    {

        public static void RegisterContainer(this ContainerBuilder builder)
        {
            //Domain services
            builder.RegisterType<DreamService>().As<IDreamService>().InstancePerRequest();
            builder.RegisterType<DreamTaskService>().As<IDreamTaskService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();



            builder.Register(x=> new NHibernateConnectionFactory());
            //builder.Register(x=> new UserRepository(x.Resolve<NHibernateConnectionFactory>()))
            //    .As<IUserRepository>();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<DreamRepository>().As<IDreamRepository>().InstancePerRequest();
            builder.RegisterType<DreamTaskRepository>().As<IDreamTaskRepository>().InstancePerRequest();

        }
    }
}
