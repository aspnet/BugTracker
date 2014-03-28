// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Abstractions;
using Microsoft.AspNet.DependencyInjection;
using Microsoft.AspNet.DependencyInjection.Fallback;
using Microsoft.AspNet.RequestContainer;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Diagnostics;

namespace BugTracker
{
    public class Startup
    {
        public void Configuration(IBuilder app)
        {
            //ErrorPageOptions.ShowAll to be used only at development time. Not recommended for production. 
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            var serviceProvider = new ServiceCollection()
                     .Add(MvcServices.GetDefaultServices())
                     .Add(SignalRServices.GetServices())
                     .BuildServiceProvider(app.ServiceProvider);

            app.UseContainer(serviceProvider);

            //Configure SignalR
            app.MapSignalR();

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
        }
    }
}