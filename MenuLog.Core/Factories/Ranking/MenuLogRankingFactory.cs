using Autofac;
using MenuLog.Core.Extensions;
using MenuLog.Core.Framework;
using MenuLog.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MenuLog.Core.Factories.Ranking
{
    public class MenuLogRankingFactory : DefaultRankingFactory
    {
        private readonly string _strategyName;
        
        /// <summary>
        /// Uses Dependency Injection to fetch the configuration and get the default strategy name
        /// </summary>
        /// <param name="configuration"></param>
        public MenuLogRankingFactory(IConfiguration configuration)
        {
            _strategyName = configuration["Strategies:MenuLog:Name"];
        }

        public override IRankingStrategy GetStrategy(string strategyName = "")
        {
            return IoC.Container.ResolveNamed<IRankingStrategy>(strategyName.IsEmpty() //Using a custom IsEmpty string extension.
                ? _strategyName 
                : strategyName);
        }
    }
}