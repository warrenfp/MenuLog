using System.Collections.Generic;

namespace MenuLog.Core.Interfaces
{
    public interface IRankingStrategy
    {
        int GetRating(IEnumerable<IOrder> orders);
    }
}