using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.InsertDonor
{
    public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _repository;
        public InsertDonorHandler( IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
        {
            var donorEmailExist = await _repository.GetByEmail(request.Email);
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

            await _repository.Add(donor);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
