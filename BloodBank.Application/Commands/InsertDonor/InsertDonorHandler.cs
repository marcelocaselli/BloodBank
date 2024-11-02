using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.InsertDonor
{
    public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, ResultViewModel<int>>
    {
        private readonly BloodBankDbContext _context;
        public InsertDonorHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
        {
            var donorEmailExist = await _context.Donors.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (donorEmailExist != null)
            {
                return ResultViewModel<int>.Error("Email já cadastrado");
            }

            var donor = new Donor(
                request.FullName,
                request.Email,
                request.BirthDate,
                request.Address,
                request.Gender,
                request.Weight,
                request.BloodType,
                request.RhFactor
            );

            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
