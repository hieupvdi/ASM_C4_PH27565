using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class SizeServices : ISizeServices
    {
        ShopDbContext Context;
        public SizeServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateSize(Size p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Sizes.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic Size = Context.Sizes.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.Sizes.Remove(Size);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Size> GetAllSizes()
        {
            return Context.Sizes.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public Size GetSizeById(Guid id)
        {
            return Context.Sizes.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<Size> GetSizeByName(string name)
        {
            //return Context.Product.Where(p => p.Name.Contains(name)).ToList();
            throw new NotImplementedException();

        }

        public bool UpdateSize(Size p)
        {
            try
            {

                var Size = Context.Sizes.Find(p.Id);
                Size.Kichthuoc = p.Kichthuoc;
                Size.Status = p.Status;
              
                //cos the them thuoc tinh
                Context.Sizes.Update(Size);
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
