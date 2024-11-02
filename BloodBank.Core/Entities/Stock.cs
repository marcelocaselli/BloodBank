using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities
{
    public class Stock : BaseEntity
    {
        public Stock(EBloodType bloodType, ERhFactor rhFactor, double totalQuantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            TotalQuantity = totalQuantity;
        }

        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
        public double TotalQuantity { get; private set; }

        public void Update(EBloodType bloodType, ERhFactor rhFactor, double totalQuantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            TotalQuantity = totalQuantity;
        }
        public void UpdateStock(double amountDonated)
        {
            TotalQuantity += amountDonated;
        }        
    }    
}
