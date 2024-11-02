using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DeleteStock
{
    public class DeleteStockCommand : IRequest<ResultViewModel>
    {
        public DeleteStockCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

