using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.Controllers
{
    public class AdminLayoutcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
