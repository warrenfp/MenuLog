using System;
using System.Collections.Generic;
using MenuLog.Core.Interfaces;
using MenuLog.Core.Models;

namespace MenuLog.Web.Data
{
    public class HardCodedDemoData : IDbData
    {
        public IList<IOrder> OrderData
        {
            get
            {
                var restaurants = new List<Restaurant>();

                for (int i = 0; i < 5; i++)
                {
                    restaurants.Add(new Restaurant
                    {
                        Name = "Restaurant - " + (i + 1),
                        Suburb = new Suburb
                        {
                            PostCode = string.Concat("PostCode" , i),
                            Name = i % 2 == 0 ? "Suburb 1" : "Suburb 2"
                        }
                    });
                }

                return new List<IOrder>
                {
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-14),
                        Price = 170,
                        Restaurant = restaurants[0]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-14),
                        Price = 170,
                        Restaurant = restaurants[0]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-14),  
                        Price = 170,
                        Restaurant = restaurants[0]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 80,
                        Restaurant = restaurants[1]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 80,
                        Restaurant = restaurants[1]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 80,
                        Restaurant = restaurants[1]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-15),
                        Price = 120,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-15),
                        Price = 120,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-15),
                        Price = 120,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-2),
                        Price = 150,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-2),
                        Price = 150,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-2),
                        Price = 150,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddMonths(-3),
                        Price = 500,
                        Restaurant = restaurants[4]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddMonths(-3),
                        Price = 500,
                        Restaurant = restaurants[4]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddMonths(-3),
                        Price = 500,
                        Restaurant = restaurants[4]
                    },
                };
            }
        }
    }
}