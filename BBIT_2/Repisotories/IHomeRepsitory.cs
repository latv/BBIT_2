using BBIT_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Homes>> Get();
        Task<Homes> Get(int id);
        Task<Homes> Create(Homes homes);
        Task Update(Homes homes);
        Task Delete(int id);
    }
}