using MenuLog.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MenuLog.Core.Factories.Ranking
{
    public abstract class RankingFactory : IRankingFactory
    {
        private string _strategyName;

        //Using Dependency Injection get the default strategy name
        protected RankingFactory(IConfiguration configuration)
        {
            _strategyName = configuration["Strategies:Default:Name"];
        }

        IRankingStrategy IRankingFactory.GetStrategy()
        {
            throw new System.NotImplementedException();
        }
    }
}