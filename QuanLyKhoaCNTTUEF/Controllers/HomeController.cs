using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaCNTTUEF.Data;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {
            int countevent = _context.Event.Count();
            int counttask = _context.Task.Count();
            int countplan = _context.Plan.Count();
            int countgroup = _context.Group.Count();
            ViewBag.EventCount = countevent;
            ViewBag.TaskCount = counttask;
            ViewBag.PlanCount = countplan;
            ViewBag.GroupCount = countgroup;
            return View();
        }

    }

}
