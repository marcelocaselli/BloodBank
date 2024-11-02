using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.UpdateStockCommand
{
    public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;
        public UpdateStockHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _context.Stocks.SingleOrDefaultAsync(x => x.Id == request.IdStock);

            if (stock == null)
            {
                return ResultViewModel.Error("");
            }

            stock.Update(request.BloodType, request.RhFactor, request.TotalQuantity);

            return ResultViewModel.Success();
        }
    }
}
