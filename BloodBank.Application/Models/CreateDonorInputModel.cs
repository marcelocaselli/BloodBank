using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

namespace BloodBank.Application;

public class CreateDonorInputModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; }
    public EGender Gender { get; set; }
    public double Weight { get; set; }
    public EBloodType BloodType { get; set; }
    public ERhFactor RhFactor { get; set; }

    public Donor ToEntity()
        => new(FullName, Email, BirthDate, Address, Gender, Weight, BloodType, RhFactor);
}

