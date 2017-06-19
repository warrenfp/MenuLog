using MenuLog.Core.Interfaces;
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
            var rankings = _ordersService.GetRestaurantByRanking();
            
            return View();
        }
    }
}
