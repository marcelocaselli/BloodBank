namespace BloodBank.Application.Models
{
    public class DonationHistoryByDonorViewModel
    {
        public DonationHistoryByDonorViewModel() { }
        public DonationHistoryByDonorViewModel(double volume, DateTime donationDate)
        {
            
            Volume = volume;
            DonationDate = donationDate;
        }

        public int IdDonor { get; set; }
        public double Volume { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
