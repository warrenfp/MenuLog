using Autofac;
using Autofac.Extensions.DependencyInjection;
using MenuLog.Core.Framework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuLog.Tests
{
    public abstract class BaseFixtureWithStartup
    {
        [TestInitialize]
        public void Initialize()
        {
            IServiceCollection services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);
            services.BuildServiceProvider();
        }
    }
}
