using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class ColorConfigurations : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {

            builder.HasKey(p =>  p.Id );//thiết lập khóa chính
            builder.Property(p => p.Status).HasColumnType("int")
            .IsRequired();//int not null

        }
    }
}
