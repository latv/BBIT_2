using BBIT_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Repositories
{
    public class ApartmentRepository : IApartmentsRepsitory 
    {
        private readonly AllContext _context;


        public ApartmentRepository(AllContext context)
        {
            _context = context;
        }

        public async Task<Apartments> Create(Apartments apartment)
        {

 
        
                _context.Apartments.Add(apartment);
                await _context.SaveChangesAsync();

                return apartment; 
        }

        public async Task Delete(int id)
        {
            var ApartmentsToDelete = await _context.Apartments.FindAsync(id);
            _context.Apartments.Remove(ApartmentsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Apartments>> Get()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartments> Get(int id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public async Task Update(Apartments apartments)
        {
            _context.Entry(apartments ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
