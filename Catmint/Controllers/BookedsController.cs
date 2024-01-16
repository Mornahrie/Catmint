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
    public class BookedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookeds
        public async Task<IActionResult> Index()
        {
              return _context.Bookeds != null ? 
                          View(await _context.Bookeds.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Bookeds'  is null.");
        }

        // GET: Bookeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookeds == null)
            {
                return NotFound();
            }

            var booked = await _context.Bookeds
                .FirstOrDefaultAsync(m => m.book_id == id);
            if (booked == null)
            {
                return NotFound();
            }

            return View(booked);
        }

        // GET: Bookeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("book_id,table_id,user_id,booked_date")] Booked booked)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booked);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booked);
        }

        // GET: Bookeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookeds == null)
            {
                return NotFound();
            }

            var booked = await _context.Bookeds.FindAsync(id);
            if (booked == null)
            {
                return NotFound();
            }
            return View(booked);
        }

        // POST: Bookeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("book_id,table_id,user_id,booked_date")] Booked booked)
        {
            if (id != booked.book_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booked);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookedExists(booked.book_id))
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
            return View(booked);
        }

        // GET: Bookeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookeds == null)
            {
                return NotFound();
            }

            var booked = await _context.Bookeds
                .FirstOrDefaultAsync(m => m.book_id == id);
            if (booked == null)
            {
                return NotFound();
            }

            return View(booked);
        }

        // POST: Bookeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookeds == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bookeds'  is null.");
            }
            var booked = await _context.Bookeds.FindAsync(id);
            if (booked != null)
            {
                _context.Bookeds.Remove(booked);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookedExists(int id)
        {
          return (_context.Bookeds?.Any(e => e.book_id == id)).GetValueOrDefault();
        }
    }
}
