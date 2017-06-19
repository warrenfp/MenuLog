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
                var restaurants = new List<Restarant>();

                for (int i = 0; i < 5; i++)
                {
                    restaurants.Add(new Restarant
                    {
                        Name = "Restaurant" + i,
                        Suburb = new Suburb { PostCode = string.Concat("PostCode", i) }
                    });
                }


                return new List<IOrder>
                {
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 100,
                        Restaurant = restaurants[0]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 150,
                        Restaurant = restaurants[0]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(2),
                        Price = 100,
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
                        OrderDate = DateTime.UtcNow.AddDays(-3),
                        Price = 100,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-3),
                        Price = 100,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-3),
                        Price = 100,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 60,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 60,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 60,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 120,
                        Restaurant = restaurants[4]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 120,
                        Restaurant = restaurants[4]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 120,
                        Restaurant = restaurants[4]
                    },


                };
            }
        }
    }
}