using Autofac;
using Autofac.Extras.DynamicProxy;
using GlarisEngine.UserLinkTracker.Infrastructure.Logging;
using GlarisEngine.UserLinkTracker.ServiceConcrete;
using GlarisEngine.UserLinkTracker.ServiceInterface;

namespace GlarisEngine.UserLinkTracker.WebAppMVC.IOC
{
    public class ServiceIOCModule : Module
    {

        public ServiceIOCModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                 .RegisterType<AuthenticationService>().As<IAuthenticationService>()
                  .InstancePerLifetimeScope()
                  .EnableInterfaceInterceptors()
                  .InterceptedBy(typeof(LogInterceptor));

            base.Load(builder);
        }
    }
}
