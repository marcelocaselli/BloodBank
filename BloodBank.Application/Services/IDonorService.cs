using BloodBank.Application.Models;

namespace BloodBank.Application.Services
{
    public interface IDonorService
    {
        ResultViewModel<List<DonorsViewModel>> GetAll(string search = "");
        ResultViewModel<DonorDetailViewModel> GetById(int id);
        Task<ResultViewModel<int>> Insert(CreateDonorInputModel model);
        ResultViewModel Update(UpdateDonorInputModel model);
        ResultViewModel Delete(int id);
    }
}
