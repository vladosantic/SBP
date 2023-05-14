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
    public class PozicijaController : Controller
    {
        private readonly SustaviBpContext _context;

        public PozicijaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: Pozicija
        public async Task<IActionResult> Index()
        {
              return _context.Pozicijas != null ? 
                          View(await _context.Pozicijas.ToListAsync()) :
                          Problem("Entity set 'SustaviBpContext.Pozicijas'  is null.");
        }

        // GET: Pozicija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pozicijas == null)
            {
                return NotFound();
            }

            var pozicija = await _context.Pozicijas
                .FirstOrDefaultAsync(m => m.PozicijaId == id);
            if (pozicija == null)
            {
                return NotFound();
            }

            return View(pozicija);
        }

        // GET: Pozicija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pozicija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PozicijaId,Naziv")] Pozicija pozicija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozicija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozicija);
        }

        // GET: Pozicija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pozicijas == null)
            {
                return NotFound();
            }

            var pozicija = await _context.Pozicijas.FindAsync(id);
            if (pozicija == null)
            {
                return NotFound();
            }
            return View(pozicija);
        }

        // POST: Pozicija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PozicijaId,Naziv")] Pozicija pozicija)
        {
            if (id != pozicija.PozicijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozicija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozicijaExists(pozicija.PozicijaId))
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
            return View(pozicija);
        }

        // GET: Pozicija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pozicijas == null)
            {
                return NotFound();
            }

            var pozicija = await _context.Pozicijas
                .FirstOrDefaultAsync(m => m.PozicijaId == id);
            if (pozicija == null)
            {
                return NotFound();
            }

            return View(pozicija);
        }

        // POST: Pozicija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pozicijas == null)
            {
                return Problem("Entity set 'SustaviBpContext.Pozicijas'  is null.");
            }
            var pozicija = await _context.Pozicijas.FindAsync(id);
            if (pozicija != null)
            {
                _context.Pozicijas.Remove(pozicija);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozicijaExists(int id)
        {
          return (_context.Pozicijas?.Any(e => e.PozicijaId == id)).GetValueOrDefault();
        }
    }
}
