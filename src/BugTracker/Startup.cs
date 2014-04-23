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

            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddSignalR();
            });

            //Configure SignalR
            app.UseSignalR();
			
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

            routes.MapRoute("api/{controller}/{id?}");
            
            //Configure MVC
            app.UseRouter(routes);
        }
    }
}