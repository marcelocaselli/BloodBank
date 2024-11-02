using BloodBank.Application.Models;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.UpdateStockCommand
{
    public class UpdateStockCommand : IRequest<ResultViewModel>
    {
        public int IdStock { get; set; }
        public EBloodType BloodType { get; set; }
        public ERhFactor RhFactor { get; set; }
        public double TotalQuantity { get; set; }
    }
}
