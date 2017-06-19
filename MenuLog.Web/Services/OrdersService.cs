using System.Collections.Generic;
using System.Linq;
using MenuLog.Core.Interfaces;

namespace MenuLog.Web.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IDbData _data;
        private readonly IRankingStrategy _rankingStrategy;

        public OrdersService(IDbData data, IRankingFactory rankingFactory)
        {
            _data = data;
            _rankingStrategy = rankingFactory.GetStrategy();
        }

        public IEnumerable<IRestaurant> GetRestaurantByRanking()
        {
            var restaurants = _data.OrderData.Select(s => s.Restaurant).Distinct().ToList();
            var averagePrice = _data.OrderData.Average(a => a.Price); //Across all restaurants as your benchmark

            _rankingStrategy.PriceComparison = averagePrice;

            foreach (var restaurant in restaurants)
            {
                if (restaurant.Rating.HasValue) //Don't recalculate
                    continue;

                var restaurantOrders = GetRestaurantOrders(restaurant.Name);
                restaurant.Rating = _rankingStrategy.GetRating(restaurantOrders);
            }
            
            return restaurants.OrderByDescending(o => o.Rating);
        }

        private IEnumerable<IOrder> GetRestaurantOrders(string name)
        {
            return _data.OrderData.Where(w => w.Restaurant.Name == name);
        }
    }
}
