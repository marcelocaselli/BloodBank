using BloodBank.Application.Models;

namespace BloodBank.Application.Services
{
    public interface IStockService
    {
        ResultViewModel<List<StocksViewModel>> Getall(string serach = "");
        ResultViewModel Update(UpdateStockInputModel model);
        ResultViewModel Delete(int id);
    }
}
