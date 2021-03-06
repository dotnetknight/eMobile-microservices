namespace eMobile.Phones.Models.Exceptions
{
    public class PhoneNotFound : BaseApiException
    {
        public override string Message { get; }

        public PhoneNotFound(string message) : base(System.Net.HttpStatusCode.NotFound)
        {
            Message = message;
        }
    }
}
