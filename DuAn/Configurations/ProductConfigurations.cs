using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("SanPham");//đặt tên bảng sql
            builder.HasKey(p =>  p.Id );//thiết lập khóa chính
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");

            builder.Property(p => p.Supplier).HasColumnType("nvarchar(100)");
            //builder.Property(p => p.Supplier).IsUnicode(true).IsFixedLength().HasMaxLength(100);//navchar(100)


            builder.HasOne(p => p.Category).WithMany(p => p.Product).HasForeignKey(p => p.CategoryId);
            builder.HasOne(p => p.Color).WithMany(p => p.Product).HasForeignKey(p => p.ColorId);
            builder.HasOne(p => p.Size).WithMany(p => p.Product).HasForeignKey(p => p.SizeId);
        }
    }
}
