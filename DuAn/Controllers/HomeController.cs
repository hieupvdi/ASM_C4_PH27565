using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;
using System.Diagnostics;

namespace DuAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices;// Interface




        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices(); // DI


        }

        public IActionResult Index()
        {
                   
            List<Product> Products = productServices.GetAllProducts();
            return View(Products); // Truyền trực tiếp 1 Obj Model duy nhất sang View



    
        }

        public ActionResult DanhSachsp()
        {
            List<Product> Products = productServices.GetAllProducts();
            return View(Products); // Truyền trực tiếp 1 Obj Model duy nhất sang View
        }
  

        public IActionResult ViewBag_ViewData()
        {
            var products = productServices.GetAllProducts();
            // ViewBag chứa dữ liệu dạng dynamic, khi cần sử dụng
            // ta không cần khởi tạo mà gán thẳng giá trị vào
            ViewBag.Products = products;
            ViewBag.Messages = "Bảo mất giá trông chán đời <3";
            // ViewData chứa dữ liệu dạng Generic, dữ liệu này được
            // lưu dưới dạng key-value
            ViewData["Products"] = products;
            ViewData["Values"] = "Giá trị của Bảo là ông chị";
            // trong đó "Product" là key còn products là value
            return View();
        }

        public IActionResult TestSession()
        {
            //ap dung cho phieen dang nhap cua tai khoan
            string message = "Em đói lắm không nghĩ được đâu";
            // Đưa dữ liệu vào phiên làm việc (Session)
            HttpContext.Session.SetString("mitom2trung", message);
            // Đọc dữ liệu ra từ Session
            var sessionData = HttpContext.Session.GetString("mitom2trung");
            ViewData["data"] = sessionData;
            /*
             * Timeout của session được tính như thế nào:
             * Khi Session đã tồn tại, Bộ đếm thời gian sẽ được kích hoạt 
             * ngay sau khi request cuối cùng được thực thi. Nếu sau khoảng
             * thời gian idleTimeout mà không có request nào được thực thi
             * thì dữ liệu đó sẽ mất. Nếu trước khi thời gian timeout kết
             * thúc mà có 1 request bất kì được thực thi thì bộ đếm thời 
             * gian sẽ được reset
             */
            return View();
        }
        // add sản phẩm vào giỏ hàng ảo




  





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//id = item.Id 