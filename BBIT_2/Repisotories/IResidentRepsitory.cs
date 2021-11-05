using BBIT_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Repositories
{
    public interface IResidentRepsitory
    {
        Task<IEnumerable<Resident>> Get();
        Task<Resident> Get(int id);
        Task<Resident> Create(Resident resident);
        Task Update(Resident resident);
        Task Delete(int id);
    }
}