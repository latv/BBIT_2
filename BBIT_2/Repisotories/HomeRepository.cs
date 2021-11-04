using BBIT_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeContext _context;

        public HomeRepository(HomeContext context)
        {
            _context = context;
        }

        public async Task<Homes> Create(Homes home)
        {
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return home;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Homes>> Get()
        {
            return await _context.Homes.ToListAsync();
        }

        public async Task<Homes> Get(int id)
        {
            return await _context.Homes.FindAsync(id);
        }

        public async Task Update(Homes home)
        {
            _context.Entry(home).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
