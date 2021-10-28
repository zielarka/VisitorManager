using Autofac;
using Microsoft.Extensions.Configuration;
using VisitorManager.Infrastructure.IoC.Modules;
using VisitorManager.Infrastructure.Mappers;


namespace VisitorManager.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfigurationRoot _configuration;

        public ContainerModule(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
