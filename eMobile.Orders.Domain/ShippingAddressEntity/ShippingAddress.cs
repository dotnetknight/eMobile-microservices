using eMobile.Orders.Domain.OrdersEntity;
using System;

namespace eMobile.Orders.Domain.ShippingAddressEntity
{
    public class ShippingAddress : BaseEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
