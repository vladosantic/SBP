using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VP.Models;

namespace VP.Controllers
{
    public class MarkaController : Controller
    {
        private readonly SustaviBpContext _context;

        public MarkaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: Marka
        public async Task<IActionResult> Index()
        {
              return _context.Markas != null ? 
                          View(await _context.Markas.ToListAsync()) :
                          Problem("Entity set 'SustaviBpContext.Markas'  is null.");
        }

        // GET: Marka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Markas == null)
            {
                return NotFound();
            }

            var marka = await _context.Markas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // GET: Marka/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marka);
        }

        // GET: Marka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Markas == null)
            {
                return NotFound();
            }

            var marka = await _context.Markas.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }

        // POST: Marka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Marka marka)
        {
            if (id != marka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkaExists(marka.Id))
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
            return View(marka);
        }

        // GET: Marka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Markas == null)
            {
                return NotFound();
            }

            var marka = await _context.Markas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // POST: Marka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Markas == null)
            {
                return Problem("Entity set 'SustaviBpContext.Markas'  is null.");
            }
            var marka = await _context.Markas.FindAsync(id);
            if (marka != null)
            {
                _context.Markas.Remove(marka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkaExists(int id)
        {
          return (_context.Markas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
