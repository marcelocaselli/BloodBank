using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonors
{
    public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorsViewModel>>>
    {
        private readonly IDonorRepository _repository;
        public GetAllDonorsHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<DonorsViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _repository.GetAll();

            var model = donors.Select(DonorsViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorsViewModel>>.Success(model);
        }
    }
}
