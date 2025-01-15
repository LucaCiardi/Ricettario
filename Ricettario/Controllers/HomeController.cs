using Microsoft.AspNetCore.Mvc;

namespace Ricettario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
