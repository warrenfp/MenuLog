using Autofac;
using Autofac.Extensions.DependencyInjection;
using MenuLog.Core.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MenuLog.Tests
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("httpLogger.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);
            
            Core.Framework.Startup.RegisterCustomTypes(builder); //Add our own common dependencies

            var container = builder.Build();
            IoC.Container = container;
        }
    }
}
