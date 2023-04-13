using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class BillDetailConfigurations : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("HoaDonCT");
            builder.HasKey(P=>P.Id);
            builder.Property(p=>p.Quantity).HasColumnType("int").IsRequired();
            //sét khóa ngoại
            builder.HasOne(p=>p.Bill).WithMany(p=>p.BillDetails)
                .HasForeignKey(p=>p.IdHD);
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetails)
              .HasForeignKey(p => p.IdSP);
        }
    }
}
