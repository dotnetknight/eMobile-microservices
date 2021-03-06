using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Mobile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobilesController : ControllerBase
    {
        private readonly ILogger<MobilesController> _logger;

        public MobilesController(ILogger<MobilesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Galaxy Note 3");
        }

        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }
    }
}
