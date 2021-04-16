using eMobile.Orders.Models.Models;
using System.Collections.Generic;

namespace eMobile.Orders.Models.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
