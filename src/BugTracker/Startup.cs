using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Abstractions;
using Microsoft.AspNet.ConfigurationModel;
using Microsoft.AspNet.DependencyInjection;
using Microsoft.AspNet.DependencyInjection.Fallback;
using Microsoft.AspNet.RequestContainer;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.DependencyInjection.NestedProviders;

namespace BugTracker
{
    public class Startup
    {
        public void Configuration(IBuilder app)
        {
            var serviceProvider = new ServiceCollection()
                     .Add(MvcServices.GetDefaultServices())
                     .Add(SignalRServices.GetServices())
                     .BuildServiceProvider(app.ServiceProvider);

            app.UseContainer(serviceProvider);

            //Configure static files
            app.UseFileServer();

            //Configure WebFx
            var routes = new RouteCollection()
            {
                DefaultHandler = new MvcApplication(serviceProvider),
            };

            routes.MapRoute(
                "{controller}/{action}",
                new { controller = "Home", action = "Index" });

            routes.MapRoute(
                "api/{controller}/{action}",
                new { controller = "Home", action = "Index" });

            routes.MapRoute(
                "api/{controller}",
                new { controller = "Home" });

            //Configure MVC
            app.UseRouter(routes);

            //Configure SignalR
            app.MapSignalR();
        }
    }
}