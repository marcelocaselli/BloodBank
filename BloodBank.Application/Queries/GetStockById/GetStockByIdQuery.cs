using BloodBank.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetStockById
{
    public class GetStockByIdQuery : IRequest<ResultViewModel<StocksViewModel>>
    {
        public GetStockByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
