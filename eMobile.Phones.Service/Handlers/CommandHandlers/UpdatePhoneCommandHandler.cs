using AutoMapper;
using Common.Bus.CQRS;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Commands;
using eMobile.Phones.Models.Exceptions;
using eMobile.Phones.Repository;
using System;
using System.Threading.Tasks;

namespace eMobile.Phones.Service.Handlers.CommandHandlers
{
    public class UpdatePhoneCommandHandler : ICommandHandlerAsync<UpdatePhoneCommand>
    {
        #region Properties
        private readonly IRepository<Phone> phoneRepository;
        private readonly IMapper mapper;

        #endregion

        #region Constructor
        public UpdatePhoneCommandHandler(
            IRepository<Phone> phoneRepository,
            IMapper mapper)
        {
            this.phoneRepository = phoneRepository;
            this.mapper = mapper;
        }

        #endregion

        public Task HandleAsync(UpdatePhoneCommand command)
        {
            try
            {
                var phone = phoneRepository.Get(command.Id);

                if (phone == null)
                    throw new PhoneNotFound("Phone with this id not found");

                var phoneToPatch = mapper.Map<UpdatePhoneCommand>(command);

                command.PatchDocument().ApplyTo(phoneToPatch);

                mapper.Map(phoneToPatch, phone);

                phoneRepository.Update(phone);
                phoneRepository.CommitTransaction();

                return Task.CompletedTask;
            }

            catch (PhoneNotFound)
            {
                phoneRepository.RollbackTransaction();
                throw;
            }

            catch (Exception)
            {
                phoneRepository.RollbackTransaction();
                throw;
            }
        }
    }
}
