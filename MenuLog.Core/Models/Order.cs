using System;
using MenuLog.Core.Interfaces;

namespace MenuLog.Core.Models
{
    public class Order : IOrder
    {
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public double Score { get; set; }
        public int Ranking { get; set; }

        public IRestaurant Restaurant { get; set; }
    }
}
