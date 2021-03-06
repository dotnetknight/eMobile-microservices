using eMobile.Phones.Models.Models;
using System.Collections.Generic;

namespace eMobile.Phones.Models.Responses
{
    public class BaseResponse
    {
        public IEnumerable<LinkModel> Links { get; set; } = null;
    }
}
