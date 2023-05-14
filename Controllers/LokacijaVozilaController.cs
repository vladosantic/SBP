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
    public class LokacijaVozilaController : Controller
    {
        private readonly SustaviBpContext _context;

        public LokacijaVozilaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: LokacijaVozila
        public async Task<IActionResult> Index()
        {
              return _context.LokacijaVozilas != null ? 
                          View(await _context.LokacijaVozilas.ToListAsync()) :
                          Problem("Entity set 'SustaviBpContext.LokacijaVozilas'  is null.");
        }

        // GET: LokacijaVozila/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LokacijaVozilas == null)
            {
                return NotFound();
            }

            var lokacijaVozila = await _context.LokacijaVozilas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lokacijaVozila == null)
            {
                return NotFound();
            }

            return View(lokacijaVozila);
        }

        // GET: LokacijaVozila/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LokacijaVozila/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivLokacije")] LokacijaVozila lokacijaVozila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokacijaVozila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokacijaVozila);
        }

        // GET: LokacijaVozila/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LokacijaVozilas == null)
            {
                return NotFound();
            }

            var lokacijaVozila = await _context.LokacijaVozilas.FindAsync(id);
            if (lokacijaVozila == null)
            {
                return NotFound();
            }
            return View(lokacijaVozila);
        }

        // POST: LokacijaVozila/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivLokacije")] LokacijaVozila lokacijaVozila)
        {
            if (id != lokacijaVozila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokacijaVozila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokacijaVozilaExists(lokacijaVozila.Id))
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
            return View(lokacijaVozila);
        }

        // GET: LokacijaVozila/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LokacijaVozilas == null)
            {
                return NotFound();
            }

            var lokacijaVozila = await _context.LokacijaVozilas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lokacijaVozila == null)
            {
                return NotFound();
            }

            return View(lokacijaVozila);
        }

        // POST: LokacijaVozila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LokacijaVozilas == null)
            {
                return Problem("Entity set 'SustaviBpContext.LokacijaVozilas'  is null.");
            }
            var lokacijaVozila = await _context.LokacijaVozilas.FindAsync(id);
            if (lokacijaVozila != null)
            {
                _context.LokacijaVozilas.Remove(lokacijaVozila);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokacijaVozilaExists(int id)
        {
          return (_context.LokacijaVozilas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
