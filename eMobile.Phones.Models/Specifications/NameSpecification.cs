using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Interfaces;

namespace eMobile.Phones.Models.Specifications
{
    public class NameSpecification : ISpecification<Phone>
    {
        private readonly string name;

        public NameSpecification(string name)
        {
            this.name = name;
        }

        public bool IsSatisfied(Phone phone)
        {
            return phone.Name
                .ToLower()
                .Contains(name.ToLower());
        }
    }
}
