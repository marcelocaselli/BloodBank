using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public interface IBloodBankRepository
    {
        Task<Donor?> GetDonorById(int id);
        Task<Stock?> GetStockByBloodType(EBloodType bloodType, ERhFactor rhFactor);
        Task AddStock(Stock stock);
        Task UpdateStock(Stock stock);
        Task AddDonation(Donation donation);
    }
}
