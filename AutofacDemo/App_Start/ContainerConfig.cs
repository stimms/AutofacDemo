using Autofac;
using Autofac.Integration.Mvc;
using AutofacDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace AutofacDemo
{
    public class ContainerConfig
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Add our own components
            builder.RegisterType<NameResolver>().As<INameResolver>();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x=>x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}