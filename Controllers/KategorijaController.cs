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
    public class KategorijaController : Controller
    {
        private readonly SustaviBpContext _context;

        public KategorijaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: Kategorija
        public async Task<IActionResult> Index()
        {
              return _context.Kategorijas != null ? 
                          View(await _context.Kategorijas.ToListAsync()) :
                          Problem("Entity set 'SustaviBpContext.Kategorijas'  is null.");
        }

        // GET: Kategorija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kategorijas == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorijas
                .FirstOrDefaultAsync(m => m.IdKategorije == id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return View(kategorija);
        }

        // GET: Kategorija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategorija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKategorije,NazivKategorije,OpisKategorije")] Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorija);
        }

        // GET: Kategorija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kategorijas == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorijas.FindAsync(id);
            if (kategorija == null)
            {
                return NotFound();
            }
            return View(kategorija);
        }

        // POST: Kategorija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKategorije,NazivKategorije,OpisKategorije")] Kategorija kategorija)
        {
            if (id != kategorija.IdKategorije)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorijaExists(kategorija.IdKategorije))
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
            return View(kategorija);
        }

        // GET: Kategorija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kategorijas == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorijas
                .FirstOrDefaultAsync(m => m.IdKategorije == id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return View(kategorija);
        }

        // POST: Kategorija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kategorijas == null)
            {
                return Problem("Entity set 'SustaviBpContext.Kategorijas'  is null.");
            }
            var kategorija = await _context.Kategorijas.FindAsync(id);
            if (kategorija != null)
            {
                _context.Kategorijas.Remove(kategorija);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorijaExists(int id)
        {
          return (_context.Kategorijas?.Any(e => e.IdKategorije == id)).GetValueOrDefault();
        }
    }
}
