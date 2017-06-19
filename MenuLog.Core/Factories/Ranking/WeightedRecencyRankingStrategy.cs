using System;
using System.Collections.Generic;
using System.Linq;
using MenuLog.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MenuLog.Core.Factories.Ranking
{
    /// <summary>
    /// This strategy expects a list of orders to be passed in.
    /// A minumum amount of orders is essential to calculate an "accurate" ranking
    /// NOTE: The purpose of this strategy is to implement an ultra simple basic weighted recency strategy.
    /// 
    /// Assumptions:
    /// This always compares an order for 1 person. Obviously multiple people would have a higher bill which would affect the rating.
    /// 
    /// Implementation details:
    /// Average price is used as the benchmark
    /// 
    /// </summary>
    public class WeightedRecencyRankingStrategy : IRankingStrategy
    {
        public double RecencyFactor { get; set; } = 1.5; //Property initialization :)
        public double PriceFactor { get; set; } = 1.0;
        public double CustomerRatingFactor { get; set; } = 0.3;

        public double PriceComparison { get; set; }
        public double ScoreComparison { get; set; }

        public int MinimumOrderAmount { get; set; } = 3;

        public WeightedRecencyRankingStrategy()
        {
        }

        public WeightedRecencyRankingStrategy(IConfiguration configuration)
        {
            RecencyFactor = Convert.ToDouble(configuration["Strategies:MenuLog:RecencyFactor"]);
            PriceFactor = Convert.ToDouble(configuration["Strategies:MenuLog:PriceFactor"]);
            CustomerRatingFactor = Convert.ToDouble(configuration["Strategies:MenuLog:CustomerRatingFactor"]);
        }

        public ScoreResult CalculateScores(IEnumerable<IOrder> orders)
        {
            var list = orders.ToList(); //To avoid multiple enumerations through orders

            if (list.Count < MinimumOrderAmount)
                throw new ArgumentOutOfRangeException($"Please input a minimum of {MinimumOrderAmount} orders to calculate an accurate ranking");

            //Calculate the score
            foreach (var order in list)
            {
                double score = 0;

                var totalDays = Math.Round(DateTime.UtcNow.Subtract(order.OrderDate).TotalDays, 2);

                //older order will get ranked exponentially worse on time. Orders today will get max score of 1 * recency factor
                score += (1 / (totalDays + 1)) * RecencyFactor;

                score += (PriceComparison / order.Price) * PriceFactor; //Higher priced meals would be penalized
                score += order.CustomerRating * CustomerRatingFactor;
                order.Score = Math.Round(score, 2);
            }

            //Assign the ranking
            foreach (var order in list)
            {
                var percentage = (order.Score / ScoreComparison) * 100;
                order.Ranking = GetStarLevel(percentage);
            }

            return new ScoreResult
            {
                Stars = (int)list.Average(s => s.Ranking),
                Score = list.Average(s => s.Score)
            };
        }

        private static int GetStarLevel(double percentage)
        {
            if (percentage > 80)
                return 5;

            if (percentage > 60)
                return 4;

            if (percentage > 40)
                return 3;

            if (percentage > 20)
                return 2;

            return 1;
        }
    }
}
