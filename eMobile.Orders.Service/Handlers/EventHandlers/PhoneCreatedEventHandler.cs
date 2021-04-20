using AutoMapper;
using Common.Events;
using eMobile.Orders.Domain.PhonesEntity;
using eMobile.Orders.Models.Events;
using eMobile.Orders.Models.Exceptions;
using eMobile.Orders.Repository;
using System;
using System.Threading.Tasks;

namespace eMobile.Orders.Service.Handlers.EventHandlers
{
    public class PhoneCreatedEventHandler : IEventHandler<PhoneCreatedEvent>
    {
        #region Properties
        private readonly IRepository<Phone> ordersRepository;
        private readonly IMapper mapper;

        #endregion

        #region Constructor
        public PhoneCreatedEventHandler(
            IRepository<Phone> ordersRepository,
            IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        #endregion

        public Task Handle(PhoneCreatedEvent @event)
        {
            try
            {
                Guid phoneId = Guid.NewGuid();

                var mappedPhone = mapper.Map<Phone>(@event);

                mappedPhone.Id = phoneId;
                mappedPhone.AddedDate = DateTime.Now;

                mappedPhone.Dimensions.Id = Guid.NewGuid();
                mappedPhone.Display.Id = Guid.NewGuid();
                mappedPhone.Media.ForEach(media => media.Id = Guid.NewGuid());

                ordersRepository.Insert(mappedPhone);

                ordersRepository.CommitTransaction();

                return Task.CompletedTask;
            }

            catch (Exception ex)
            {
                ordersRepository.RollbackTransaction();

                throw new BaseApiException(System.Net.HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
