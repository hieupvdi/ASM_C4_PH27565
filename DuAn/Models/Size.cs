namespace DuAn.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public int Kichthuoc { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
