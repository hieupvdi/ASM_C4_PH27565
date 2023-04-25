using DuAn.IServices;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;

namespace DuAn.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly IUserServices _userServices;// Interface
        public LoginController()
        {
            _userServices =new UserServices();
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Login1(string username, string pass)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pass))
            {
                if(username.Length > 6 && pass.Length > 6)
                {
                    if (!Regex.IsMatch(username, "[A-Za-z]") || !Regex.IsMatch(pass, "[A-Za-z]"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.errr = "tài khoản pass không chứa kí tự đặt biệt";
                    }
                    
                }
                else
                {
                    ViewBag.errr = "tài khoản pass phải lớn hơn 6";
                }
                 
            }
            else
            {
                ViewBag.errr = "phải nhập thông tin";
               
            }


            return View();
        }
    }
}
