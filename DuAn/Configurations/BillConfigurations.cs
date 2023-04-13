using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("HoaDon");//đặt tên bảng sql
            builder.HasKey(p => new{ p.Id});//thiết lập khóa chính
            builder.Property(p=>p.Status).HasColumnType("int")
                .IsRequired();//int not null
            builder.HasOne(p => p.User).WithMany(p => p.Bill).HasForeignKey(p => p.UserId);
        }
    }
}
