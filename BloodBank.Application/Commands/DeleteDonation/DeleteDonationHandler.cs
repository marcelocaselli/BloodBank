using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;
        public DeleteDonationHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (donation == null)
            {
                return ResultViewModel.Error("Doação não localizada");
            }

            _context.Donations.Remove(donation);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
