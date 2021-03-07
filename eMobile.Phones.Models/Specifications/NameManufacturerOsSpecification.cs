using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Interfaces;

namespace eMobile.Phones.Models.Specifications
{
    public class SearchByNameManufacturerOs : ISpecification<Phone>
    {
        private readonly ISpecification<Phone> nameSpecification;
        private readonly ISpecification<Phone> osSpecification;
        private readonly ISpecification<Phone> manufacturerSpecification;

        public SearchByNameManufacturerOs(
            ISpecification<Phone> nameSpecification,
            ISpecification<Phone> osSpecification,
            ISpecification<Phone> manufacturerSpecification)
        {
            this.nameSpecification = nameSpecification;
            this.osSpecification = osSpecification;
            this.manufacturerSpecification = manufacturerSpecification;
        }

        public bool IsSatisfied(Phone phone)
        {
            return
                nameSpecification.IsSatisfied(phone) ||
                osSpecification.IsSatisfied(phone) ||
                manufacturerSpecification.IsSatisfied(phone);
        }
    }
}
