using Microsoft.AspNet.Mvc;

namespace BugTracker.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}