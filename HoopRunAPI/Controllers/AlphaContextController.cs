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
    [Produces("application/json")]
    [Route("api/usermodel")]
    public class HoopRunAPIContextController : Controller
    {
        private readonly HoopRunAPIContext _context;

        public HoopRunAPIContextController(HoopRunAPIContext context)
        {
            _context = context;
        }

        // GET: api/HoopRunAPIContext
        [HttpGet]
        public IEnumerable<UserModel> GetUserModel()
        {
            return _context.UserModel;
        }

        // GET: api/HoopRunAPIContext/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _context.UserModel.SingleOrDefaultAsync(m => m.Id == id);

            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // GET: api/HoopRunAPIContext/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetUserModel([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _context.UserModel.SingleOrDefaultAsync(m => m.Firstname == name);

            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // PUT: api/HoopRunAPIContext/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel([FromRoute] int id, [FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST: api/HoopRunAPIContext
        [HttpPost]
        public async Task<IActionResult> PostUserModel([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserModel.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.Id }, userModel);
        }

        // DELETE: api/HoopRunAPIContext/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _context.UserModel.SingleOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.UserModel.Remove(userModel);
            await _context.SaveChangesAsync();

            return Ok(userModel);
        }

        private bool UserModelExists(int id)
        {
            return _context.UserModel.Any(e => e.Id == id);
        }
    }
}