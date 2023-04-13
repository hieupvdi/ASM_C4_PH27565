using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserAdminController : Controller
    {
        private readonly IUserServices UserServices;// Interface
        public UserAdminController()
        {
            UserServices = new UserServices();
        }
        public IActionResult Index()
        {
            return View();
        }


        //show User
        public ActionResult ShowAllUser()
        {

            List<User> users = UserServices.GetAllUsers();
            return View(users); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }



        //thêm sửa xóa User



        public IActionResult CreateUser() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User p, IFormFile LinkAnh)
        {
            // Lưu file ảnh vào thư mục "wwwroot/images"
            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", LinkAnh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                p.LinkAnh = "/images/" + fileName;
            }

            if (UserServices.CreateUser(p))
            {
                return RedirectToAction("ShowAllUser");
            }
            else return BadRequest();
        }









        public IActionResult DetailUsers(Guid id)
        {
            var users = UserServices.GetUserById(id);
            return View(users);
        }

        public IActionResult DeleteUser(Guid id)
        {
            if (UserServices.DeleteUser(id))
            {
                return RedirectToAction("ShowAllUser");
            }
            else return BadRequest();
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
