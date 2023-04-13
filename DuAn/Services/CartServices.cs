using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class CartServices : ICartServices
    {
        ShopDbContext Context;
        public CartServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateCart(Cart p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Carts.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic Cart = Context.Carts.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.Carts.Remove(Cart);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Cart> GetAllCarts()
        {
            return Context.Carts.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public Cart GetCartById(Guid id)
        {
            return Context.Carts.FirstOrDefault(p => p.UserId == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<Cart> GetCartByName(string name)
        {
            //return Context.Product.Where(p => p.Name.Contains(name)).ToList();
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart p)
        {
            try
            {

                var Cart = Context.Carts.Find(p.UserId);
                Cart.Description = p.Description;
               
                //cos the them thuoc tinh
                Context.Carts.Update(Cart);
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
