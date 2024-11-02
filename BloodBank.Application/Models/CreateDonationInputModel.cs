namespace BloodBank.Application.Models
{
    public class CreateDonationInputModel
    {
        public int IdDonor { get; set; }
        public double Volume { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
