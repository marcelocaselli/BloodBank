using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.InsertDonation
{
    public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<int>>
    {
        private readonly BloodBankDbContext _context;
        private readonly IDonorRepository _repository;
        public InsertDonationHandler(BloodBankDbContext context, IDonorRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation(request.IdDonor, request.Volume, request.DonationDate);
            // buscar no banco de dados o doador 
            // verificar se existe no estoque o tipo sanguineo
            // se não existir, criar o estoque ou se existir atualizar o estoque

            //var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == request.IdDonor);

            var donor = await _repository.GetById(request.IdDonor);

            var stock = await _context.Stocks.SingleOrDefaultAsync(x => x.BloodType == donor.BloodType && x.RhFactor == donor.RhFactor);

            if (stock == null)
            {
                stock = new Stock(donor.BloodType, donor.RhFactor, donation.Volume);
                _context.Stocks.Add(stock);
            }
            else
            {
                stock.UpdateStock(donation.Volume);
            }

            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
