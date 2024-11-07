using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankDbContext _context;
        public DonationRepository(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<List<Donation>> GetAll()
        {
            var donations = await _context
                .Donations
                .ToListAsync();

            return donations;
        }

        public async Task<Donation?> GetById(int id)
        {
            return await _context.Donations.SingleOrDefaultAsync(x => x.Id == id);            
        }

        public async Task<Donor?> GetDonorById(int id)
        {
            return await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Donation>> GetDonationsByDonorId(int id)
        {
            return await _context.Donations
                .Where(x => x.IdDonor == id)
                .ToListAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }        
    }
}
