using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DeleteStock
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;
        public DeleteStockHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _context.Stocks.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (stock == null)
            {
                return ResultViewModel.Error("Estoque não localizado");
            }

            _context.Stocks.Remove(stock);

            return ResultViewModel.Success();
        }
    }
}
