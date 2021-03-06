using System;

namespace eMobile.Phones.Models.Responses
{
    public class CreatePhoneCommandResponse : BaseResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}
