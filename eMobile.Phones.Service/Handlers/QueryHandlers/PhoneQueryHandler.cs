using AutoMapper;
using eMobile.Common.Bus.CQRS;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Exceptions;
using eMobile.Phones.Models.Models;
using eMobile.Phones.Models.Queries;
using eMobile.Phones.Models.Responses;
using eMobile.Phones.Repository;
using eMobile.Phones.Service.Helpers;
using System;
using System.Threading.Tasks;

namespace eMobile.Phones.Service.Handlers.QueryHandlers
{
    public class PhoneQueryHandler : IQueryHandlerAsync<PhoneQuery, PhoneQueryResponse>
    {
        #region Properties
        private readonly IRepository<Phone> phoneRepository;
        private readonly HATEOASLinksService hateoasLinksService;
        private readonly MediaTypeCheckService mediaTypeCheckService;
        private readonly IMapper mapper;

        #endregion

        #region Constructor
        public PhoneQueryHandler(
            IRepository<Phone> phoneRepository,
            HATEOASLinksService hateoasLinksService,
            MediaTypeCheckService mediaTypeCheckService,
            IMapper mapper)
        {
            this.phoneRepository = phoneRepository;
            this.hateoasLinksService = hateoasLinksService;
            this.mediaTypeCheckService = mediaTypeCheckService;
            this.mapper = mapper;
        }

        #endregion

        public Task<PhoneQueryResponse> HandleAsync(PhoneQuery query)
        {
            PhoneDto mappedPhone;

            try
            {
                var phone = phoneRepository.Get(query.PhoneId);

                if (phone == null)
                    throw new PhoneNotFound("Phone with requested id not found");

                mappedPhone = mapper.Map<PhoneDto>(phone);
            }

            catch (PhoneNotFound)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new BaseApiException(System.Net.HttpStatusCode.InternalServerError, ex.ToString());
            }

            return Task.FromResult(new PhoneQueryResponse()
            {
                Phone = mappedPhone,
                Links = mediaTypeCheckService.CanCreateHATEOASLink() ? hateoasLinksService.CreateLinksForPhones(mappedPhone.Id) : null
            });
        }
    }
}
