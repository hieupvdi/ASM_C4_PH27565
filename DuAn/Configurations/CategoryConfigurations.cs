using DuAn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAn.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);//thiết lập khóa chính
            builder.Property(p => p.Status).HasColumnType("int")
            .IsRequired();//int not null
        }
    }
}
