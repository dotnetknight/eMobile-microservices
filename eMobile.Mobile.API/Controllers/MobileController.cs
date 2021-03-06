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
    public class MobileController : ControllerBase
    {
        private readonly ILogger<MobileController> _logger;

        public MobileController(ILogger<MobileController> logger)
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
