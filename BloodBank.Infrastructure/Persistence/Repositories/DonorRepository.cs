using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDbContext _context;
        public DonorRepository(BloodBankDbContext context)
        {
            _context = context;   
        }

        public async Task<List<Donor>> GetAll()
        {
            var donors = await _context.Donors
                .Include(x => x.Address)
                .ToListAsync();

            return donors;
        }

        public async Task<Donor?> GetById(int id)
        {
            return await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);            
        }

        public async Task<Donor?> GetDetailById(int id)
        {
            return await _context.Donors
              .Include(x => x.Address)
              //.Include(x => x.Doacoes)                
              .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Donor?> GetByEmail(string email)
        {
            return await _context.Donors.SingleOrDefaultAsync(x  => x.Email == email);            
        }


        public async Task<int> Add(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            return donor.Id;
        }

        public async Task Delete(int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Donors.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }
    }
}
