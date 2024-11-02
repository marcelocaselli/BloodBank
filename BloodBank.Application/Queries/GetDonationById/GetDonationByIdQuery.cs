using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<ResultViewModel<DonationDetailViewModel
        >>
    {
        public GetDonationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

