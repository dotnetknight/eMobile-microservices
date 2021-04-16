using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Orders.Domain.ShippingAddressEntity
{
    public class ShippingAddressMap
    {
        public ShippingAddressMap(EntityTypeBuilder<ShippingAddress> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.HasOne(t => t.Order)
                .WithOne(a => a.ShippingAddress)
                .HasForeignKey<ShippingAddress>(ad => ad.OrderId);
        }
    }
}
