using Banking.Application.Movements.Contracts;
using Banking.Application.Movements.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using System;
using System.Collections.Generic;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Route("movement/{customerId}/movements")]
    [ApiController]
    [Authorize]
    public class MovementController : ControllerBase
    {
        private readonly IMovementQueries _movementQueries;

        public MovementController(IMovementQueries movementQueries)
        {
            _movementQueries = movementQueries;
        }

        [HttpPost]
        public IActionResult GetListPaginated(int customerId, [FromQuery]int page = 0, [FromQuery]int pageSize = 10)
        {
            try
            {                
                List<MovementDto> customers = _movementQueries.GetListPaginated(customerId,page, pageSize);
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponse(ApiConstants.InternalServerError));
            }
        }
    }
}
