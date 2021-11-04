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
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly IHomeRepository _homeRepository;

        public HomesController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Homes>> GetHomes()
        {
            return await _homeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Homes>> GetHomes(int id)
        {
            return await _homeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Homes>> PostHomes([FromBody] Homes home)
        {
            var newHome= await _homeRepository.Create(home);
            return CreatedAtAction(nameof(GetHomes), new { id = newHome.Id }, newHome);
        }

        [HttpPut]
        public async Task<ActionResult> PutHomes(int id, [FromBody] Homes home)
        {
            if (id != home.Id)
            {
                return BadRequest();
            }

            await _homeRepository.Update(home);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var homeToDelete = await _homeRepository.Get(id);
            if (homeToDelete == null)
                return NotFound();

            await _homeRepository.Delete(homeToDelete.Id);
            return NoContent();
        }
    }
}