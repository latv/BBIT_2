using BBIT_2.Models;
using BBIT_2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Controllers
{
    [Route("api/[controller]")]
//    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsRepsitory _apartsmentRepository;
        private readonly IHomeRepository _homeRepository;
    
        public ApartmentsController(IApartmentsRepsitory apartmentsRepsitory,IHomeRepository homeRepository)
        {
            _apartsmentRepository = apartmentsRepsitory;
            _homeRepository = homeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Apartments>> GetApartments()
        {
            var ap = await _apartsmentRepository.Get();
            return ap;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Apartments>> GetApartsments(int id)
        {
            return await _apartsmentRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Apartments>> PostApartsmens(int id , [FromBody] Apartments apartments, Homes homes)
        {
            var apartsmentsIdInHomeId = await _homeRepository.Get(apartments.HomeId);
            if (apartsmentsIdInHomeId == null)
            {
                return BadRequest("Don't have related home!");
            }
            var newApartsment= await _apartsmentRepository.Create(apartments);
            return CreatedAtAction(nameof(GetApartments), new { id = newApartsment.Id }, newApartsment);
        }

        [HttpPut]
        public async Task<ActionResult> PutApartsment(int id  ,[FromBody] Apartments apartsment,Resident resident)
        {
            if (id != apartsment.Id)
            {
                return BadRequest();
            }

            var apartsmentsIdInHomeId = await _homeRepository.Get(apartsment.HomeId);
            if (apartsmentsIdInHomeId == null)
            {
                return BadRequest("Don't have related home!");
            }


            await _apartsmentRepository.Update(apartsment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var apartsmentToDelete = await _apartsmentRepository.Get(id);
            if (apartsmentToDelete == null)
                return NotFound();

            await _apartsmentRepository.Delete(apartsmentToDelete.Id);
            return NoContent();
        }
    }
}