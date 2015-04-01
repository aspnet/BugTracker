using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;

namespace BugTracker
{
    /// <summary>
    /// This demonstrates how the application can be launched in a DNX console application. 
    /// "dnx . run" command in the application folder will invoke this.
    /// </summary>
    public class Program
    {
        private readonly IServiceProvider _hostServiceProvider;

        public Program(IServiceProvider hostServiceProvider)
        {
            _hostServiceProvider = hostServiceProvider;
        }

        public Task<int> Main(string[] args)
        {
            var config = new Configuration();
            config.AddCommandLine(args);
            config.AddEnvironmentVariables();

            var context = new HostingContext()
            {
                Configuration = config,
                ApplicationName = "BugTracker",
                ServerFactoryLocation = "Microsoft.AspNet.Server.WebListener",
            };

            var engine = new HostingEngine(_hostServiceProvider);

            using (engine.Start(context))
            {
                Console.WriteLine("Started the server..");
                Console.WriteLine("Press any key to stop the server");
                Console.ReadLine();
            }

            return Task.FromResult(0);
        }
    }
}