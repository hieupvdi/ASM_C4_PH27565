using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillAdminController : Controller
    {
        public readonly IBillServices _billServices;
        public readonly IBillDetailsServices _billDetailsServices;
        public readonly IProductServices _productServices;
        public BillAdminController()
        {
            _billServices= new BillServices();
            _billDetailsServices = new BillDetailsServices();
            _productServices= new ProductServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAllBill()
        {

            List<Bill> bills = _billServices.GetAllBills();
            return View(bills); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }


        public ActionResult ShowAllBillDetails(Guid idhd)
        {
                                  
            var listbillDetails = _billDetailsServices.GetBillDetailsByHB(idhd);
            var listbill = _billServices.GetAllBills();
            var listProduct = _productServices.GetAllProducts();

            ViewBag.listbillDetails = listbillDetails;
            ViewBag.listbill = listbill;
            ViewBag.listProduct = listProduct;


            return View();// Truyền trực tiếp 1 Obj Model duy nhất sang View

        }
    }
}
