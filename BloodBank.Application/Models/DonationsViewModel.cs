using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class DonationsViewModel
    {
        public DonationsViewModel(int idDonor, DateTime donationDate, double volume)
        {
            IdDonor = idDonor;
            DonationDate = donationDate;
            Volume = volume;
        }

        public int IdDonor { get; private set; }
        public DateTime DonationDate { get; private set; }
        public double Volume { get; private set; }

        public static DonationsViewModel FromEntity(Donation entity)
            => new(entity.IdDonor, entity.DonationDate, entity.Volume);
    }
}


