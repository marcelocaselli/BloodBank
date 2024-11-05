namespace BloodBank.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAll();
        Task<Donor?> GetDetailById(int id);
        Task<Donor?> GetById(int id);
        Task<Donor?> GetByEmail(string email);
        Task<int> Add(Donor donor);
        Task Update(Donor donor);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
