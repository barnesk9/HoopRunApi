using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoopRunAPI.Models;

namespace HoopRunAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/player")]
    public class PlayerController : Controller
    {
        private readonly HoopRunAPIContext _context;

        public PlayerController(HoopRunAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Player
        public async Task<IActionResult> Index()
        {
            var pm = await _context.Player.ToListAsync();
            return Ok(pm);
        }

        [HttpGet("{id}")]
        // GET: Player/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerModel = await _context.Player
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playerModel == null)
            {
                return NotFound();
            }

            return Ok(playerModel);
        }

        // GET: Player/Create
        [Route("api/player/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Firstname,Lastname,ProfilePicture,Status")] Player playerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerModel);
        }

        // GET: Player/Edit/5
        [Route("api/player/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerModel = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            if (playerModel == null)
            {
                return NotFound();
            }
            return View(playerModel);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,Firstname,Lastname,ProfilePicture,Status")] Player playerModel)
        {
            if (id != playerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(playerModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playerModel);
        }

        // GET: Player/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerModel = await _context.Player
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playerModel == null)
            {
                return NotFound();
            }

            return View(playerModel);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerModel = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            _context.Player.Remove(playerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
