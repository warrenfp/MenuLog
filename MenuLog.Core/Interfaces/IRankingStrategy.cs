using System;
using System.Collections.Generic;
using MenuLog.Core.Factories.Ranking;

namespace MenuLog.Core.Interfaces
{
    public interface IRankingStrategy
    {
        double PriceComparison { get; set; }
        double ScoreComparison { get; set; }

        ScoreResult CalculateScores(IEnumerable<IOrder> orders);
    }
}