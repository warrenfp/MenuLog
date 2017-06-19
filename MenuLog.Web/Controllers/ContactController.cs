using Microsoft.AspNetCore.Mvc;

namespace MenuLog.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
