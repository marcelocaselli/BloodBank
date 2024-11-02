using BloodBank.Core.Enums;

namespace BloodBank.Application.Models
{
    public class UpdateStockInputModel
    {
        public int IdStock { get; set; }
        public EBloodType BloodType { get; set; }
        public ERhFactor RhFactor { get; set; }
        public double TotalQuantity { get; set; }
    }
}
