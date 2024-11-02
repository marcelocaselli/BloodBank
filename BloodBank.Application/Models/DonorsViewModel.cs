using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class DonorsViewModel
    {
        public DonorsViewModel(int id, string fullName, string email, 
            DateTime birthDate, Address address)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Address = address;

        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }

        public static DonorsViewModel FromEntity(Donor entity)
            => new(entity.Id, entity.FullName, entity.Email, entity.BirthDate,
                entity.Address);
    }
}
