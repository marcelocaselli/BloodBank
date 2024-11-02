using Azure.Core;
using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetDonorById
{
    public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorDetailViewModel>>
    {
        private readonly BloodBankDbContext _context;
        public GetDonorByIdHandler(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<DonorDetailViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _context.Donors
               .Include(x => x.Address)
            //.Include(x => x.Doacoes)                
               .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (donor == null)
            {
                return ResultViewModel<DonorDetailViewModel>.Error("Doador não encontrado.");
            }

            var model = DonorDetailViewModel.FromEntity(donor);

            return ResultViewModel<DonorDetailViewModel>.Success(model);
        }
    }
}
