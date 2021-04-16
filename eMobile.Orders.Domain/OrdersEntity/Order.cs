using eMobile.Orders.Domain.PhonesEntity;
using eMobile.Orders.Domain.ShippingAddressEntity;
using System;

namespace eMobile.Orders.Domain.OrdersEntity
{
    public class Order : BaseEntity
    {
        public Phone Phone { get; set; }
        public int Quantity { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public Guid PhoneId { get; set; }
    }
}
