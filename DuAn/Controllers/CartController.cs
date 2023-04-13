using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace DuAn.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartDetailsServices _cartDetailsServices;
        private readonly IProductServices _productServices;
        private readonly ICartServices _cartServices;

        public CartController() {

            _cartServices = new CartServices();
            _cartDetailsServices = new CartDetailsServices();
            _productServices = new ProductServices();

        }
        public IActionResult Index()
        {
            return View();
        }



        //show Cart
        public ActionResult ShowAllCart()
        {

            List<Cart> carts = _cartServices.GetAllCarts();
         
            return View(carts); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }

        //show CartDetails

        public IActionResult ShowallCartDetails()
        {
            // Trong phương thức Create
            var userIdString = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out var userId))
            {
                var listCartDetails =  _cartDetailsServices.GetAllCartDetailss();
                ViewBag.listCartDetails = listCartDetails.Where(c => c.UserId == userId).ToList();
                ViewBag.listProduct =  _productServices.GetAllProducts();

                // Tiếp tục sử dụng giá trị userId (kiểu Guid) trong phương thức Create


            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }
        #region show ao
        //show CartDetails ảo
        //public IActionResult ShowCartao()
        //{
        //    // Lấy dữ liệu từ Session để truyền vào View
        //    //Đoạn mã này dùng để lấy dữ liệu giỏ hàng từ session và truyền vào view để hiển thị các sản phẩm trong giỏ hàng

        //    var cartdetail = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");       
        //    ViewBag.cart = cartdetail;
        //    ViewBag.total = cartdetail.Sum(c => c.Product.Price * c.Quantity);
        //    return View();// Truyền sang view



        //}


        #endregion

        #region theemgiohangsession

        //public IActionResult AddToCart(Guid idsp, Guid userid)// Sử dụng Session
        //{

        //    // B1: Dựa vào ID lấy ra sản phẩm
        //    var product = _productServices.GetProductById(idsp);

        //    //B2: Lấy danh sách sản phẩm ra từ Session

        //    var cartdetails = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");
        //    var newcartDetails = new CartDetails
        //    {
        //        Id = Guid.NewGuid(),
        //        UserId = userid,
        //        IdSP = product.Id,
        //        Quantity = 1,
        //        Product = product,

        //    };


        //    if (cartdetails.Count == 0) // Trong trường hợp mà list rỗng
        //    {

        //        cartdetails.Add(newcartDetails);
        //        SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);

        //    }
        //    else
        //    {
        //        if (SessionCartServices.CheckObjInList(idsp, cartdetails))
        //        {
        //            //Tìm kiếm sản phẩm có trong giỏ hàng và cập nhật số lượng
        //            foreach (var p in cartdetails)
        //            {
        //                if (p.IdSP == idsp)
        //                {
        //                    p.Quantity++;
        //                    break;
        //                }
        //            }
        //            SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);

        //            //return Content("Bình thường sẽ + số lượng nhưng tôi không thích thế");
        //        }
        //        else
        //        { // Nếu sp chưa tồn tại trong giỏ hàng thì thêm như
        //          // bth
        //            cartdetails.Add(newcartDetails);
        //            SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);


        //        }
        //    }



        //    // B3: Kiểm tra và thêm SP vào giỏ hàng
        //    return RedirectToAction("ShowCartao");
        //}

        ////xóa sản phẩm khỏi giỏ hàng theo idsp
        //public IActionResult RemoveCart(Guid idsp)
        //{
        //    // Lấy danh sách sản phẩm trong giỏ hàng từ Session
        //    var cartdetails = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");

        //    // Tìm kiếm sản phẩm có trong giỏ hàng theo idsp
        //    var productToRemove = cartdetails.FirstOrDefault(p => p.IdSP == idsp);

        //    if (productToRemove != null)
        //    {
        //        // Xóa sản phẩm khỏi giỏ hàng
        //        cartdetails.Remove(productToRemove);
        //        SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);
        //    }

        //    return RedirectToAction("ShowCartao");
        //}
        ////ClearSessio giỏ hàng 
        //public IActionResult RemoveAllCart()
        //{

        //    SessionCartServices.ClearSessio(HttpContext.Session);//remove session           
        //    return RedirectToAction("ShowCartao");




        //}


        #endregion

        public IActionResult CreateCartDetails(Guid idsp)
        {

            // Trong phương thức Create
            var userIdString = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out var userId))
            {
                //tạo giỏ hàng ở login r




                var newcar = new Cart()
                {

                    UserId = userId,
                    Description = "giỏ hàng khách hàng",


                };


                _cartServices.CreateCart(newcar);






                List<CartDetails> cartDetails = _cartDetailsServices.GetAllCartDetailss().Where(c => c.UserId == userId).ToList();
                //tạo giỏ hàng ct
                CartDetails obj = new()
                {
                    UserId = userId,
                    IdSP = idsp,
                    Quantity = 1

                };

                if (cartDetails.Any(c => c.UserId == userId && c.IdSP == idsp))
                {
                    obj.Quantity = cartDetails.FirstOrDefault(c => c.UserId == userId && c.IdSP == idsp).Quantity + 1;
                    return _cartDetailsServices.UpdateCartDetails(obj.IdSP, obj.UserId, obj) ? RedirectToAction("ShowallCartDetails") : BadRequest();
                }
                else
                {
                    return _cartDetailsServices.CreateCartDetails(obj) ? RedirectToAction("ShowallCartDetails") : BadRequest();
                }


                // Tiếp tục sử dụng giá trị userId (kiểu Guid) trong phương thức Create
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            

        }



        public IActionResult DeleteCartDetails(Guid id)
        {

            // Trong phương thức Create
            var userIdString = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out var userId))
            {
           
                return _cartDetailsServices.DeleteCartDetails(id, userId) ? RedirectToAction("ShowallCartDetails") : BadRequest();


                // Tiếp tục sử dụng giá trị userId (kiểu Guid) trong phương thức Create
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }


        }
































    }
}
