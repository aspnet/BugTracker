using Microsoft.AspNet;
using Microsoft.AspNet.Abstractions;
using Microsoft.AspNet.DependencyInjection;
using Microsoft.AspNet.DependencyInjection.Fallback;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.RequestContainer;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.SignalR;

namespace BugTracker
{
    public class Startup
    {
        public void Configuration(IBuilder app)
        {
            //ErrorPageOptions.ShowAll to be used only at development time. Not recommended for production. 
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            var serviceProvider = new ServiceCollection()
                     .AddMvc()
                     .AddSignalR()
                     .BuildServiceProvider(app.ServiceProvider);

            app.UseContainer(serviceProvider);

            //Configure SignalR
            app.MapSignalR();

            //Configure static files
            app.UseFileServer();

            //Configure WebFx
            var routes = new RouteCollection()
            {
                DefaultHandler = new MvcRouteHandler(),
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