using Common.Bus.CQRS;
using eMobile.Phones.Domain.DimensionsEntity;
using eMobile.Phones.Domain.DisplayEntity;
using eMobile.Phones.Domain.MediaEntity;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Commands;
using eMobile.Phones.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMobile.Phones.Service.Handlers.CommandHandlers
{
    public class CreatePhoneCommandHandler : ICommandHandlerAsync<CreatePhoneCommand>
    {
        #region Properties
        private readonly IRepository<Phone> phoneRepository;
        #endregion

        #region Constructor
        public CreatePhoneCommandHandler(IRepository<Phone> phoneRepository)
        {
            this.phoneRepository = phoneRepository;
        }
        #endregion
        public Task HandleAsync(CreatePhoneCommand command)
        {
           

            return Task.CompletedTask;
        }
    }
}
