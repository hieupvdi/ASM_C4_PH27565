using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("GioHang");//đặt tên bảng sql
            builder.HasKey(p => p.UserId);//thiết lập khóa chính
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
                
        }
    }
}
