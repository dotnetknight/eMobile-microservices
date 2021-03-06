using System;

namespace eMobile.Phones.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
