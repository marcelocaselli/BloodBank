using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

public class Donor : BaseEntity 
{ 
    protected Donor() { }
    public Donor(string fullName, string email, DateTime birthDate, Address address, 
        EGender gender, double weight, EBloodType bloodType, ERhFactor fatorRh)
    {
        if(weight < 50)
        {
            throw new ArgumentException("Doador deve pesar o mínimo de 50Kg");              
        }

        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Address = address;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = fatorRh;

        Donations = [];
        StatusDonor = EStatusDonor.Active;
    }

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

    public void Update(string fullName, string email, DateTime birthDate, 
        EGender gender, double weight)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;        
    }    
}



