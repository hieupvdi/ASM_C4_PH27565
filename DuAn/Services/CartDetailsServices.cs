using DuAn.IServices;
using DuAn.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace DuAn.Services
{
    public class CartDetailsServices : ICartDetailsServices
    {
        ShopDbContext Context;
        public CartDetailsServices()
        {
            Context = new ShopDbContext();

        }

        public bool CreateCartDetails(CartDetails p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.CartDetailss.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
        
        public bool DeleteCartDetails(Guid id,Guid userid)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic cartdetailss = Context.CartDetailss.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.CartDetailss.Remove(cartdetailss);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<CartDetails> GetAllCartDetailss()
        {
            var list = Context.CartDetailss.ToList();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public CartDetails GetCartDetailsById(Guid idsp, Guid userid)
        {
            var list =  Context.CartDetailss.ToList();
            var obj = list.FirstOrDefault(c => c.UserId == userid && c.IdSP == idsp);
            if (obj == null)
            {
                return new CartDetails();
            }
            return obj;
        }

        public List<CartDetails> GetCartDetailsByName(Guid userid)
        {
            var list = Context.CartDetailss.ToList();
            if (list == null)
            {
                return new();
            }

            list = list.Where(c => c.UserId == userid).ToList();
            return list;
        }

        public bool UpdateCartDetails(Guid idsp, Guid userid, CartDetails obj)
        {
            try
            {
                var listObj = Context.CartDetailss.ToList();
                var cartdetails = listObj.FirstOrDefault(c => c.UserId == userid && c.IdSP == idsp);

                cartdetails.Quantity = obj.Quantity;


                Context.CartDetailss.Update(cartdetails);
                Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
