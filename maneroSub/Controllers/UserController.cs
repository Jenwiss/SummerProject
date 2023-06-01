using Microsoft.AspNetCore.Mvc;

namespace maneroSub.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
