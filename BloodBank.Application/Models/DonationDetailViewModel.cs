using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class DonationDetailViewModel
    {
        public DonationDetailViewModel(int idDonor, double volume, DateTime donationDate)
        {
            IdDonor = idDonor;
            Volume = volume;
            DonationDate = donationDate;
        }

        public int IdDonor { get; private set; }
        public double Volume { get; private set; }
        public DateTime DonationDate { get; private set; }

        public static DonationDetailViewModel FromEntity(Donation entity)
            => new(entity.IdDonor, entity.Volume, entity.DonationDate);
    }
}
