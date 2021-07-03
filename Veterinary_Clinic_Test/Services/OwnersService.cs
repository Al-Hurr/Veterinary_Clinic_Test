using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary_Clinic_Test.Context;
using Veterinary_Clinic_Test.Models;

namespace Veterinary_Clinic_Test.Services
{
    public class OwnersService
    {
        private readonly AppDbContext _context;

        public OwnersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> GetAsync(int id)
        {
            return await _context.Owners
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Owner>> GetAllAsync()
        {
            return await _context.Owners
                .ToListAsync();
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var owner = await GetAsync(id);
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }
    }
}
