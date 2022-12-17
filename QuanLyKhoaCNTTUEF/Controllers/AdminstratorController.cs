using Microsoft.AspNetCore.Mvc;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class AdminstratorController : Controller
    {
        public string Admin(int id)
        {
            string admin = String.Empty;
            if (id == 1)
            {
                admin = "Bạn là quản trị viên";
            }
            else if (id == 2)
            {
                admin = "Bạn là quản trị viên 2";
            }
            else
            {
                admin = "Bạn không phải là quản trị viên!";
            }
            return admin;
        }
        public string Address(int id, string users)
        {
            return "id= " + id + "user= " + users;
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Event()
        {
            return View();
        }
        public ActionResult Plan()
        {
            return View();
        }
        public ActionResult Group()
        {
            return View();
        }
    }
}
