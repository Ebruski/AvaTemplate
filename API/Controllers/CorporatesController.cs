using System.Text.Json;
using Application.Common.Models;
using Application.UseCases.Corporates.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CorporatesController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenericRequest([FromBody] GetAllCorporatesQuery request)
        {
            var result = await Mediator.Send(request);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}
