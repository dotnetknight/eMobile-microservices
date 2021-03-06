using Common.Bus.CQRS;
using eMobile.Phones.Models.Commands;
using eMobile.Phones.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMobile.Phones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly ICommandBusAsync commandBus;

        public PhonesController(ICommandBusAsync commandBus)
        {
            this.commandBus = commandBus;
        }

        // GET: api/<PhonesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{phoneId}", Name = "Author")]
        public ActionResult<string> Phone()
        {
            return Ok("Galaxy Note 3");
        }

        ///// <summary>
        ///// Return author with specific id
        ///// </summary>
        ///// <param name="query"></param>
        ///// <response code="200">Author with id</response>
        ///// <response code="404">Author not found</response>
        //[HttpGet("{AuthorId}", Name = "Author")]
        //[ProducesResponseType(typeof(AuthorQueryResponse), 200)]
        //[ProducesResponseType(typeof(ErrorModel), 404)]
        //public async Task<ActionResult<AuthorQueryResponse>> Author([FromRoute] AuthorQuery query)
        //{
        //    var result = await _queryBus.ExecuteAsync<AuthorQuery, AuthorQueryResponse>(query);
        //    return Ok(result);
        //}

        /// <summary>
        /// Creates new author in the system
        /// </summary>
        /// <param name="command"></param>
        /// <response code="201">Creates new author in the system</response>
        /// <response code="400">Unable to add new user in the system due to validation error</response>
        [HttpPost(Name = "CreatePhone")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult<CreatePhoneCommandResponse>> CreateAuthor([FromBody] CreatePhoneCommand command)
        {
            var result = await commandBus.ExecuteAsync<CreatePhoneCommand, CreatePhoneCommandResponse>(command);
            return CreatedAtAction("phoneId", new
            {
                phoneId = result.Id
            }, result);
        }
    }
}
