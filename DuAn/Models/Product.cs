namespace DuAn.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LinkAnh { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
    
        public string Supplier { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }
  

        public int Status { get; set; }

        //QUAN HE
        public virtual ICollection<BillDetails> BillDetails { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
      

    }
}
