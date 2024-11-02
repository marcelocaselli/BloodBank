using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;
        public DeleteDonorHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (donor == null)
            {
                return ResultViewModel.Error("Doador não localizado.");
            }

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
