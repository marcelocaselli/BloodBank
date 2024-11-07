using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly BloodBankDbContext _context;
        public StockRepository(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetAll()
        {
            var stocks = await _context.Stocks
                .ToListAsync();

            return stocks;
        }

        public async Task<Stock?> GetById(int id)
        {
            return await _context.Stocks.SingleOrDefaultAsync(x => x.Id == id);
        }

        //public async Task Delete(int id)
        //{
        //    var stock = await _context.Stocks.SingleOrDefaultAsync(x => x.Id == id);

        //    _context.Stocks.Remove(stock);
        //    await _context.SaveChangesAsync();
        //}
    }
}
