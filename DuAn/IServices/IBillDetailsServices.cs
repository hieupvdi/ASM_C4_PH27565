using DuAn.Models;

namespace DuAn.IServices
{
    public interface IBillDetailsServices
    {
        public bool CreateBillDetails(BillDetails p);
        public bool UpdateBillDetails(BillDetails p);
        public bool DeleteBillDetails(Guid id);
        public List<BillDetails> GetAllBillDetailss();
        public BillDetails GetBillDetailsById(Guid id);
        public List<BillDetails> GetBillDetailsByHB(Guid idhd);
        
    }
}
