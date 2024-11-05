using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DeleteStock
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand, ResultViewModel>
    {
        private readonly IStockRepository _repository;
        public DeleteStockHandler(IStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _repository.GetById(request.Id);

            if (stock == null)
            {
                return ResultViewModel.Error("Estoque não localizado");
            }

            await _repository.Delete(stock.Id);

            return ResultViewModel.Success();
        }
    }
}
