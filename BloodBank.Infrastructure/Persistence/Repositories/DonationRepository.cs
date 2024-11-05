using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using BloodBank.Application.Models;

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

        public async Task<Donation?> GetDonationHistoryByDonor(int id)
        {
            var donation = await _context.Donations
                .Where(x => x.IdDonor == id)
                .Select(x => new DonationHistoryByDonorViewModel
                {
                    DonationDate = x.DonationDate,
                    Volume = x.Volume,
                    IdDonor = x.IdDonor
                })
                .ToListAsync();

            return donation;
        }

        public Task<int> Add(Donation donation)
        {
            throw new NotImplementedException();
        }

        public Task Update(Donation donation)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
