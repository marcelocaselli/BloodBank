using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAll();
        Task<Donation?> GetById(int id);
        Task<Donation?> GetDonationHistoryByDonor(int id);
        Task<int> Add(Donation donation);
        Task Update(Donation donation);
        Task Delete(int id);
    }
}
