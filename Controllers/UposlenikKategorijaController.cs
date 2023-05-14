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
    public class UposlenikKategorijaController : Controller
    {
        private readonly SustaviBpContext _context;

        public UposlenikKategorijaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: UposlenikKategorija
        public async Task<IActionResult> Index()
        {
            var sustaviBpContext = _context.UposlenikKategorijas.Include(u => u.IdKategorijeNavigation).Include(u => u.IdUposlenikNavigation);
            return View(await sustaviBpContext.ToListAsync());
        }

        // GET: UposlenikKategorija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UposlenikKategorijas == null)
            {
                return NotFound();
            }

            var uposlenikKategorija = await _context.UposlenikKategorijas
                .Include(u => u.IdKategorijeNavigation)
                .Include(u => u.IdUposlenikNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uposlenikKategorija == null)
            {
                return NotFound();
            }

            return View(uposlenikKategorija);
        }

        // GET: UposlenikKategorija/Create
        public IActionResult Create()
        {
            ViewData["IdKategorije"] = new SelectList(_context.Kategorijas, "IdKategorije", "IdKategorije");
            ViewData["IdUposlenik"] = new SelectList(_context.Uposleniks, "IdUposlenik", "IdUposlenik");
            return View();
        }

        // POST: UposlenikKategorija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUposlenik,IdKategorije")] UposlenikKategorija uposlenikKategorija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uposlenikKategorija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKategorije"] = new SelectList(_context.Kategorijas, "IdKategorije", "IdKategorije", uposlenikKategorija.IdKategorije);
            ViewData["IdUposlenik"] = new SelectList(_context.Uposleniks, "IdUposlenik", "IdUposlenik", uposlenikKategorija.IdUposlenik);
            return View(uposlenikKategorija);
        }

        // GET: UposlenikKategorija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UposlenikKategorijas == null)
            {
                return NotFound();
            }

            var uposlenikKategorija = await _context.UposlenikKategorijas.FindAsync(id);
            if (uposlenikKategorija == null)
            {
                return NotFound();
            }
            ViewData["IdKategorije"] = new SelectList(_context.Kategorijas, "IdKategorije", "IdKategorije", uposlenikKategorija.IdKategorije);
            ViewData["IdUposlenik"] = new SelectList(_context.Uposleniks, "IdUposlenik", "IdUposlenik", uposlenikKategorija.IdUposlenik);
            return View(uposlenikKategorija);
        }

        // POST: UposlenikKategorija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUposlenik,IdKategorije")] UposlenikKategorija uposlenikKategorija)
        {
            if (id != uposlenikKategorija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uposlenikKategorija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UposlenikKategorijaExists(uposlenikKategorija.Id))
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
            ViewData["IdKategorije"] = new SelectList(_context.Kategorijas, "IdKategorije", "IdKategorije", uposlenikKategorija.IdKategorije);
            ViewData["IdUposlenik"] = new SelectList(_context.Uposleniks, "IdUposlenik", "IdUposlenik", uposlenikKategorija.IdUposlenik);
            return View(uposlenikKategorija);
        }

        // GET: UposlenikKategorija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UposlenikKategorijas == null)
            {
                return NotFound();
            }

            var uposlenikKategorija = await _context.UposlenikKategorijas
                .Include(u => u.IdKategorijeNavigation)
                .Include(u => u.IdUposlenikNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uposlenikKategorija == null)
            {
                return NotFound();
            }

            return View(uposlenikKategorija);
        }

        // POST: UposlenikKategorija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UposlenikKategorijas == null)
            {
                return Problem("Entity set 'SustaviBpContext.UposlenikKategorijas'  is null.");
            }
            var uposlenikKategorija = await _context.UposlenikKategorijas.FindAsync(id);
            if (uposlenikKategorija != null)
            {
                _context.UposlenikKategorijas.Remove(uposlenikKategorija);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UposlenikKategorijaExists(int id)
        {
          return (_context.UposlenikKategorijas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
