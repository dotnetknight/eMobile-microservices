using eMobile.Phones.Models.Models;
using System.Collections.Generic;

namespace eMobile.Phones.Models.Responses
{
    public class PhonesQueryResponse : BaseResponse
    {
        public IEnumerable<PhoneDto> Phones { get; set; }
    }
}
