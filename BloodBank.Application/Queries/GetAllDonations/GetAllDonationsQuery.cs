using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<ResultViewModel<List<DonationsViewModel>>>
    {

    }
}
