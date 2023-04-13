namespace DuAn.Models
{
    public class Bill
    {

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public string CustomerName { get; set; }
        public int Sdt { get; set; }
        public string Diachi { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BillDetails> BillDetails { get; set; }
      
    }
}
