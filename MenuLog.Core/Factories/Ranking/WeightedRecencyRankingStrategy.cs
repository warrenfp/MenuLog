using System;
using System.Collections.Generic;
using MenuLog.Core.Interfaces;

namespace MenuLog.Core.Factories.Ranking
{
    public class WeightedRecencyRankingStrategy : IRankingStrategy
    {
        public int GetRating(IEnumerable<IOrder> orders)
        {
            throw new NotImplementedException();
        }
    }
}
