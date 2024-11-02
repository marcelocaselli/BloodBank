using BloodBank.Application.Models;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<ResultViewModel>
    {
        public int IdDonor { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public double Weight { get; set; }
    }
}
