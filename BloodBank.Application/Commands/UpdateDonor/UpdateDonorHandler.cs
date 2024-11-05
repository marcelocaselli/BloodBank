using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;
        public UpdateDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.IdDonor);

            if (donor == null)
            {
                return ResultViewModel.Error("Doador não localizado.");
            }

            donor.Update(request.FullName, request.Email, request.BirthDate,
                request.Gender, request.Weight);

            await _repository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}


