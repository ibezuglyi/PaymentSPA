using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using StructureMap;
using PaymentSPA.UnitOfWork;
using System.Data.Entity;
using PaymentSPA.Models;
using PaymentSPA.Repositories;
using System.Web.Mvc;
using PaymentSPA.App_Start;
using PaymentSPA.Services;

namespace PaymentSPA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            IContainer container = GetIoCContainer();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

        }

        private static IContainer GetIoCContainer()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                x.For<IUnitOfWork>().Use<UnitOfWork.UnitOfWork>();
                x.For<DbContext>().Use<PaymentContext>();
                x.For<IPaymentRepository>().Use<PaymentRepository>();
                x.For<IPaymentService>().Use<PaymentService>();
            });
            return ObjectFactory.Container;
        }
    }
}
