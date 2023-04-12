using Microsoft.AspNetCore.Mvc;

namespace WebApplication2MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
