using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetAllDonors
{
    public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorsViewModel>>>
    {
        private readonly BloodBankDbContext _context;
        public GetAllDonorsHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<DonorsViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _context.Donors
                .Include(x => x.Address)
                .ToListAsync();

            var model = donors.Select(DonorsViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorsViewModel>>.Success(model);
        }
    }
}
