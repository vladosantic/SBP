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
    public class UposlenikController : Controller
    {
        private readonly SustaviBpContext _context;

        public UposlenikController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: Uposlenik
        public async Task<IActionResult> Index()
        {
            var sustaviBpContext = _context.Uposleniks.Include(u => u.Pozicija);
            return View(await sustaviBpContext.ToListAsync());
        }

        // GET: Uposlenik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uposleniks == null)
            {
                return NotFound();
            }

            var uposlenik = await _context.Uposleniks
                .Include(u => u.Pozicija)
                .FirstOrDefaultAsync(m => m.IdUposlenik == id);
            if (uposlenik == null)
            {
                return NotFound();
            }

            return View(uposlenik);
        }

        // GET: Uposlenik/Create
        public IActionResult Create()
        {
            ViewData["PozicijaId"] = new SelectList(_context.Pozicijas, "PozicijaId", "PozicijaId");
            return View();
        }

        // POST: Uposlenik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUposlenik,Ime,Prezime,PozicijaId,Adresa,BrojMobitela,Jmbg,Email,DatumRodjenja")] Uposlenik uposlenik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uposlenik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PozicijaId"] = new SelectList(_context.Pozicijas, "PozicijaId", "PozicijaId", uposlenik.PozicijaId);
            return View(uposlenik);
        }

        // GET: Uposlenik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uposleniks == null)
            {
                return NotFound();
            }

            var uposlenik = await _context.Uposleniks.FindAsync(id);
            if (uposlenik == null)
            {
                return NotFound();
            }
            ViewData["PozicijaId"] = new SelectList(_context.Pozicijas, "PozicijaId", "PozicijaId", uposlenik.PozicijaId);
            return View(uposlenik);
        }

        // POST: Uposlenik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUposlenik,Ime,Prezime,PozicijaId,Adresa,BrojMobitela,Jmbg,Email,DatumRodjenja")] Uposlenik uposlenik)
        {
            if (id != uposlenik.IdUposlenik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uposlenik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UposlenikExists(uposlenik.IdUposlenik))
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
            ViewData["PozicijaId"] = new SelectList(_context.Pozicijas, "PozicijaId", "PozicijaId", uposlenik.PozicijaId);
            return View(uposlenik);
        }

        // GET: Uposlenik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uposleniks == null)
            {
                return NotFound();
            }

            var uposlenik = await _context.Uposleniks
                .Include(u => u.Pozicija)
                .FirstOrDefaultAsync(m => m.IdUposlenik == id);
            if (uposlenik == null)
            {
                return NotFound();
            }

            return View(uposlenik);
        }

        // POST: Uposlenik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uposleniks == null)
            {
                return Problem("Entity set 'SustaviBpContext.Uposleniks'  is null.");
            }
            var uposlenik = await _context.Uposleniks.FindAsync(id);
            if (uposlenik != null)
            {
                _context.Uposleniks.Remove(uposlenik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UposlenikExists(int id)
        {
          return (_context.Uposleniks?.Any(e => e.IdUposlenik == id)).GetValueOrDefault();
        }
    }
}
