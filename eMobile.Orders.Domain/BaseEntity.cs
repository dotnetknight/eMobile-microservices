using System;

namespace eMobile.Orders.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
