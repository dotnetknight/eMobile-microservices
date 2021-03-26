using eMobile.Phones.Models.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;

namespace eMobile.Phones.Service.Helpers
{
    public class HATEOASLinksService
    {

        #region Properties
        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly IActionContextAccessor actionContextAccessor;

        #endregion

        #region Constructor

        public HATEOASLinksService(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor)
        {
            this.urlHelperFactory = urlHelperFactory;
            this.actionContextAccessor = actionContextAccessor;
        }

        #endregion

        public IEnumerable<LinkModel> CreateLinksForPhones(Guid id)
        {
            var urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);

            var links = new List<LinkModel>
            {
                new LinkModel(urlHelper.Link("Phones", new { }),
                "list_of_phones",
                "GET"
                ),

                new LinkModel(urlHelper.Link("Phone", new { id }),
                "get_phone",
                "GET"
                ),

                new LinkModel(urlHelper.Link("CreatePhone", new { }),
                "create_phone",
                "POST"
                ),

                new LinkModel(urlHelper.Link("UpdatePhone", new { }),
                "create_phone",
                "PATCH"
                ),
            };

            return links;
        }
    }
}
