using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoopRunAPI.Models;
using Microsoft.Extensions.Configuration;

namespace HoopRunAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly HoopRunAPIContext _context;

        public UserController(HoopRunAPIContext context)
        {
            _context = context;
        }

        // GET: User
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserModel.ToListAsync());
        }
        */

        public async Task<IActionResult> Index(string fieldToSort, string sortType)
        {
            var users = from u in _context.UserModel
                select u;

            ViewData["userCount"] = users.Count();

            if (sortType == null)
            {
                sortType = "asc";
            }

            switch (fieldToSort)
            {
                case "uname":
                    if (sortType == "desc")
                    {
                        ViewData["sortType"] = "asc";
                        users = users.OrderByDescending(u => u.Username);
                    }
                    else
                    {
                        ViewData["sortType"] = "desc";
                        users = users.OrderBy(u => u.Username);
                    }
                    break;

                case "fname":
                    if (sortType == "desc")
                    {
                        ViewData["sortType"] = "asc";
                        users = users.OrderByDescending(u => u.Firstname);
                    }
                    else
                    {
                        ViewData["sortType"] = "desc";
                        users = users.OrderBy(u => u.Firstname);
                    }

                    break;

                case "lname":
                    if (sortType == "desc")
                    {
                        ViewData["sortType"] = "asc";
                        users = users.OrderByDescending(u => u.Lastname);
                    }
                    else
                    {
                        ViewData["sortType"] = "desc";
                        users = users.OrderBy(u => u.Lastname);
                    }
                    break;


                case "email":
                    if (sortType == "desc")
                    {
                        ViewData["sortType"] = "asc";
                        users = users.OrderByDescending(u => u.Email);
                    }
                    else
                    {
                        ViewData["sortType"] = "desc";
                        users = users.OrderBy(u => u.Email);
                    }
                    break;

                default:
                    ViewData["sortType"] = "desc";
                    ViewData["sortField"] = "uname";
                    users = users.OrderBy(u => u.Username);
                    break;
            }

            return View(await users.ToListAsync());
        }
        /*
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var students = from s in db.Students
                select s;
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            return View(students.ToList());
        }*/

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Username,Email,Firstname,Lastname,Status")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel.SingleOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Username,Email,Firstname,Lastname,Status,address")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
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
            return View(userModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.UserModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserModel.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string query, string searchType)
        {
            var users = from u in _context.UserModel
                select u;

            switch (searchType)
            {
                case "uname":
                    users = users.Where(u => u.Username.Contains(query));
                    break;

                case "fname":
                    users = users.Where(u => u.Firstname.Contains(query));
                    break;

                case "lname":
                    users = users.Where(u => u.Lastname.Contains(query));
                    break;

                case "email":
                    users = users.Where(u => u.Email.Contains(query));
                    break;

                default:
                    users = users.OrderBy(u => u.Username);
                    break;
            }

            ViewData["TotalResults"] = users.Count();
            return View(users);
        }

        private bool UserModelExists(int id)
        {
            return _context.UserModel.Any(e => e.Id == id);
        }
    }
}