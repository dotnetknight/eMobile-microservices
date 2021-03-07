using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Interfaces;
using System.Collections.Generic;

namespace eMobile.Phones.Service.Filters
{
    public class FilterPhones : IFilter<Phone>
    {
        public IEnumerable<Phone> Filter(IEnumerable<Phone> phones, ISpecification<Phone> specification)
        {
            foreach (var phone in phones)
                if (specification.IsSatisfied(phone))
                    yield return phone;
        }
    }
}
