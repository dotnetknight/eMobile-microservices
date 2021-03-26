using Common.Bus.CQRS;
using eMobile.Common.Bus.CQRS;
using eMobile.Phones.Models.Commands;
using eMobile.Phones.Models.Models;
using eMobile.Phones.Models.Queries;
using eMobile.Phones.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eMobile.Phones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IQueryBusAsync queryBus;
        private readonly ICommandBusAsync commandBus;

        public PhonesController(ICommandBusAsync commandBus, IQueryBusAsync queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        #region GET
        /// <summary>
        /// Returns phone with specific id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Phone with id</response>
        /// <response code="404">Phone not found</response>
        [HttpGet("{id}", Name = "Phone")]
        [ProducesResponseType(typeof(PhoneQueryResponse), 200)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        public async Task<ActionResult<PhoneQueryResponse>> Phone([FromRoute] Guid id)
        {
            var result = await queryBus.ExecuteAsync<PhoneQuery, PhoneQueryResponse>(new PhoneQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Returns all phones
        /// </summary>
        /// <param name="query"></param>
        /// <response code="200">Phones</response>
        [HttpGet(Name = "Phones")]
        [ResponseCache(Duration = 3)]
        [ProducesResponseType(typeof(PhonesQueryResponse), 200)]
        public async Task<ActionResult<PhonesQueryResponse>> Phones([FromQuery] PhonesQuery query)
        {
            var result = await queryBus.ExecuteAsync<PhonesQuery, PhonesQueryResponse>(query);
            return Ok(result);
        }

        #endregion

        #region POST

        /// <summary>
        /// Creates new phone in the system
        /// </summary>
        /// <param name="command"></param>
        /// <response code="201">Creates new phone in the system</response>
        /// <response code="400">Unable to add new user in the system due to validation error</response>
        [HttpPost(Name = "CreatePhone")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult<CreatePhoneCommandResponse>> CreatePhone([FromBody] CreatePhoneCommand command)
        {
            var result = await commandBus.ExecuteAsync<CreatePhoneCommand, CreatePhoneCommandResponse>(command);

            return CreatedAtAction("Phone", new
            {
                id = result.Id
            }, result);
        }

        #endregion

        #region Patch

        /// <summary>
        /// Updates phone entity in the system
        /// </summary>
        /// <param name="patchDocument"></param>
        /// <param name="id"></param>
        /// <response code="204">Updates phone entity in the system</response>
        [HttpPatch("{id}", Name = "UpdatePhone")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UpdatePhoneCommand>> UpdatePhone([FromBody] JsonPatchDocument<UpdatePhoneCommand> patchDocument, [FromRoute] Guid id)
        {
            await commandBus.ExecuteAsync(
                new UpdatePhoneCommand(
                    patchDocument, id));

            return NoContent();
        }

        #endregion

        #region HttpOptions
        /// <summary>
        /// Communication options for a given URL
        /// </summary>
        /// <response code="200">Returns allowed http methods</response>
        [HttpOptions(Name = "Options")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AuthorsControllerOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,PATCH,OPTIONS");

            return Ok();
        }
        #endregion
    }
}
