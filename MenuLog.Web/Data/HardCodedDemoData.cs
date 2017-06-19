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
                        Name = "Restaurant" + (i + 1),
                        Suburb = new Suburb { PostCode = string.Concat("PostCode", i) }
                    });
                }


                return new List<IOrder>
                {
                    //Restaurant 1 => Expensive and not current
                    //Restarant 2 => Cheap and current
                    //Restaurant 3 => Old reviews and matching prices to restaurant 2
                    //Restaurant 4 => Older than 3. Same prices
                    //Restaurant 5 => Old and expensive
                    
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
                        Price = 60,
                        Restaurant = restaurants[1]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 60,
                        Restaurant = restaurants[1]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        Price = 60,
                        Restaurant = restaurants[1]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-6),
                        Price = 60,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-6),
                        Price = 60,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-6),
                        Price = 60,
                        Restaurant = restaurants[2]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-12),
                        Price = 60,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-12),
                        Price = 60,
                        Restaurant = restaurants[3]
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow.AddDays(-12),
                        Price = 60,
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