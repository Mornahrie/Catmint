using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catmint.Data;
using Catmint.Models;

namespace Catmint.Controllers
{
    public class LazalkasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LazalkasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lazalkas
        public async Task<IActionResult> Index()
        {
              return _context.Lazalki != null ? 
                          View(await _context.Lazalki.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Lazalki'  is null.");
        }

        // GET: Lazalkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lazalki == null)
            {
                return NotFound();
            }

            var lazalka = await _context.Lazalki
                .FirstOrDefaultAsync(m => m.place_id == id);
            if (lazalka == null)
            {
                return NotFound();
            }

            return View(lazalka);
        }

        // GET: Lazalkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lazalkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("place_id,place_num")] Lazalka lazalka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lazalka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lazalka);
        }

        // GET: Lazalkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lazalki == null)
            {
                return NotFound();
            }

            var lazalka = await _context.Lazalki.FindAsync(id);
            if (lazalka == null)
            {
                return NotFound();
            }
            return View(lazalka);
        }

        // POST: Lazalkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("place_id,place_num")] Lazalka lazalka)
        {
            if (id != lazalka.place_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lazalka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LazalkaExists(lazalka.place_id))
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
            return View(lazalka);
        }

        // GET: Lazalkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lazalki == null)
            {
                return NotFound();
            }

            var lazalka = await _context.Lazalki
                .FirstOrDefaultAsync(m => m.place_id == id);
            if (lazalka == null)
            {
                return NotFound();
            }

            return View(lazalka);
        }

        // POST: Lazalkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lazalki == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lazalki'  is null.");
            }
            var lazalka = await _context.Lazalki.FindAsync(id);
            if (lazalka != null)
            {
                _context.Lazalki.Remove(lazalka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LazalkaExists(int id)
        {
          return (_context.Lazalki?.Any(e => e.place_id == id)).GetValueOrDefault();
        }
    }
}
