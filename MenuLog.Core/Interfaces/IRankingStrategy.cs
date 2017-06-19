using System.Collections.Generic;

namespace MenuLog.Core.Interfaces
{
    public interface IRankingStrategy
    {
        double PriceComparison { get; set; }
        double ScoreComparison { get; set; }

        int GetRating(IEnumerable<IOrder> orders);
    }
}