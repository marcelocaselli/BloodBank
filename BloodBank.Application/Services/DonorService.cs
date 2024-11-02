using BancoDeSangue.Infrastructure.Persistence;
using BloodBank.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly BloodBankDbContext _context;
        public DonorService(BloodBankDbContext context)
        {
            _context = context;
        }
        
        public ResultViewModel<List<DonorsViewModel>> GetAll(string search = "")
        {
            var donors = _context.Donors
                .Include(x => x.Address)
                .ToList();

            var model = donors.Select(DonorsViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorsViewModel>>.Success(model);
        }

        public ResultViewModel<DonorDetailViewModel> GetById(int id)
        {
            var donor = _context.Donors
                .Include(x => x.Address)
                //.Include(x => x.Doacoes)                
                .SingleOrDefault(x => x.Id == id);

            if (donor == null)
            {
                return ResultViewModel<DonorDetailViewModel>.Error("Doador não encontrado.");
            }

            var model = DonorDetailViewModel.FromEntity(donor);

            return ResultViewModel<DonorDetailViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Insert(CreateDonorInputModel model)
        {
            var donorEmailExist = await _context.Donors.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (donorEmailExist != null)
            {
                return ResultViewModel<int>.Error("Email já cadastrado");
            }

            var donor = new Donor(
                model.FullName,
                model.Email,                
                model.BirthDate,
                model.Address,
                model.Gender,
                model.Weight,
                model.BloodType,
                model.RhFactor
            );            

            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(donor.Id);
        }
        public ResultViewModel Update(UpdateDonorInputModel model)
        {
            var donor = _context.Donors.SingleOrDefault(x => x.Id == model.IdDonor);

            if (donor == null)
            {
                return ResultViewModel.Error("Doador não localizado.");
            }

            donor.Update(model.FullName, model.Email, model.BirthDate,
                model.Gender, model.Weight);

            _context.Donors.Update(donor);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var donor = _context.Donors.SingleOrDefault(x => x.Id == id);

            if (donor == null)
            {
                return ResultViewModel.Error("Doador não localizado.");
            }

            _context.Donors.Remove(donor);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
