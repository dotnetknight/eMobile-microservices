using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Orders.Domain.OrdersEntity
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.HasOne(t => t.ShippingAddress);

            entityBuilder.HasOne(t => t.Phone)
               .WithOne(a => a.Order)
               .HasForeignKey<Order>(ad => ad.PhoneId);
        }
    }
}