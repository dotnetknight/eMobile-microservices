using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Interfaces;

namespace eMobile.Phones.Models.Specifications
{
    public class ManufacturerSpecification : ISpecification<Phone>
    {
        private readonly string manufacturer;

        public ManufacturerSpecification(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public bool IsSatisfied(Phone phone)
        {
            return phone.Manufacturer
                .ToLower()
                .Contains(manufacturer.ToLower());
        }
    }
}
