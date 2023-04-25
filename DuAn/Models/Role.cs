using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
    public class Role
    {
       
       
        public Guid Id { get; set; }
        [Required]    
        public string RoleName { get; set; }
        [Required]          
        public   string Description { get; set; }
        [Required]
        public int Status { get; set; }
        public virtual List<User> Users { get; set; }
        //public ICollection<User> User { get; set; }
    }
}
