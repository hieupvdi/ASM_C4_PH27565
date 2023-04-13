using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillServices _billServices;// Interface
        private readonly IBillDetailsServices _billDetailsServices;// Interface
        public readonly IProductServices _productServices;
        public readonly ICartServices _cartServices;
        public readonly ICartDetailsServices _cartDetailsServices;
        public BillController()
        {
            _billServices = new BillServices();
            _billDetailsServices = new BillDetailsServices();
            _productServices=new ProductServices();
            _cartServices=new CartServices();
            _cartDetailsServices=new CartDetailsServices();
        }
        public IActionResult Index()
        {
            return View();
        }

        //show Bill =>
        public ActionResult ShowAllBill()
        {
            var userIdString = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out var userId))
            {
                var listBill =  _billServices.GetBillByUser(userId);
                var listProductBill = _billDetailsServices.GetAllBillDetailss();
                var listProduct =  _productServices.GetAllProducts();

                ViewBag.listBill = listBill;
                ViewBag.listProductBill = listProductBill;
                ViewBag.listProduct = listProduct;
            }
                //List<Bill> bills = _billServices.GetAllBills();
            return View(); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }


        //show show Bill => Bill BillDetail
        //DANG lỗi 
        public ActionResult ShowAllBillDetails(Guid idhd)
        {
            var listbillDetails = _billDetailsServices.GetBillDetailsByHB(idhd);
            var listbill = _billServices.GetAllBills();
            var listProduct = _productServices.GetAllProducts();

            ViewBag.listbillDetails = listbillDetails;
            ViewBag.listbill = listbill;
            ViewBag.listProduct = listProduct;



    
            
            return View();

            //List<BillDetails> billdetails = _billDetailsServices.GetAllBillDetailss();
            //return View(billdetails); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }




        //them sua xoa



        public IActionResult CreateBill(string customername, int  sdt,string diachi,int Status)
        {
            var userIdString = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out var userId))
            {

                // Tạo 1 hóa đơn mới cho người dùng nhập tin để giao hàng
                Bill objBill = new()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CustomerName = customername,
                    Sdt = sdt,
                    Diachi=diachi,
                    Status = Status,
                    CreateDate = DateTime.Now,  
                };
                var resultCreateBill = _billServices.CreateBill(objBill);
                var resultCreateProductBill = false;

                int countError = 0;// đếm những sản phẩm không thêm được thành công vào hóa đơn

                List<CartDetails> listCartDetails = _cartDetailsServices.GetCartDetailsByName(userId);
                var listProduct = _productServices.GetAllProducts();

                // Nếu tạo hóa đơn thành công
                if (resultCreateBill)
                {
                    // Tạo các sản phẩm trong hóa đơn = các sản phẩm trong giỏ hàng
                    foreach (var item in listCartDetails)
                    {
                        BillDetails billdetails = new BillDetails()
                        {
                    
                            IdSP = item.IdSP,
                            IdHD = objBill.Id,
                            Quantity = item.Quantity,
                            Price = listProduct.FirstOrDefault(c => c.Id == item.IdSP).Price,

                         
                        };

                          _billDetailsServices.CreateBillDetails(billdetails);
                        if (!resultCreateProductBill)
                        {
                            countError++;
                        }

                    }
                    // Xóa các sản phẩm trong giỏ hàng
                    foreach (var cartDetails in listCartDetails)
                    {
                         _cartDetailsServices.DeleteCartDetails(cartDetails.IdSP, cartDetails.UserId);
                    }
                    if (countError == 0)
                    {
                        //return RedirectToAction("ShowAllBillDetails");
                        return RedirectToAction("ShowAllBillDetails", new { idhd = objBill.Id });
                    }
                

                }
                return RedirectToAction("ShowAllBill");



            }
            else
            {
                return RedirectToAction("ShowallCartDetails", "Cart");
            }
             
        }
        //lỗi k  xóa mền đ
        public IActionResult DeleteBill(Guid idhd) 
        {
            // Xóa hóa đơn (Xóa mềm: Thay đổi trạng thái thành "Đã hủy") | số 0 thanh toán khi nhận hàng | số 1 ATM | số 2 đã hủy |
             _billServices.DeleteBill(idhd);

            return RedirectToAction("ShowAllBill");
        }





    }
}
