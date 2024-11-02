namespace BloodBank.Application.Models
{
    public class UpdateDonationInputModel
    {
        public int IdDonation { get; set; }
        public DateTime DonationDate { get; set; }
        public double Volume { get; set; }
        
    }
}
