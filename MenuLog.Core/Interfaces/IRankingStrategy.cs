using System.Collections.Generic;

namespace MenuLog.Core.Interfaces
{
    public interface IRankingStrategy
    {
        double PriceComparison { get; set; }

        int GetRating(IEnumerable<IOrder> orders);
    }
}