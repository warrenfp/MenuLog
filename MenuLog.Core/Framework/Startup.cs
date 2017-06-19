using Autofac;
using MenuLog.Core.Factories.Ranking;
using MenuLog.Core.Interfaces;

namespace MenuLog.Core.Framework
{
    public static class Startup
    {
        public static void RegisterCustomTypes(ContainerBuilder containerBuilder)
        {
            //Our imlementation of the the Default ranking factory
            containerBuilder
                .RegisterType<MenuLogRankingFactory>()
                .As<IRankingFactory>();

            containerBuilder
                .RegisterType<WeightedRecencyRankingStrategy>()
                .Named<IRankingStrategy>("WeightedRecencyRanking");
        }
    }
}
