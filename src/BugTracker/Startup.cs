using Microsoft.AspNet;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.SignalR;

    public class Startup
    {
        public void Configure(IBuilder app)
        {
            /* Error page middleware displays a nice formatted HTML page for any unhandled exceptions in the request pipeline.
            * Note: ErrorPageOptions.ShowAll to be used only at development time. Not recommended for production.
            */
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            app.UseServices(services =>
            {
                //Add all MVC related services to IoC.
                services.AddMvc();

                //Add all SignalR related services to IoC.
                services.AddSignalR();
            });

            //Configure SignalR
            app.UseSignalR();

            //Serves static files in the application.
            app.UseFileServer();

            //Configure WebFx
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    null,
                    "{controller}/{action}",
                    new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    null,
                    "api/{controller}/{action}",
                    new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    null,
                    "api/{controller}",
                    new { controller = "Home" });
            });
        }
    }
