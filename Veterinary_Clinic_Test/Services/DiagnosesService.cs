using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary_Clinic_Test.Context;
using Veterinary_Clinic_Test.Models;

namespace Veterinary_Clinic_Test.Services
{
    public class DiagnosesService
    {
        private readonly AppDbContext _context;
        private readonly DoctorsService _doctorsService;

        public DiagnosesService(AppDbContext context,
            DoctorsService doctorsService)
        {
            _context = context;
            _doctorsService = doctorsService;
        }

        public async Task<Diagnosis> GetAsync(int id)
        {
            return await _context.Diagnoses
                .Include(x => x.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Diagnosis>> GetAllAsync()
        {
            return await _context.Diagnoses
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public async Task UpdateAsync(Diagnosis diagnosis)
        {
            diagnosis.Doctor = diagnosis.Doctor.Id == 0 ? null : await _doctorsService.GetAsync(diagnosis.Doctor.Id);
            _context.Update(diagnosis);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var diagnosis = await GetAsync(id);
            _context.Diagnoses.Remove(diagnosis);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Diagnosis diagnosis)
        {
            diagnosis.Doctor = diagnosis.Doctor.Id == 0 ? null : await _doctorsService.GetAsync(diagnosis.Doctor.Id);
            await _context.Diagnoses.AddAsync(diagnosis);
            await _context.SaveChangesAsync();
        }
    }
}
