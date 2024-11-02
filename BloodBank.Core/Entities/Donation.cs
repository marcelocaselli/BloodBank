namespace BloodBank.Core.Entities
{
    public class Donation : BaseEntity
    {
        protected Donation() { }
        public Donation(int idDoador, double volume, DateTime donationDate)
        {
            IdDonor = idDoador;
            Volume = volume;
            DonationDate = donationDate;
        }

        public int IdDonor { get; private set; }
        public Donor? Donor { get; private set; }
        public double Volume { get; private set; }
        public DateTime DonationDate { get; private set; }
                
        public void Update(int idDonor, double volume, DateTime donationDate)
        {
            IdDonor = idDonor;
            Volume = volume;
            DonationDate = donationDate;
        }
    }
}

