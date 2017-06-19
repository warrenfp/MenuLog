using MenuLog.Core.Interfaces;

namespace MenuLog.Core.Factories.Ranking
{
    public class DefaultRankingFactory : IRankingFactory
    {
        public virtual IRankingStrategy GetStrategy(string strategyName = "")
        {
            throw new System.NotImplementedException(@"Please implement your own ranking factory. 
                Ensure you specify your strategy name in the Stragies configuration section. eg. Strategies:YourStrategy:Name");

            //For the sake of this demo. Ensure the user has to have their own implementation.
        }
    }
}