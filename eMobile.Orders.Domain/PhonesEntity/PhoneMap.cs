using eMobile.Orders.Domain.DimensionsEntity;
using eMobile.Orders.Domain.DisplayEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Orders.Domain.PhonesEntity
{
    public class PhoneMap
    {
        public PhoneMap(EntityTypeBuilder<Phone> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.HasMany(t => t.Media)
                .WithOne(d => d.Phone)
                .HasForeignKey(x => x.PhoneId);

            entityBuilder.HasOne(t => t.Dimensions)
               .WithOne(d => d.Phone)
               .HasForeignKey<Dimensions>(ad => ad.PhoneId);

            entityBuilder.HasOne(t => t.Display)
               .WithOne(d => d.Phone)
               .HasForeignKey<Display>(ad => ad.PhoneId);

            entityBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(p => p.Manufacturer)
                .IsRequired()
                .HasMaxLength(30);

            entityBuilder.Property(p => p.Weight).IsRequired();
            entityBuilder.Property(p => p.CPUModel).IsRequired();
            entityBuilder.Property(p => p.RAM).IsRequired();
            entityBuilder.Property(p => p.Price).IsRequired();

            entityBuilder.Property(p => p.OS).HasMaxLength(7);
        }
    }
}
