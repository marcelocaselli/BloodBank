using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationHistoryByDonor
{
    public class GetDonationHistoryByDonorQuery : IRequest<ResultViewModel<List<DonationHistoryByDonorViewModel>>>
    {
        public GetDonationHistoryByDonorQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}



