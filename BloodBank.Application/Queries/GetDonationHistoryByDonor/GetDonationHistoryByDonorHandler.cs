using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetDonationHistoryByDonor
{
    public class GetDonationHistoryByDonorHandler : IRequestHandler<GetDonationHistoryByDonorQuery, ResultViewModel<List<DonationHistoryByDonorViewModel>>>
    {
        private readonly BloodBankDbContext _context;
        public GetDonationHistoryByDonorHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<DonationHistoryByDonorViewModel>>> Handle(GetDonationHistoryByDonorQuery request, CancellationToken cancellationToken)
        {
            // Buscar o doador no banco e verificar se existe
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (donor == null)
            {
                return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Error("Doador não existe");
            }

            // Buscar todas as doações feitas pelo doador
            var donations = await _context.Donations
                .Where(x => x.IdDonor == request.Id)
                .Select(x => new DonationHistoryByDonorViewModel
                {
                    DonationDate = x.DonationDate,
                    Volume = x.Volume,
                    IdDonor = x.IdDonor
                })
                .ToListAsync();

            // Verificar se há doações
            if (!donations.Any())
            {
                return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Error("Nenhuma doação encontrada para este doador");
            }

            return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Success(donations);
        }
    }
}
