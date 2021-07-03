using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary_Clinic_Test.Context;
using Veterinary_Clinic_Test.Models;

namespace Veterinary_Clinic_Test.Services
{
    public class VaccinationsService
    {
        private readonly AppDbContext _context;
        private readonly AnimalsService _animalsService;
        private readonly DoctorsService _doctorsService;
        private readonly DiagnosesService _diagnosesService;

        public VaccinationsService(AppDbContext context,
            AnimalsService animalsService,
            DoctorsService doctorsService,
            DiagnosesService diagnosesService)
        {
            _context = context;
            _animalsService = animalsService;
            _doctorsService = doctorsService;
            _diagnosesService = diagnosesService;
        }

        public async Task<Vaccination> GetAsync(int id)
        {
            return await _context.Vaccinations
                .Include(x => x.Diagnosis)
                .Include(x => x.Doctor)
                .Include(x => x.Animal)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Vaccination>> GetAllAsync()
        {
            return await _context.Vaccinations
                .Include(x => x.Diagnosis)
                .Include(x => x.Doctor)
                .Include(x => x.Animal)
                .ToListAsync();
        }

        public async Task UpdateAsync(Vaccination vaccination)
        {
            vaccination.Diagnosis = vaccination.Diagnosis.Id == 0 ? null : await _diagnosesService.GetAsync(vaccination.Diagnosis.Id);
            vaccination.Animal = vaccination.Animal.Id == 0 ? null : await _animalsService.GetAsync(vaccination.Animal.Id);
            vaccination.Doctor = vaccination.Doctor.Id == 0 ? null : await _doctorsService.GetAsync(vaccination.Doctor.Id);
            _context.Update(vaccination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vaccination = await GetAsync(id);
            _context.Vaccinations.Remove(vaccination);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Vaccination vaccination)
        {
            vaccination.Diagnosis = vaccination.Diagnosis.Id == 0 ? null : await _diagnosesService.GetAsync(vaccination.Diagnosis.Id);
            vaccination.Animal = vaccination.Animal.Id == 0 ? null : await _animalsService.GetAsync(vaccination.Animal.Id);
            vaccination.Doctor = vaccination.Doctor.Id == 0 ? null : await _doctorsService.GetAsync(vaccination.Doctor.Id);
            await _context.Vaccinations.AddAsync(vaccination);
            await _context.SaveChangesAsync();
        }
    }
}
