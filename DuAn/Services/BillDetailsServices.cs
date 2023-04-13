using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class BillDetailsServices : IBillDetailsServices
    {
        ShopDbContext Context;
        public BillDetailsServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateBillDetails(BillDetails p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.BillDetailss.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteBillDetails(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic BillDetails = Context.BillDetailss.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.BillDetailss.Remove(BillDetails);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<BillDetails> GetAllBillDetailss()
        {
            return Context.BillDetailss.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public BillDetails GetBillDetailsById(Guid id)
        {
            return Context.BillDetailss.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<BillDetails> GetBillDetailsByHB(Guid idhd)
        {
            var list = Context.BillDetailss.ToList();
            if (list == null)
            {
                return new();
            }
            //list = list.Where(c => c.UserId == userid && c.Status != 1).ToList();
            list = list.Where(c => c.IdHD == idhd).ToList();
            return list;
        }

        public bool UpdateBillDetails(BillDetails p)
        {
            try
            {
   
                var BillDetails = Context.BillDetailss.Find(p.Id);
                BillDetails.Quantity = p.Quantity;
                BillDetails.Price = p.Price;
               
                //cos the them thuoc tinh
                Context.BillDetailss.Update(BillDetails);
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
