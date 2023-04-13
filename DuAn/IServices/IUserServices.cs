using DuAn.Models;

namespace DuAn.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User p);
        public bool UpdateUser(User p);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUserByName(string name);
        public User GetUserUserName(string Username);
    }
}
