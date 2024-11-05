using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorById
{
    public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorDetailViewModel>>
    {
        private readonly IDonorRepository _repository;
        public GetDonorByIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<DonorDetailViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            if (donor == null)
            {
                return ResultViewModel<DonorDetailViewModel>.Error("Doador não encontrado.");
            }

            var model = DonorDetailViewModel.FromEntity(donor);

            return ResultViewModel<DonorDetailViewModel>.Success(model);
        }
    }
}
