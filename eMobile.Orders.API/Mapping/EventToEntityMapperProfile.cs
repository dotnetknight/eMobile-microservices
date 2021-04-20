using AutoMapper;
using eMobile.Orders.Domain.DimensionsEntity;
using eMobile.Orders.Domain.DisplayEntity;
using eMobile.Orders.Domain.MediaEntity;
using eMobile.Orders.Domain.OrdersEntity;
using eMobile.Orders.Domain.PhonesEntity;
using eMobile.Orders.Models.Dtos;
using eMobile.Orders.Models.Events;

namespace eMobile.Orders.API.Mapping
{
    public class EventToEntityMapperProfile : Profile
    {
        public EventToEntityMapperProfile()
        {
            CreateMap<PhoneCreatedEvent, Order>();
            CreateMap<PhoneCreatedEvent, Phone>();

            CreateMap<PhoneMedia, Media>();
            CreateMap<PhoneDisplay, Display>();
            CreateMap<PhoneDimensions, Dimensions>();
        }
    }
}
