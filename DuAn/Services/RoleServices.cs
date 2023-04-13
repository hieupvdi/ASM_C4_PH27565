using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class RoleServices : IRoleServices
    {
        ShopDbContext Context;
        public RoleServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateRole(Role p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Roles.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic Role = Context.Roles.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.Roles.Remove(Role);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Role> GetAllRoles()
        {
            return Context.Roles.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public Role GetRoleById(Guid id)
        {
            return Context.Roles.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<Role> GetRoleByName(string name)
        {
            return Context.Roles.Where(p => p.RoleName.Contains(name)).ToList();
        }

        public bool UpdateRole(Role p)
        {
            try
            {

                var Role = Context.Roles.Find(p.Id);
                Role.RoleName = p.RoleName;
                Role.Description = p.Description;
                Role.Status = p.Status;
                //cos the them thuoc tinh
                Context.Roles.Update(Role);
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
