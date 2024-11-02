using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<ResultViewModel<List<DonorsViewModel>>>
    {

    }
}
