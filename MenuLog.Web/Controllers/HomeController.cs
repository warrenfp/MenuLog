using System.Linq;
using MenuLog.Core.Interfaces;
using MenuLog.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MenuLog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrdersService _ordersService;

        public HomeController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public IActionResult Index()
        {
            //Transform to a simpler object.
            var rankings = _ordersService.GetRestaurantsByRanking().Select(s => new RestaurantModel
            {
                Name = s.Name,
                PostCode = s.Suburb.PostCode,
                SuburbName = s.Suburb.Name,
                Rating = s.Rating,
                Score = s.Score
            });

            var model = new RankingModel()
            {
                Rankings = rankings
            };
            
            return View(model);
        }
    }
}
