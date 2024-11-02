using BloodBank.Core.Enums;

namespace BloodBank.Application.Models
{
    public class UpdateDonorInputModel
    {
        public int IdDonor { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public double Weight { get; set; }
    }
}

