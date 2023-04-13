using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAdminController : Controller
    {
        private readonly IProductServices productServices;// Interface
        public ProductAdminController()
        {
            productServices = new ProductServices(); // DI
        }
        public IActionResult Index()
        {
            return View();
        }


        //show sản phẩm
        public ActionResult ShowAllProduct()
        {

            List<Product> products = productServices.GetAllProducts();
            return View(products); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }
    

   










        //thêm sửa xóa Product
        public IActionResult CreateProduct() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product p, IFormFile LinkAnh)
        {

            // Lưu file ảnh vào thư mục "wwwroot/images"
            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                p.LinkAnh = "/images/" + fileName;
            }

            if (productServices.CreateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        public IActionResult DetailProducts(Guid id)
        {
            var Products = productServices.GetProductById(id);
            return View(Products);
        }
        public IActionResult DeleteProduct(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditProduct(Guid id)
        {

            var products = productServices.GetProductById(id);
            return View(products);

        }

        public IActionResult EditProduct(Product p, IFormFile LinkAnh)
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

            if (productServices.UpdateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else
            {
                return BadRequest();
            }

        }


  

       
    }
}
