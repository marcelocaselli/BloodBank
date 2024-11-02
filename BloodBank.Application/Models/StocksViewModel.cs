using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

namespace BloodBank.Application.Models
{
    public class StocksViewModel
    {
        public StocksViewModel(EBloodType bloodType, ERhFactor rhFactor,
            double totalQuantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            TotalQuantity = totalQuantity;
        }

        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
        public double TotalQuantity { get; private set; }

        public static StocksViewModel FromEntity(Stock entity)
            => new(entity.BloodType, entity.RhFactor, entity.TotalQuantity);
    } 
}
