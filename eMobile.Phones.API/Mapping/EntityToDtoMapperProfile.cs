using AutoMapper;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Models;

namespace eMobile.Phones.API.Mapping
{
    public class EntityToDtoMapperProfile : Profile
    {
        public EntityToDtoMapperProfile()
        {
            CreateMap<Phone, PhoneDto>();
        }
    }
}
