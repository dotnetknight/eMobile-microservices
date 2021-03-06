using System;
using System.Collections.Generic;
using eMobile.Phones.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace eMobile.Phones.API.Controllers
{
    [Route("api")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Produces("application/json")]
    public class RootController : ControllerBase
    {
        /// <summary>
        /// Creates root links for application
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Root")]
        public IActionResult Root()
        {
            var links = new List<LinkModel>
            {
                new LinkModel(Url.Link("Root", new { }),
                "self",
                "GET"
                ),

                new LinkModel(Url.Link("Phones", new { }),
                "list_of_phones",
                "GET"
                ),

                new LinkModel(Url.Link("Phone", new { phoneId = new Guid() }),
                "get_phone",
                "GET"
                ),

                new LinkModel(Url.Link("CreatePhone", new { }),
                "create_phone",
                "POST"
                ),

                new LinkModel(Url.Link("Options", new { }),
                "phones_controller_options",
                "OPTIONS"
                ),
            };

            return Ok(links);
        }
    }
}