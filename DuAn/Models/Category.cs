namespace DuAn.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
