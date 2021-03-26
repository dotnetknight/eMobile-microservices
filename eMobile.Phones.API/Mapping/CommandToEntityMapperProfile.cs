using AutoMapper;
using eMobile.Phones.Domain.DimensionsEntity;
using eMobile.Phones.Domain.DisplayEntity;
using eMobile.Phones.Domain.MediaEntity;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Commands;

namespace eMobile.Phones.API.Mapping
{
    public class CommandToEntityMapperProfile : Profile
    {
        public CommandToEntityMapperProfile()
        {
            CreateMap<CreatePhoneCommand, Phone>();
            CreateMap<Phone, UpdatePhoneCommand>();
            CreateMap<UpdatePhoneCommand, Phone>();

            CreateMap<PhoneMedia, Media>();
            CreateMap<PhoneDisplay, Display>();
            CreateMap<PhoneDimensions, Dimensions>();
        }
    }
}
