using BloodBank.Application.Queries.GetAllStocks;
using BloodBank.Application.Queries.GetStockById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/bloodstocks")]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get api/bloodstocks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllStocksQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetStockByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

                
        ////Delete api/bloodstocks/id
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _mediator.Send(new DeleteStockCommand(id));

        //    if (!result.IsSuccess)
        //    {
        //        return BadRequest(result.Message);
        //    }

        //    return NoContent();
        //}
    }
}
