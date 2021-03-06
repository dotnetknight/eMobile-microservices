using eMobile.Common.Query;
using System;

namespace eMobile.Phones.Models.Queries
{
    public class PhoneQuery : IQuery
    {
        public Guid PhoneId { get; set; }

        public PhoneQuery(Guid phoneId)
        {
            PhoneId = phoneId;
        }
    }
}
