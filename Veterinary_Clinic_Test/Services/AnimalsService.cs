using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary_Clinic_Test.Context;
using Veterinary_Clinic_Test.Models;

namespace Veterinary_Clinic_Test.Services
{
    public class AnimalsService
    {
        private readonly AppDbContext _context;
        private readonly OwnersService _ownersService;
        private readonly DoctorsService _doctorsService;
        private readonly DiagnosesService _diagnosesService;

        public AnimalsService(AppDbContext context,
            OwnersService ownersService,
            DoctorsService doctorsService,
            DiagnosesService diagnosesService)
        {
            _context = context;
            _ownersService = ownersService;
            _doctorsService = doctorsService;
            _diagnosesService = diagnosesService;
        }

        public async Task<Animal> GetAsync(int id)
        {
            return await _context.Animals
                .Include(x => x.Owner)
                .Include(x => x.Doctor)
                .Include(x => x.Diagnosis)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Animal>> GetAllAsync()
        {
            return await _context.Animals
                .Include(x => x.Owner)
                .Include(x => x.Doctor)
                .Include(x => x.Diagnosis)
                .ToListAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            animal.Diagnosis = animal.Diagnosis.Id == 0 ? null : await _diagnosesService.GetAsync(animal.Diagnosis.Id);
            animal.Owner = animal.Owner.Id == 0 ? null : await _ownersService.GetAsync(animal.Owner.Id);
            animal.Doctor = animal.Doctor.Id == 0 ? null : await _doctorsService.GetAsync(animal.Doctor.Id);
            _context.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var animal = await GetAsync(id);
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Animal animal)
        {
            animal.Diagnosis = animal.Diagnosis.Id == 0 ? null : await _diagnosesService.GetAsync(animal.Diagnosis.Id);
            animal.Owner = animal.Owner.Id == 0 ? null : await _ownersService.GetAsync(animal.Owner.Id);
            animal.Doctor = animal.Doctor.Id == 0 ? null : await _doctorsService.GetAsync(animal.Doctor.Id);
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
        }
    }
}
