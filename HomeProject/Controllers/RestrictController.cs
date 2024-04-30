using HomeProject.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HomeProject.Controllers
{
    [PageUserLogin]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
