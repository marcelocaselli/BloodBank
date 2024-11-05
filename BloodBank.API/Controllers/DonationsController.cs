using BloodBank.Application.Commands.DeleteDonation;
using BloodBank.Application.Commands.InsertDonation;
using BloodBank.Application.Commands.UpdateDonation;
using BloodBank.Application.Queries.GetAllDonations;
using BloodBank.Application.Queries.GetDonationById;
using BloodBank.Application.Queries.GetDonationHistoryByDonor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get api/donations?search=xyz
        [HttpGet]
        public async Task<IActionResult> Get(string search ="")
        {
            var result = await _mediator.Send(new GetAllDonationsQuery());

            return Ok(result);
        }

        //Get api/donations/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDonationByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}/donor")]
        public async Task<IActionResult> GetDonationHistoryByDonor(int id)
        {
            var donation = await _mediator.Send(new GetDonationHistoryByDonorQuery(id));

            return Ok(donation);
        }

        //Post api/donations
        [HttpPost]
        public async Task<IActionResult> Post(InsertDonationCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();            
        }

        //Put api/donations/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);                
            }

            return NoContent();             
        }

        //Delete api/donations/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonationCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
