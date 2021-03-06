using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net.Http.Headers;

namespace eMobile.Phones.Service.Helpers
{
    public class MediaTypeCheckService
    {
        #region Properties
        private IActionContextAccessor _actionContextAccessor;

        #endregion

        #region Constructor

        public MediaTypeCheckService(
            IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }

        #endregion

        public bool CanCreateHATEOASLink()
        {
            if (MediaTypeHeaderValue.TryParse(_actionContextAccessor.ActionContext.HttpContext.Request.Headers["Accept"], out MediaTypeHeaderValue parsedMediaType))
            {
                if (parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json")
                    return true;
            }

            return false;
        }
    }
}
