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
    public class DodjelaVozilaController : Controller
    {
        private readonly SustaviBpContext _context;

        public DodjelaVozilaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: DodjelaVozila
        public async Task<IActionResult> Index()
        {
            var sustaviBpContext = _context.DodjelaVozilas
                .Include(d => d.IdUposlenikaNavigation)
                .Include(d => d.IdVozilaNavigation)
                    .ThenInclude(v => v.ModelVozilaNavigation); 

            var dodjelaVozilas = await sustaviBpContext.ToListAsync();

            return View(dodjelaVozilas);
        }

        // GET: DodjelaVozila/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DodjelaVozilas == null)
            {
                return NotFound();
            }

            var dodjelaVozila = await _context.DodjelaVozilas
                .Include(d => d.IdUposlenikaNavigation)
                .Include(d => d.IdVozilaNavigation)
                    .ThenInclude(v => v.ModelVozilaNavigation)
                      
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dodjelaVozila == null)
            {
                return NotFound();
            }

            return View(dodjelaVozila);
        }



        // GET: DodjelaVozila/Create
        public IActionResult Create()
        {
            ViewData["IdUposlenika"] = new SelectList(_context.Uposleniks, "IdUposlenik", "ImePrezime");
            ViewData["IdVozila"] = new SelectList(_context.Vozilos, "IdVozila", "RegistracijskaOznaka");
            return View();
        }

        // POST: DodjelaVozila/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUposlenika,IdVozila,Dodjeljeno,VratitiDo,Dodatak")] DodjelaVozila dodjelaVozila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodjelaVozila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUposlenika"] = new SelectList(_context.Uposleniks, "IdUposlenik", "ImePrezime", dodjelaVozila.IdUposlenika);
            ViewData["IdVozila"] = new SelectList(_context.Vozilos, "IdVozila", "RegistracijskaOznaka", dodjelaVozila.IdVozila);
            return View(dodjelaVozila);
        }

        // GET: DodjelaVozila/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DodjelaVozilas == null)
            {
                return NotFound();
            }

            var dodjelaVozila = await _context.DodjelaVozilas.FindAsync(id);
            if (dodjelaVozila == null)
            {
                return NotFound();
            }
            ViewData["IdUposlenika"] = new SelectList(_context.Uposleniks, "IdUposlenik", "ImePrezime", dodjelaVozila.IdUposlenika);
            ViewData["IdVozila"] = new SelectList(_context.Vozilos, "IdVozila", "RegistracijskaOznaka", dodjelaVozila.IdVozila);
            return View(dodjelaVozila);
        }

        // POST: DodjelaVozila/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUposlenika,IdVozila,Dodjeljeno,VratitiDo,Dodatak")] DodjelaVozila dodjelaVozila)
        {
            if (id != dodjelaVozila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodjelaVozila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodjelaVozilaExists(dodjelaVozila.Id))
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
            ViewData["IdUposlenika"] = new SelectList(_context.Uposleniks, "IdUposlenik", "ImePrezime", dodjelaVozila.IdUposlenika);
            ViewData["IdVozila"] = new SelectList(_context.Vozilos, "IdVozila", "RegistracijskaOznaka", dodjelaVozila.IdVozila);
            return View(dodjelaVozila);
        }

        // GET: DodjelaVozila/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DodjelaVozilas == null)
            {
                return NotFound();
            }

            var dodjelaVozila = await _context.DodjelaVozilas
                .Include(d => d.IdUposlenikaNavigation)
                .Include(d => d.IdVozilaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dodjelaVozila == null)
            {
                return NotFound();
            }

            return View(dodjelaVozila);
        }

        // POST: DodjelaVozila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DodjelaVozilas == null)
            {
                return Problem("Entity set 'SustaviBpContext.DodjelaVozilas'  is null.");
            }
            var dodjelaVozila = await _context.DodjelaVozilas.FindAsync(id);
            if (dodjelaVozila != null)
            {
                _context.DodjelaVozilas.Remove(dodjelaVozila);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodjelaVozilaExists(int id)
        {
          return (_context.DodjelaVozilas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
