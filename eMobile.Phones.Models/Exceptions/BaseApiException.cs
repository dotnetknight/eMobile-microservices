using System;
using System.Net;

namespace eMobile.Phones.Models.Exceptions
{
    public class BaseApiException : Exception
    {
        public HttpStatusCode ResponseHttpStatusCode { get; set; }

        public string BackEndMessage { get; set; }
    }
}
