using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Interfaces;

namespace eMobile.Phones.Models.Specifications
{
    public class OsSpecification : ISpecification<Phone>
    {
        private readonly string os;

        public OsSpecification(string os)
        {
            this.os = os;
        }

        public bool IsSatisfied(Phone phone)
        {
            return phone.OS
                .ToLower()
                .Contains(os.ToLower());
        }
    }
}
