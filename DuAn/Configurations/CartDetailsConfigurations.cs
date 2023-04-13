using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;
namespace DuAn.Configurations
{
    public class CartDetailsConfigurations : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.ToTable("GioHangCT");
            builder.HasKey(P =>  P.Id );
          //  builder.Property(p => p.Quantity).HasColumnType("int").IsRequired();
            //sét khóa ngoại
            builder.HasOne(p => p.Cart).WithMany(p => p.CartDetails)
                .HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Product).WithMany(p => p.CartDetails)
              .HasForeignKey(p => p.IdSP);
        }
    }
}
