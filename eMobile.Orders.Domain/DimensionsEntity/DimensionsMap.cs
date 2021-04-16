using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Orders.Domain.DimensionsEntity
{
    public class DimensionsMap
    {
        public DimensionsMap(EntityTypeBuilder<Dimensions> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Height).IsRequired();
            entityBuilder.Property(p => p.Width).IsRequired();
            entityBuilder.Property(p => p.Length).IsRequired();
        }
    }
}
