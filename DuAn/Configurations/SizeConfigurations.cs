using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DuAn.Models;

namespace DuAn.Configurations
{
    public class SizeConfigurations : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {

            builder.HasKey(p =>  p.Id );//thiết lập khóa chính
          

        }
    }
}
