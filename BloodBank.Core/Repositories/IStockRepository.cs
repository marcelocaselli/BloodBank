using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAll();
        Task<Stock?> GetById(int id);
        Task Delete(int id);
    }
}
