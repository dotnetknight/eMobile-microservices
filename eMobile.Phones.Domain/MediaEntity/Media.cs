using eMobile.Phones.Domain.PhonesEntity;
using System;

namespace eMobile.Phones.Domain.MediaEntity
{
    public class Media : BaseEntity
    {
        public Phone Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string VideoUrl { get; set; }
        public Guid PhoneId { get; set; }
    }
}
