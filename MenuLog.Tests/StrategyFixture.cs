using System;
using System.Collections.Generic;
using Autofac;
using MenuLog.Core.Framework;
using MenuLog.Core.Interfaces;
using MenuLog.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuLog.Tests
{
    [TestClass]
    public class StrategyFixture : BaseFixtureWithStartup
    {
        [TestMethod]
        public void Can_Resolve_The_Strategy_Named_WeightedRecencyRanking()
        {
            Assert.IsNotNull(IoC.Container.ResolveNamed<IRankingStrategy>("WeightedRecencyRanking"));
        }

        [TestMethod]
        public void More_Recent_Orders_Will_Rank_Higher()
        {
            var weightedRecencyStrategy = IoC.Container.ResolveNamed<IRankingStrategy>("WeightedRecencyRanking");
            weightedRecencyStrategy.PriceComparison = 100; //This is what you use to compare as your average across all of your data
            weightedRecencyStrategy.ScoreComparison = 2.5;

            var ranking1 = weightedRecencyStrategy.GetRating(new List<IOrder>
            {
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
            });

            var ranking2 = weightedRecencyStrategy.GetRating(new List<IOrder>
            {
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow.AddDays(-1), Price = 100}, //2 older orders
                new Order {OrderDate = DateTime.UtcNow.AddDays(-1), Price = 100}
            });

            Assert.IsTrue(ranking1 > ranking2, "Ranking 1 set is expected to be higher than ranking 2 set");

            Assert.AreEqual(5, ranking1, "Expected ranking 1 to be 5 stars");
            Assert.AreEqual(4, ranking2, "Expected ranking 2 to be 4 stars");
        }

        [TestMethod]
        public void Higher_Than_Average_Priced_Meals_Will_Be_Penalized()
        {
            var weightedRecencyStrategy = IoC.Container.ResolveNamed<IRankingStrategy>("WeightedRecencyRanking");
            weightedRecencyStrategy.PriceComparison = 100; //This is what you use to compare as your average across all of your data
            weightedRecencyStrategy.ScoreComparison = 2.5; 

            var ranking1 = weightedRecencyStrategy.GetRating(new List<IOrder>
            {
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
            });

            var ranking2 = weightedRecencyStrategy.GetRating(new List<IOrder>
            {
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 200}, 
                new Order {OrderDate = DateTime.UtcNow, Price = 200}
            });

            Assert.IsTrue(ranking1 > ranking2, "Ranking 1 set is expected to be higher than ranking 2 set");

            Assert.AreEqual(5, ranking1, "Expected ranking 1 to be 5 stars");
            Assert.AreEqual(4, ranking2, "Expected ranking 2 to be 4 stars");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Please input a minimum of 5 orders to calculate an accurate ranking")]
        public void Expect_An_Exception_If_Not_Enough_Orders_Are_Supplied()
        {
            var weightedRecencyStrategy = IoC.Container.ResolveNamed<IRankingStrategy>("WeightedRecencyRanking");

            weightedRecencyStrategy.GetRating(new List<IOrder>
            {
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
                new Order {OrderDate = DateTime.UtcNow, Price = 100},
            });
        }
    }
}
