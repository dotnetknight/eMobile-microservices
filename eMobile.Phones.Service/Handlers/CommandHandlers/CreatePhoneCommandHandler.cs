using AutoMapper;
using Common.Bus.CQRS;
using Common.Bus.RabbitMQ;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Commands;
using eMobile.Phones.Models.Events;
using eMobile.Phones.Models.Exceptions;
using eMobile.Phones.Models.Responses;
using eMobile.Phones.Repository;
using eMobile.Phones.Service.Helpers;
using System;
using System.Threading.Tasks;

namespace eMobile.Phones.Service.Handlers.CommandHandlers
{
    public class CreatePhoneCommandHandler : ICommandHandlerAsync<CreatePhoneCommand, CreatePhoneCommandResponse>
    {
        #region Properties
        private readonly IRepository<Phone> phoneRepository;
        private readonly HATEOASLinksService hateoasLinksService;
        private readonly MediaTypeCheckService mediaTypeCheckService;
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;

        #endregion

        #region Constructor
        public CreatePhoneCommandHandler(
            IRepository<Phone> phoneRepository,
            HATEOASLinksService hateoasLinksService,
            MediaTypeCheckService mediaTypeCheckService,
            IMapper mapper,
            IEventBus eventBus)
        {
            this.phoneRepository = phoneRepository;
            this.hateoasLinksService = hateoasLinksService;
            this.mediaTypeCheckService = mediaTypeCheckService;
            this.mapper = mapper;
            this.eventBus = eventBus;
        }

        #endregion

        public Task<CreatePhoneCommandResponse> HandleAsync(CreatePhoneCommand command)
        {
            try
            {
                Guid phoneId = Guid.NewGuid();

                var mappedPhone = mapper.Map<Phone>(command);

                mappedPhone.Id = phoneId;
                mappedPhone.AddedDate = DateTime.Now;

                mappedPhone.Dimensions.Id = Guid.NewGuid();
                mappedPhone.Display.Id = Guid.NewGuid();
                mappedPhone.Media.ForEach(media => media.Id = Guid.NewGuid());

                phoneRepository.Insert(mappedPhone);

                eventBus.Publish(new PhoneCreatedEvent(
                    command.Name,
                    command.Manufacturer,
                    command.Dimensions,
                    command.Weight,
                    command.Display,
                    command.CPUModel,
                    command.RAM,
                    command.OS,
                    command.Price,
                    command.Media));

                phoneRepository.CommitTransaction();

                return Task.FromResult(new CreatePhoneCommandResponse()
                {
                    Id = phoneId,
                    Links = mediaTypeCheckService.CanCreateHATEOASLink() ? hateoasLinksService.CreateLinksForPhones(phoneId) : null
                });
            }

            catch (Exception ex)
            {
                phoneRepository.RollbackTransaction();
                throw new BaseApiException(System.Net.HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
