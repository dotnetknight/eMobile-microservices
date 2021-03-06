using System;
using System.Net;

namespace eMobile.Phones.Models.Exceptions
{
    public class BaseApiException : Exception
    {
        public int HttpStatusCode { get; set; }
        public string ServerMessage { get; set; }

        public BaseApiException(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = (int)httpStatusCode;
        }

        public BaseApiException(HttpStatusCode httpStatusCode, string message)
        {
            HttpStatusCode = (int)httpStatusCode;
            ServerMessage = message;
        }
    }
}
