using BBIT_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Repositories
{
    public interface IApartmentsRepsitory
    {
        Task<IEnumerable<Apartments>> Get();
        Task<Apartments> Get(int id);
        Task<Apartments> Create(Apartments apartments);
        Task Update(Apartments apartments);
        Task Delete(int id);
    }
}