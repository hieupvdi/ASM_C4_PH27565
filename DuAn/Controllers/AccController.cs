using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DuAn.Controllers
{
    public class AccController : Controller
    {
        private readonly IUserServices _userServices;// Interface
        public readonly IRoleServices _roleServices;
        public  readonly ICartServices _cartServices;
        public AccController()
        {
            _userServices = new UserServices();
            _roleServices = new RoleServices();
            _cartServices = new CartServices();
           
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(User p)
        {
            DuAn.Models.ShopDbContext db = new DuAn.Models.ShopDbContext();

            var user = db.Users.FirstOrDefault(p => p.Username == p.Username);


            var check = _userServices.GetUserByName(p.Username);
            if (check == null)
            {

                _userServices.CreateUser(p);
            }
            else
            {
                ViewBag.error = "Username đã đăng ký";
                return View();
            }
             return BadRequest();



        }
      
      
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]

        #region  loginloi
        //public ActionResult DangNhap1(string username, string password)
        //{

        //    DuAn.Models.ShopDbContext db = new DuAn.Models.ShopDbContext();
        //    var timUr = db.Users.FirstOrDefault(p => p.Username == username);

        //    var users = SessionUser.GetObjFromSession(HttpContext.Session, "Users");
        //    if (timUr != null)
        //    {

        //        var newusers = new User
        //        {

        //            Id = timUr.Id,
        //            Gmail = timUr.Gmail,
        //            LinkAnh = timUr.LinkAnh,
        //            Username = timUr.Username,
        //            Password = timUr.Password,
        //            RoleId = timUr.RoleId,
        //            Status = timUr.Status,


        //        };


        //        var data = db.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).ToList();
        //        if (data != null)
        //        {


        //            var data11 = db.Roles.FirstOrDefault(r => r.RoleName == "Admin");
        //            if (data11 != null)
        //            {
        //                // Người dùng có vai trò là Admin
        //                // Thực hiện các logic liên quan đến trang Admin
        //                return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
        //            }
        //            else 
        //            {

        //                users.Add(newusers);
        //                SessionUser.SetObjToSession(HttpContext.Session, "Users", users);
        //  
        //                return RedirectToAction("Index", "Home");
        //            }

        //        }
        //        else
        //        {
        //            ViewBag.Loginfail = "Đăng nhập thất bại,vui lòng trở lại";
        //            return RedirectToAction("DangNhap");
        //        }

        //    }
        //    else
        //    {
        //        ViewBag.Loginfail = "Đăng nhập thất bại,vui lòng trở lại";
        //        return RedirectToAction("DangNhap");
        //    }


        //}
        #endregion

        public IActionResult DangNhap(string username, string password)
        {
            //đang lỗi
            //if (!Regex.IsMatch(usernam, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(pass, "^[a-zA-Z0-9]*$"))
            var user = _userServices.GetUserUserName(username.Trim());
            var users = SessionUser.GetObjFromSession(HttpContext.Session, "Users");

            if (user != null && user.Username == username && user.Password == password && user.Status == 0)
            {
                var role = _roleServices.GetRoleById(user.RoleId);
                if (role.RoleName == "Admin")
                {
                    users.Add(user);
                    SessionUser.SetObjToSession(HttpContext.Session, "Users", users);
                    // Lưu giá trị userId vào Session
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                  
                }
                else
                {
                    users.Add(user);
                  
                    SessionUser.SetObjToSession(HttpContext.Session, "Users", users);
                    // Lưu userId vào Session
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Erro = "Đăng Nhập k thành công";
                return RedirectToAction("DangNhap");

            }


        }




        //Đăng Xuất
        public ActionResult DangXuat()
        {       
            SessionUser.ClearSessio(HttpContext.Session);//Clear session           
            return RedirectToAction("DangNhap");
        }
    }
}
