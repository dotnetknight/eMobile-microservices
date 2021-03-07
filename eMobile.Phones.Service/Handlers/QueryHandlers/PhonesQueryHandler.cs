using AutoMapper;
using eMobile.Common.Bus.CQRS;
using eMobile.Phones.Domain.PhonesEntity;
using eMobile.Phones.Models.Exceptions;
using eMobile.Phones.Models.Models;
using eMobile.Phones.Models.Queries;
using eMobile.Phones.Models.Responses;
using eMobile.Phones.Models.Specifications;
using eMobile.Phones.Repository;
using eMobile.Phones.Service.Filters;
using eMobile.Phones.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Phones.Service.Handlers.QueryHandlers
{
    public class PhonesQueryHandler : IQueryHandlerAsync<PhonesQuery, PhonesQueryResponse>
    {
        #region Properties
        private readonly IRepository<Phone> phoneRepository;
        private readonly HATEOASLinksService hateoasLinksService;
        private readonly MediaTypeCheckService mediaTypeCheckService;
        private readonly IMapper mapper;

        #endregion

        #region Constructor
        public PhonesQueryHandler(
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

        public Task<PhonesQueryResponse> HandleAsync(PhonesQuery query)
        {
            try
            {
                var phones = phoneRepository.GetAll();

                if (string.IsNullOrEmpty(query.SearchQuery))
                {
                    return CreateResponse(phones);
                }

                var filterItems = new FilterPhones();

                var filteredPhones = filterItems.Filter(phones,
                     new SearchByNameManufacturerOs(
                         new NameSpecification(query.SearchQuery),
                         new ManufacturerSpecification(query.SearchQuery),
                         new OsSpecification(query.SearchQuery)));

                return CreateResponse(filteredPhones.ToList());
            }

            catch (Exception ex)
            {
                throw new BaseApiException(System.Net.HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        #region PrivateMethods

        private Task<PhonesQueryResponse> CreateResponse(List<Phone> phones)
        {
            return Task.FromResult(new PhonesQueryResponse()
            {
                Phones = MapAuthorToAuthorDto(phones),
                Links = mediaTypeCheckService.CanCreateHATEOASLink() ? hateoasLinksService.CreateLinksForPhones(Guid.Empty) : null
            });
        }

        private List<PhoneDto> MapAuthorToAuthorDto(List<Phone> phones)
        {
            return mapper.Map<List<PhoneDto>>(phones);
        }

        #endregion
    }
}
