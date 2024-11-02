using BloodBank.Application.Commands.DeleteStock;
using BloodBank.Application.Commands.UpdateStockCommand;
using BloodBank.Application.Queries.GetAllStocks;
using BloodBank.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/bloodstocks")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;
        private readonly IMediator _mediator;
        public StockController(IStockService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        //Get api/bloodstocks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllStocksQuery());

            return Ok(result);
        }


        //Put api/bloodstocks/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //Delete api/bloodstocks/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStockCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
