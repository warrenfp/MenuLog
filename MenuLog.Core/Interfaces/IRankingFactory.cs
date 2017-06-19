namespace MenuLog.Core.Interfaces
{
    public interface IRankingFactory
    {
        IRankingStrategy GetStrategy(string strategyName);
    }
}