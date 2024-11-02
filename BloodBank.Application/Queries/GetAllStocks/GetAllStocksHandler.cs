using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetAllStocks
{
    public class GetAllStocksHandler : IRequestHandler<GetAllStocksQuery, ResultViewModel<List<StocksViewModel>>>
    {
        private readonly BloodBankDbContext _context;
        public GetAllStocksHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<StocksViewModel>>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _context.Stocks.ToListAsync();

            var model = stocks.Select(StocksViewModel.FromEntity).ToList();

            return ResultViewModel<List<StocksViewModel>>.Success(model);
        }
    }
}
