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
    public class PlayerRunsController : ControllerBase
    {
        private readonly HoopRunAPIContext _context;

        public PlayerRunsController(HoopRunAPIContext context)
        {
            _context = context;
        }

        // GET: api/PlayerRuns
        [HttpGet]
        public IEnumerable<PlayerRun> GetPlayerRun()
        {
            return _context.PlayerRun;
        }

        // GET: api/PlayerRuns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerRun([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerRun = await _context.PlayerRun.FindAsync(id);

            if (playerRun == null)
            {
                return NotFound();
            }

            return Ok(playerRun);
        }

        // PUT: api/PlayerRuns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerRun([FromRoute] int id, [FromBody] PlayerRun playerRun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerRun.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerRun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerRunExists(id))
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

        // POST: api/PlayerRuns
        [HttpPost]
        public async Task<IActionResult> PostPlayerRun([FromBody] PlayerRun playerRun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlayerRun.Add(playerRun);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerRunExists(playerRun.PlayerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerRun", new { id = playerRun.PlayerId }, playerRun);
        }

        // DELETE: api/PlayerRuns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerRun([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerRun = await _context.PlayerRun.FindAsync(id);
            if (playerRun == null)
            {
                return NotFound();
            }

            _context.PlayerRun.Remove(playerRun);
            await _context.SaveChangesAsync();

            return Ok(playerRun);
        }

        private bool PlayerRunExists(int id)
        {
            return _context.PlayerRun.Any(e => e.PlayerId == id);
        }
    }
}