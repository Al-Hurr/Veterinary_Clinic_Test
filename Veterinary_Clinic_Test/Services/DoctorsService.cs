using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary_Clinic_Test.Context;
using Veterinary_Clinic_Test.Models;

namespace Veterinary_Clinic_Test.Services
{
    public class DoctorsService
    {
        private readonly AppDbContext _context;

        public DoctorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetAsync(int id)
        {
            return await _context.Doctors
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors
                .ToListAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await GetAsync(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
