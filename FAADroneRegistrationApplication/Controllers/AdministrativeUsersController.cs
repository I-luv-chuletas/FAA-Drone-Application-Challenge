using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FAADroneRegistrationApplication;
using FAADroneRegistrationApplication.Models;

namespace FAADroneRegistrationApplication.Controllers
{
    public class AdministrativeUsersController : Controller
    {
        private readonly FAADroneRegistrationApplicationContext _context;

        public AdministrativeUsersController(FAADroneRegistrationApplicationContext context)
        {
            _context = context;
        }

        // GET: AdministrativeUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdministrativeUsers.ToListAsync());
        }

        // GET: AdministrativeUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUsers = await _context.AdministrativeUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (administrativeUsers == null)
            {
                return NotFound();
            }

            return View(administrativeUsers);
        }

        // GET: AdministrativeUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministrativeUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Username,Password")] AdministrativeUsers administrativeUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrativeUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrativeUsers);
        }

        // GET: AdministrativeUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUsers = await _context.AdministrativeUsers.FindAsync(id);
            if (administrativeUsers == null)
            {
                return NotFound();
            }
            return View(administrativeUsers);
        }

        // POST: AdministrativeUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Username,Password")] AdministrativeUsers administrativeUsers)
        {
            if (id != administrativeUsers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrativeUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativeUsersExists(administrativeUsers.ID))
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
            return View(administrativeUsers);
        }

        // GET: AdministrativeUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUsers = await _context.AdministrativeUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (administrativeUsers == null)
            {
                return NotFound();
            }

            return View(administrativeUsers);
        }

        // POST: AdministrativeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrativeUsers = await _context.AdministrativeUsers.FindAsync(id);
            _context.AdministrativeUsers.Remove(administrativeUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativeUsersExists(int id)
        {
            return _context.AdministrativeUsers.Any(e => e.ID == id);
        }
    }
}
