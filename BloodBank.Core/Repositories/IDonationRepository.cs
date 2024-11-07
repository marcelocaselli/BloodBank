using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAll();
        Task<Donation?> GetById(int id);
        Task<Donor?> GetDonorById(int id);
        Task<List<Donation>> GetDonationsByDonorId(int id);
        Task Delete(int id);
    }
}
