using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetDonationById
{
    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<DonationDetailViewModel>>
    {
        private readonly BloodBankDbContext _context;
        public GetDonationByIdHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<DonationDetailViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (donation == null)
            {
                return ResultViewModel<DonationDetailViewModel>.Error("Doação não localizada");
            }

            var model = DonationDetailViewModel.FromEntity(donation);

            return ResultViewModel<DonationDetailViewModel>.Success(model);
        }
    }
}
