using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("ChucVu");//đặt tên bảng sql
            builder.HasKey(p => p.Id );//thiết lập khóa chính
            builder.Property(p => p.RoleName).HasColumnType("varchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
        }
    }
}
