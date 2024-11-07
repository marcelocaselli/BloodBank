using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.InsertDonation
{
    public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<int>>
    {
        private readonly IBloodBankRepository _repository;
        public InsertDonationHandler(IBloodBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
        {
            // Passo 1: Buscar o doador pelo ID
            var donor = await _repository.GetDonorById(request.IdDonor);
            if (donor == null)
            {
                return ResultViewModel<int>.Error("Doador não encontrado.");
            }

            // Passo 2: Criar uma nova doação
            var donation = new Donation(donor.Id, request.Volume, request.DonationDate);

            // Passo 3: Verificar o estoque para o tipo sanguíneo do doador
            var stock = await _repository.GetStockByBloodType(donor.BloodType, donor.RhFactor);

            if (stock == null)
            {
                // Criar novo estoque caso não exista
                stock = new Stock(donor.BloodType, donor.RhFactor, donation.Volume);
                await _repository.AddStock(stock);
            }
            else
            {
                // Atualizar o estoque existente
                stock.UpdateStock(donation.Volume);
                await _repository.UpdateStock(stock);
            }

            // Passo 4: Registrar a doação
            await _repository.AddDonation(donation);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
