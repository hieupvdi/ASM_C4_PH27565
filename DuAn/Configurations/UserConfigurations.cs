using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;


namespace DuAn.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("NguoiDung");
            builder.HasKey(P =>  P.Id);
          
            builder.Property(p => p.Username).HasColumnType("varchar(256)");
            builder.Property(p => p.Password).HasColumnType("varchar(256)");
            //sét khóa ngoại
            builder.HasOne(p => p.Role).WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleId);
            builder.HasAlternateKey(p => p.Username);//Unique

        }
    }
}
