using eMobile.Common.Query;
using System;

namespace eMobile.Phones.Models.Queries
{
    public class PhoneQuery : IQuery
    {
        public Guid Id { get; set; }

        public PhoneQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
