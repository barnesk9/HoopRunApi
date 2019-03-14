using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoopRunAPI.Models;

namespace HoopRunAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly HoopRunAPIContext _context;

        public GymsController(HoopRunAPIContext context)
        {
            _context = context;
        }

        // GET: api/Gyms
        [HttpGet]
        public IEnumerable<Gym> GetGym()
        {
            return _context.Gym;
        }

        // GET: api/Gyms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGym([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gym = await _context.Gym.FindAsync(id);

            if (gym == null)
            {
                return NotFound();
            }

            return Ok(gym);
        }

        // PUT: api/Gyms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGym([FromRoute] int id, [FromBody] Gym gym)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gym.Id)
            {
                return BadRequest();
            }

            _context.Entry(gym).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Gyms
        [HttpPost]
        public async Task<IActionResult> PostGym([FromBody] Gym gym)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Gym.Add(gym);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGym", new { id = gym.Id }, gym);
        }

        // DELETE: api/Gyms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gym = await _context.Gym.FindAsync(id);
            if (gym == null)
            {
                return NotFound();
            }

            _context.Gym.Remove(gym);
            await _context.SaveChangesAsync();

            return Ok(gym);
        }

        private bool GymExists(int id)
        {
            return _context.Gym.Any(e => e.Id == id);
        }
    }
}