using BloodBank.Application.Commands.DeleteDonor;
using BloodBank.Application.Commands.InsertDonor;
using BloodBank.Application.Commands.UpdateDonor;
using BloodBank.Application.Queries.GetAllDonors;
using BloodBank.Application.Queries.GetDonorById;
using BloodBank.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/donors")]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService _service;
        private readonly IMediator _mediator;
        public DonorsController(IDonorService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }
        //Get api/donors?search=busca
        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var result = await _mediator.Send(new GetAllDonorsQuery());            

            return Ok(result);
        }

        //GetById api/donors/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDonorByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        //Post api/donors
        [HttpPost]
        public async Task<IActionResult> Post(InsertDonorCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        //Put api/donors/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDonorCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //Delete api/donors/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonorCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
