using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Phones.Domain.DisplayEntity
{
    public class DisplayMap
    {
        public DisplayMap(EntityTypeBuilder<Display> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.HorizontalResolution).IsRequired();
            entityBuilder.Property(p => p.VerticalResolution).IsRequired();
            entityBuilder.Property(p => p.Size).IsRequired();
        }
    }
}
