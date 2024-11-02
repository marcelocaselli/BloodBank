using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using BloodBank.Core.Entities;

namespace BloodBank.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly BloodBankDbContext _context;
        public DonationService(BloodBankDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<DonationsViewModel>> GetAll(string search = "")
        {
            var donations = _context
                .Donations
                .ToList();

            var model = donations.Select(DonationsViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationsViewModel>>.Success(model);
        }

        public ResultViewModel<DonationDetailViewModel> GetById(int id)
        {
            var donation = _context.Donations.SingleOrDefault(x => x.Id == id);

            if (donation == null)
            {
                return ResultViewModel<DonationDetailViewModel>.Error("Doação não localizada");
            }

            var model = DonationDetailViewModel.FromEntity(donation);

            return ResultViewModel<DonationDetailViewModel>.Success(model);
        }

        public ResultViewModel<List<DonationHistoryByDonorViewModel>> GetDonationHistoryByDonor(int id)
        {
            // Buscar o doador no banco e verificar se existe
            var donor = _context.Donors.SingleOrDefault(x => x.Id == id);
            if (donor == null)
            {
                return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Error("Doador não existe");
            }

            // Buscar todas as doações feitas pelo doador
            var donations = _context.Donations
                .Where(x => x.IdDonor == id)
                .Select(x => new DonationHistoryByDonorViewModel
                {
                    DonationDate = x.DonationDate,
                    Volume = x.Volume,
                    IdDonor = x.IdDonor
                })
                .ToList();

            // Verificar se há doações
            if (!donations.Any())
            {
                return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Error("Nenhuma doação encontrada para este doador");
            }

            return ResultViewModel<List<DonationHistoryByDonorViewModel>>.Success(donations);
        }



        public ResultViewModel<int> Insert(CreateDonationInputModel model)
        {
            var donation = new Donation(model.IdDonor, model.Volume, model.DonationDate);
            // buscar no banco de dados o doador 
            // verificar se existe no estoque o tipo sanguineo
            // se não existir, criar o estoque ou se existir atualizar o estoque

            var donor = _context.Donors.SingleOrDefault(x => x.Id == model.IdDonor);
            
            var stock = _context.Stocks.SingleOrDefault(x => x.BloodType == donor.BloodType && x.RhFactor == donor.RhFactor);

            if (stock == null)
            {
                stock = new Stock(donor.BloodType, donor.RhFactor, donation.Volume);
                _context.Stocks.Add(stock);
            }
            else
            {
                stock.UpdateStock(donation.Volume);
            }

            _context.Donations.Add(donation);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(donation.Id);
        }

        public ResultViewModel Update(UpdateDonationInputModel model)
        {
            var donation = _context.Donations.SingleOrDefault(x => x.Id == model.IdDonation);

            if (donation == null)
            {
                return ResultViewModel.Error("Doação não localizada");
            }

            donation.Update(model.IdDonation ,model.Volume, model.DonationDate);

            _context.Donations.Update(donation);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var donation = _context.Donations.SingleOrDefault(x => x.Id == id);

            if (donation == null)
            {
                return ResultViewModel.Error("Doação não localizada");
            }

            _context.Donations.Remove(donation);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
