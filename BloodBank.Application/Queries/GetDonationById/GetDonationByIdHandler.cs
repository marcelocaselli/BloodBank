using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationById
{
    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<DonationDetailViewModel>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationByIdHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<DonationDetailViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);

            if (donation == null)
            {
                return ResultViewModel<DonationDetailViewModel>.Error("Doação não localizada");
            }

            var model = DonationDetailViewModel.FromEntity(donation);

            return ResultViewModel<DonationDetailViewModel>.Success(model);
        }
    }
}
