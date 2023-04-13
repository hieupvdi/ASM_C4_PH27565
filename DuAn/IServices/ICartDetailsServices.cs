using DuAn.Models;

namespace DuAn.IServices
{
    public interface ICartDetailsServices
    {
        public bool CreateCartDetails(CartDetails p);
        public bool UpdateCartDetails(Guid idsp, Guid userid, CartDetails obj);
        public bool DeleteCartDetails(Guid id,Guid userid);
        public List<CartDetails> GetAllCartDetailss();
        public CartDetails GetCartDetailsById(Guid idsp, Guid userid);
        public List<CartDetails> GetCartDetailsByName(Guid userid);
    }
}
