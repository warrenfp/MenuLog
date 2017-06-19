using System.Collections.Generic;

namespace MenuLog.Core.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<IRestaurant> GetRestaurantsByRanking();
    }
}