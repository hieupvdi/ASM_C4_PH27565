using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
