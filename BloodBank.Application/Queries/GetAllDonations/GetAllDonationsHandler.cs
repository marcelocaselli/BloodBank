using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonations
{
    public class GetAllDonationsHandler : IRequestHandler<GetAllDonationsQuery, ResultViewModel<List<DonationsViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetAllDonationsHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<DonationsViewModel>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();


            var model = donations.Select(DonationsViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationsViewModel>>.Success(model);
        }
    }
}
