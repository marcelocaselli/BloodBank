using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly BloodBankDbContext _context;
        public BloodBankRepository(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task AddDonation(Donation donation)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
        }

        public async Task AddStock(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
        }

        public async Task<Donor?> GetDonorById(int id)
        {
            return await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stock?> GetStockByBloodType(EBloodType bloodType, ERhFactor rhFactor)
        {
            return await _context.Stocks.SingleOrDefaultAsync(x => x.BloodType == bloodType && x.RhFactor == rhFactor);
        }

        public async Task UpdateStock(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
        }
    }
}
