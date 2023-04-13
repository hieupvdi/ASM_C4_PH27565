using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class CategoryServices : ICategoryServices
    {
        ShopDbContext Context;

        public  CategoryServices()
        {
            Context = new ShopDbContext();
        }
        public bool CreateCategory(Category p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Categorys.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteCategory(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic Category = Context.Categorys.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.Categorys.Remove(Category);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Category> GetAllCategorys()
        {
            return Context.Categorys.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public Category GetCategoryById(Guid id)
        {
            return Context.Categorys.FirstOrDefault(p => p.Id == id);
        }

        public List<Category> GetCategoryByName(string name)
        {
            return Context.Categorys.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateCategory(Category p)
        {
            try
            {

                var Category = Context.Categorys.Find(p.Id);
                Category.Name = p.Name;
                Category.Status = p.Status;

                //cos the them thuoc tinh
                Context.Categorys.Update(Category);
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
