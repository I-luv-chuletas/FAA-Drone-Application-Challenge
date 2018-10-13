using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FAADroneRegistrationApplication.Models;

namespace FAADroneRegistrationApplication.Controllers
{
    public class ConsumerDronesController : Controller
    {
        private readonly FAADroneRegistrationApplicationContext _context;

        public ConsumerDronesController(FAADroneRegistrationApplicationContext context)
        {
            _context = context;
        }

        // GET: ConsumerDrones
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsumerDrones.ToListAsync());
        }

        // GET: ConsumerDrones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumerDrones = await _context.ConsumerDrones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consumerDrones == null)
            {
                return NotFound();
            }

            return View(consumerDrones);
        }

        // GET: ConsumerDrones/Create
        public IActionResult Create(int userID)
        {
            return View();
        }

        // POST: ConsumerDrones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Make,Model")] ConsumerDrones consumerDrones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumerDrones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumerDrones);
        }

        // GET: ConsumerDrones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumerDrones = await _context.ConsumerDrones.FindAsync(id);
            if (consumerDrones == null)
            {
                return NotFound();
            }
            return View(consumerDrones);
        }

        // POST: ConsumerDrones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Make,Model")] ConsumerDrones consumerDrones)
        {
            if (id != consumerDrones.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumerDrones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumerDronesExists(consumerDrones.ID))
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
            return View(consumerDrones);
        }

        // GET: ConsumerDrones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumerDrones = await _context.ConsumerDrones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consumerDrones == null)
            {
                return NotFound();
            }

            return View(consumerDrones);
        }

        // POST: ConsumerDrones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumerDrones = await _context.ConsumerDrones.FindAsync(id);
            _context.ConsumerDrones.Remove(consumerDrones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumerDronesExists(int id)
        {
            return _context.ConsumerDrones.Any(e => e.ID == id);
        }
    }
}
