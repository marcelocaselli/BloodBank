using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetStockById
{
    public class GetStockByIdHandler : IRequestHandler<GetStockByIdQuery, ResultViewModel<StocksViewModel>>
    {
        private readonly IStockRepository _repository;
        public GetStockByIdHandler(IStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<StocksViewModel>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var stock = await _repository.GetById(request.Id);

            if (stock == null)
            {
                return ResultViewModel<StocksViewModel>.Error("Estoque não encontrado.");
            }

            var model = StocksViewModel.FromEntity(stock);

            return ResultViewModel<StocksViewModel>.Success(model);
        }
    }
}
