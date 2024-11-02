using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetAllDonations
{
    public class GetAllDonationsHandler : IRequestHandler<GetAllDonationsQuery, ResultViewModel<List<DonationsViewModel>>>
    {

        private readonly BloodBankDbContext _context;
        public GetAllDonationsHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<DonationsViewModel>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _context
                .Donations
                .ToListAsync();


            var model = donations.Select(DonationsViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationsViewModel>>.Success(model);
        }
    }
}
