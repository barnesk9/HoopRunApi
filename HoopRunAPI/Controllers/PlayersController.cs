using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoopRunAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace HoopRunAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly HoopRunAPIContext _context;

        public PlayersController(HoopRunAPIContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public IEnumerable<Player> GetPlayer()
        {
            return _context.Player;
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }


        // PATCH: api/Players
        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdateBook([FromRoute] int id, [FromBody] JsonPatchDocument<Player> patchDoc)
        {
            // If the received data is null
            if (patchDoc == null)
            {
                return BadRequest();
            }

            // Retrieve book from database
            var player = await _context.Player.SingleOrDefaultAsync(x => x.Id == id);

            // Check if is the book exist or not
            if (player == null)
            {
                return NotFound();
            }

            // Map retrieved book to BookModel with other properties (More or less with eexactly same name)
            var bookToPatch = Mapper.Map<Player>(player);

            // Apply book to ModelState
            patchDoc.ApplyTo(bookToPatch, ModelState);

            // Use this method to validate your data
            TryValidateModel(bookToPatch);

            // If model is not valid, return the problem
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Assign entity changes to original entity retrieved from database
            Mapper.Map(bookToPatch, player);

            // Say to entity framework that you have changes in book entity and it's modified
            _context.Entry(player).State = EntityState.Modified;

            // Save changes to database
            await _context.SaveChangesAsync();

            // If everything was ok, return no content status code to users
            return NoContent();
        }

        // POST: api/Players
        [HttpPatch]
        public async Task<IActionResult> PatchPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}