using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class BillServices : IBillServices
    {
        ShopDbContext Context;
        public BillServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateBill(Bill p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Bills.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteBill(Guid id)//Số mền trạng thái 3
        {
            try
            {
                var listObj =  Context.Bills.ToList();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 3;

             
                Context.Bills.Update(obj);
                Context.SaveChanges();
                return true;

               
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return Context.Bills.ToList();
            //laays data chi loi code hoac loi ket noi sql  throw new NotImplementedException();
        }

        public Bill GetBillById(Guid id)
        {
            return Context.Bills.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<Bill> GetBillByUser(Guid userid)
        {
            var list =  Context.Bills.ToList();
            if (list == null)
            {
                return new();
            }
            //list = list.Where(c => c.UserId == userid && c.Status != 1).ToList();
            list = list.Where(c => c.UserId == userid).ToList();
            return list;
        }

        public bool UpdateBill(Bill p)
        {
            try
            {

                var Bill = Context.Bills.Find(p.Id);
                Bill.CustomerName=p.CustomerName;
                Bill.Sdt = p.Sdt;
                Bill.Diachi=p.Diachi;
                Bill.Status = p.Status;
                //cos the them thuoc tinh
                Context.Bills.Update(Bill);
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
