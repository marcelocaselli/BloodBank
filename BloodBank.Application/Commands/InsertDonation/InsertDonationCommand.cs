using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.InsertDonation
{
    public class InsertDonationCommand : IRequest<ResultViewModel<int>>
    {
        public int IdDonor { get; set; }
        public double Volume { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
