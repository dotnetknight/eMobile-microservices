using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Orders.Domain.MediaEntity
{
    public class MediaMap
    {
        public MediaMap(EntityTypeBuilder<Media> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.PhotoUrl).IsRequired();
            entityBuilder.Property(p => p.VideoUrl).IsRequired();
        }
    }
}
