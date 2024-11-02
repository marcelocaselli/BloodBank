using BloodBank.Application.Models;

namespace BloodBank.Application.Services
{
    public interface IDonationService
    {
        ResultViewModel<List<DonationsViewModel>> GetAll(string search = "");
        ResultViewModel<DonationDetailViewModel> GetById(int id);
        ResultViewModel<List<DonationHistoryByDonorViewModel>> GetDonationHistoryByDonor(int id);
        ResultViewModel<int> Insert(CreateDonationInputModel model);
        ResultViewModel Update(UpdateDonationInputModel model);
        ResultViewModel Delete(int id);
    }
}
