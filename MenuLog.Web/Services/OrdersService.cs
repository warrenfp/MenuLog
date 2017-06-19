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

            foreach (var restaurant in restaurants)
            {
                if (restaurant.Rating.HasValue) //Don't recalculate
                    continue;

                var averagePrice = _data.OrderData.Where(w => w.Restaurant.Name != restaurant.Name)
                    .Average(a => a.Price); //Across all OTHER restaurants as your benchmark

                _rankingStrategy.PriceComparison = averagePrice;
                _rankingStrategy.ScoreComparison = 2.5; //This is the highest possible score per order (1.5 for recency + 1(avg) price)

                var restaurantOrders = GetRestaurantOrders(restaurant.Name);
                var scores = _rankingStrategy.CalculateScores(restaurantOrders);

                restaurant.Rating = scores.Stars;
                restaurant.Score = scores.Score;
            }
            
            return restaurants.OrderByDescending(o => o.Score)
                .ThenByDescending(s => s.Rating);
        }

        private IEnumerable<IOrder> GetRestaurantOrders(string name)
        {
            return _data.OrderData.Where(w => w.Restaurant.Name == name);
        }
    }
}
