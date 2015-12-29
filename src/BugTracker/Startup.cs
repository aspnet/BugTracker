using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add MVC services to the services container
        services.AddMvc();

        //Add all SignalR related services to IoC.
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            /* Error page middleware displays a nice formatted HTML page for any unhandled exceptions in the request pipeline.
            */
            app.UseDeveloperExceptionPage();
        }

        //Configure SignalR
        app.UseSignalR();

        //Serves static files in the application.
        app.UseFileServer();

        // Configure MVC
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

    public static void Main(string[] args)
    {
        var application = new WebApplicationBuilder()
            .UseConfiguration(WebApplicationConfiguration.GetDefault(args))
            .UseStartup<Startup>()
            .Build();

        application.Run();
    }
}
