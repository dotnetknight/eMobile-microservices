using eMobile.Phones.Models.Models;
using System.Collections.Generic;

namespace eMobile.Phones.Models.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
