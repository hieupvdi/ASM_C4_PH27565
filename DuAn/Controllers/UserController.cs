using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices UserServices;// Interface

        public UserController()
        {
            UserServices = new UserServices();
        }
        public IActionResult Index()
        {
            return View();
        }

        //show User
        public ActionResult ShowACC()
        {
            // Lấy dữ liệu từ Session để truyền vào View
            //Đoạn mã này dùng để lấy dữ liệu giỏ hàng từ session và truyền vào view để hiển thị các sản phẩm trong giỏ hàng

            var users = SessionUser.GetObjFromSession(HttpContext.Session, "Users");
            return View(users);// Truyền sang view

        }


        [HttpGet]

        public IActionResult EditUser(Guid id)
        {
            var users = UserServices.GetUserById(id);
            return View(users);
        }
        public IActionResult EditUser(User p, IFormFile LinkAnh)
        {
            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }

                p.LinkAnh = "/images/" + fileName;
            }

            if (UserServices.UpdateUser(p))
            {
                return RedirectToAction("ShowAllUser");
            }
            else
            {
                return BadRequest();
            }

        }







    }
}
