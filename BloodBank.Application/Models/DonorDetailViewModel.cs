using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

namespace BloodBank.Application.Models
{
    public class DonorDetailViewModel
    {
        public DonorDetailViewModel(int id, string fullName, string email, DateTime birthDate, 
            Address address, EGender gender, double weight, EBloodType bloodType, 
            ERhFactor rhFator, EStatusDonor statusDonor, List<Donation> donations)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Address = address;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFator;
            StatusDonor = statusDonor;
            Donations = donations;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public EGender Gender { get; private set; }
        public double Weight { get; private set; }
        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
        public EStatusDonor StatusDonor { get; private set; }
        public List<Donation> Donations { get; private set; }

        public static DonorDetailViewModel FromEntity(Donor entity)
            => new(entity.Id, entity.FullName, entity.Email, entity.BirthDate,
                entity.Address, entity.Gender, entity.Weight, entity.BloodType,
                entity.RhFactor, entity.StatusDonor, entity.Donations);
    }
}
