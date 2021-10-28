using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VisitorManager.Infrastructure.Services;

namespace VisitorManager.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IServiceMarker>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}