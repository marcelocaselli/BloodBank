using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.InsertDonor
{
    public class InsertDonorCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public EGender Gender { get; set; }
        public double Weight { get; set; }
        public EBloodType BloodType { get; set; }
        public ERhFactor RhFactor { get; set; }
    }
}
