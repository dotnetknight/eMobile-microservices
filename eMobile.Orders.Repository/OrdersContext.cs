using Microsoft.EntityFrameworkCore;
using eMobile.Orders.Domain.PhonesEntity;
using eMobile.Orders.Domain.DisplayEntity;
using eMobile.Orders.Domain.DimensionsEntity;
using eMobile.Orders.Domain.MediaEntity;
using eMobile.Orders.Domain.ShippingAddressEntity;
using eMobile.Orders.Domain.OrdersEntity;

namespace eMobile.Orders.Repository
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PhoneMap(modelBuilder.Entity<Phone>());
            new DisplayMap(modelBuilder.Entity<Display>());
            new DimensionsMap(modelBuilder.Entity<Dimensions>());
            new MediaMap(modelBuilder.Entity<Media>());
            new ShippingAddressMap(modelBuilder.Entity<ShippingAddress>());
            new OrderMap(modelBuilder.Entity<Order>());
        }
    }
}
