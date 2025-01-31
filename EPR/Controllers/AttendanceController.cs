using Microsoft.AspNetCore.Mvc;

namespace EPR.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
