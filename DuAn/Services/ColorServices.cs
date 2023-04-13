using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class ColorServices : IColorServices
    {
        ShopDbContext Context;
        public ColorServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateColor(Color p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Colors.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic Color = Context.Colors.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.Colors.Remove(Color);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Color> GetAllColors()
        {
            return Context.Colors.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public Color GetColorById(Guid id)
        {
            return Context.Colors.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<Color> GetColorByName(string name)
        {
            return Context.Colors.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateColor(Color p)
        {
            try
            {

                var Color = Context.Colors.Find(p.Id);
                Color.Name = p.Name;
                Color.Status = p.Status;
                //cos the them thuoc tinh
                Context.Colors.Update(Color);
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
