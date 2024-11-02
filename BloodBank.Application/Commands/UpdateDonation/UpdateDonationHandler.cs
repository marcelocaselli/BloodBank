using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;
        public UpdateDonationHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(x => x.Id == request.IdDonation);

            if (donation == null)
            {
                return ResultViewModel.Error("Doação não localizada");
            }

            donation.Update(request.IdDonation, request.Volume, request.DonationDate);

            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
