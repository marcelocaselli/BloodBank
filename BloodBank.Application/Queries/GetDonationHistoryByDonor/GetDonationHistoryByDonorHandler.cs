using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationHistoryByDonor
{
    public class GetDonationHistoryByDonorHandler : IRequestHandler<GetDonationHistoryByDonorQuery, ResultViewModel<List<DonationHistoryByDonorViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationHistoryByDonorHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<DonationHistoryByDonorViewModel>>> Handle(GetDonationHistoryByDonorQuery request, CancellationToken cancellationToken)
        {
            // Buscar o doador no banco e verificar se existe

            var donor = await _repository.GetDonorById(request.Id);
            
            if (donor == null)
            {
                return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Error("Doador não existe");
            }

            //Buscar todas as doações feitas pelo doador
            var donations = await _repository.GetDonationsByDonorId(request.Id);
            var donationHistory = donations.Select(x => new DonationHistoryByDonorViewModel
            {
                DonationDate = x.DonationDate,
                Volume = x.Volume,
                IdDonor = x.IdDonor
            }).ToList();

            // Verificar se há doações
            if (!donations.Any())
            {
                return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Error("Nenhuma doação encontrada para este doador");
            }

            return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Success(donationHistory);
        }
    }
}
