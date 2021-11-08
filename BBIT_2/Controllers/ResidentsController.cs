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
   // [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly IResidentRepsitory _residentRepsitory;
        private readonly IApartmentsRepsitory _apartmentsRepsitory;

        public ResidentsController(IResidentRepsitory residentsRepository, IApartmentsRepsitory apartmentsRepsitory)
        {
            _residentRepsitory = residentsRepository;
            _apartmentsRepsitory = apartmentsRepsitory;

        }

        [HttpGet]
        public async Task<IEnumerable<Resident>> GetResidents()
        {
            return await _residentRepsitory.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResidents(int id)
        {
            return await _residentRepsitory.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Resident>> PostResidents(int id , [FromBody] Resident resident, Apartments apartments)
        {
            var residentIdInApartmentId = await _apartmentsRepsitory.Get(resident.ApartmentId);
            if (residentIdInApartmentId == null)
            {
                return BadRequest("Don't have related apartment!");
            }
            var newResident= await _residentRepsitory.Create(resident);
            return CreatedAtAction(nameof(GetResidents), new { id = newResident.Id }, newResident);
        }

        [HttpPut]
        public async Task<ActionResult> PutResidents(int id, [FromBody] Resident resident, Apartments apartments)
        {
            if (id != resident.Id)
            {
                return BadRequest("Have Id dublicate");
            }
            var residentIdInApartmentId = await _apartmentsRepsitory.Get(resident.ApartmentId);
            if (residentIdInApartmentId == null)
            {
                return BadRequest("Don't have related apartment!");
            }

            await _residentRepsitory.Update(resident);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var residentToDelete = await _residentRepsitory.Get(id);
            if (residentToDelete == null)
                return NotFound();

            await _residentRepsitory.Delete(residentToDelete.Id);
            return NoContent();
        }
    }
}