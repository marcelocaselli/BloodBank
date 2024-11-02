using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetAllStocks
{
    public class GetAllStocksQuery : IRequest<ResultViewModel<List<StocksViewModel>>>
    {

    }
}
