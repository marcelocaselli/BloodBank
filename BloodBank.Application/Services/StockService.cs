using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;

namespace BloodBank.Application.Services
{
    public class StockService : IStockService
    {
        private readonly BloodBankDbContext _context;
        public StockService(BloodBankDbContext context)
        {
            _context = context;   
        }
        public ResultViewModel<List<StocksViewModel>> Getall(string serach = "")
        {
            var stocks = _context.Stocks.ToList();

            var model = stocks.Select(StocksViewModel.FromEntity).ToList();

            return ResultViewModel<List<StocksViewModel>>.Success(model);
        }

        public ResultViewModel Update(UpdateStockInputModel model)
        {
            var stock = _context.Stocks.SingleOrDefault(x => x.Id == model.IdStock);

            if (stock == null)
            {
                return ResultViewModel.Error("");
            }

            stock.Update(model.BloodType, model.RhFactor, model.TotalQuantity);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var stock = _context.Stocks.SingleOrDefault(x => x.Id == id);
            if (stock == null)
            {
                return ResultViewModel.Error("Estoque não localizado");
            }

            _context.Stocks.Remove(stock);

            return ResultViewModel.Success();
        }
    }
}
