using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;
        public UpdateDonorHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == request.IdDonor);

            if (donor == null)
            {
                return ResultViewModel.Error("Doador não localizado.");
            }

            donor.Update(request.FullName, request.Email, request.BirthDate,
                request.Gender, request.Weight);

            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}


