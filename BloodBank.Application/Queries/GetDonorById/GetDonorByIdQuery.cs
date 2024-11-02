using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<ResultViewModel<DonorDetailViewModel>>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

