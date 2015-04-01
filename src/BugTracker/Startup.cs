using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

public class Startup
{
    public IConfiguration Configuration { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add MVC services to the services container
        services.AddMvc();

        // Add all SignalR related services to IoC.
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app)
    {
        // Error page middleware displays a nice formatted HTML page for any unhandled exceptions in the request pipeline.
        // Note: ErrorPageOptions.ShowAll to be used only at development time. Not recommended for production.
        app.UseErrorPage(ErrorPageOptions.ShowAll);

        // Configure SignalR
        app.UseSignalR();

        // Serves static files in the application.
        app.UseFileServer();

        // Configure Mvc
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
