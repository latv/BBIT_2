using BBIT_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Repositories
{
    public class ResidentRepository : IResidentRepsitory
    {
        private readonly ResidentContext _context;

        public ResidentRepository(ResidentContext context)
        {
            _context = context;
        }

        public async Task<Resident> Create(Resident resident)
        {
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

            return resident;
        }

        public async Task Delete(int id)
        {
            var ResidentToDelete = await _context.Residents.FindAsync(id);
            _context.Residents.Remove(ResidentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Resident>> Get()
        {
            return await _context.Residents.ToListAsync();
        }

        public async Task<Resident> Get(int id)
        {
            return await _context.Residents.FindAsync(id);
        }

        public async Task Update(Resident resident)
        {
            _context.Entry(resident).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
