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
    public class RunsController : ControllerBase
    {
        private readonly HoopRunAPIContext _context;

        public RunsController(HoopRunAPIContext context)
        {
            _context = context;
        }

        // GET: api/Runs
        [HttpGet]
        public IEnumerable<Run> GetRun()
        {
            return _context.Run;
        }

        // GET: api/Runs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRun([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var run = await _context.Run.FindAsync(id);

            if (run == null)
            {
                return NotFound();
            }

            return Ok(run);
        }

        // PUT: api/Runs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRun([FromRoute] int id, [FromBody] Run run)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != run.Id)
            {
                return BadRequest();
            }

            _context.Entry(run).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RunExists(id))
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

        // POST: api/Runs
        [HttpPost]
        public async Task<IActionResult> PostRun([FromBody] Run run)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Run.Add(run);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRun", new { id = run.Id }, run);
        }

        // DELETE: api/Runs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRun([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var run = await _context.Run.FindAsync(id);
            if (run == null)
            {
                return NotFound();
            }

            _context.Run.Remove(run);
            await _context.SaveChangesAsync();

            return Ok(run);
        }

        private bool RunExists(int id)
        {
            return _context.Run.Any(e => e.Id == id);
        }
    }
}