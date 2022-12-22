using Microsoft.AspNetCore.Mvc;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
