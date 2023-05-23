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
    public class VoziloController : Controller
    {
        private readonly SustaviBpContext _context;

        public VoziloController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: Vozilo
        public async Task<IActionResult> Index()
        {
            var sustaviBpContext = _context.Vozilos.Include(v => v.IdLokacijeNavigation).Include(v => v.ModelVozilaNavigation).Include(v => v.VrstaVozilaNavigation);
            return View(await sustaviBpContext.ToListAsync());
        }

        // GET: Vozilo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vozilos == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilos
                .Include(v => v.IdLokacijeNavigation)
                .Include(v => v.ModelVozilaNavigation)
                .Include(v => v.VrstaVozilaNavigation)
                .FirstOrDefaultAsync(m => m.IdVozila == id);
            if (vozilo == null)
            {
                return NotFound();
            }

            return View(vozilo);
        }

        // GET: Vozilo/Create
        public IActionResult Create()
        {
            ViewData["IdLokacije"] = new SelectList(_context.LokacijaVozilas, "Id", "NazivLokacije");
            ViewData["ModelVozila"] = new SelectList(_context.ModelVozilas, "Id", "Naziv");
            ViewData["VrstaVozila"] = new SelectList(_context.VrstaVozilas, "VrstaId", "Naziv");
            return View();
        }

        // POST: Vozilo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVozila,ModelVozila,BrojSasije,RegistracijskaOznaka,GodinaProizvodnje,VrstaVozila,IdLokacije,Gorivo,Kategorija")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vozilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLokacije"] = new SelectList(_context.LokacijaVozilas, "Id", "NazivLokacije", vozilo.IdLokacije);
            ViewData["ModelVozila"] = new SelectList(_context.ModelVozilas, "Id", "Naziv", vozilo.ModelVozila);
            ViewData["VrstaVozila"] = new SelectList(_context.VrstaVozilas, "VrstaId", "Naziv", vozilo.VrstaVozila);
            return View(vozilo);
        }

        // GET: Vozilo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vozilos == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilos.FindAsync(id);
            if (vozilo == null)
            {
                return NotFound();
            }
            ViewData["IdLokacije"] = new SelectList(_context.LokacijaVozilas, "Id", "NazivLokacije", vozilo.IdLokacije);
            ViewData["ModelVozila"] = new SelectList(_context.ModelVozilas, "Id", "Naziv", vozilo.ModelVozila);
            ViewData["VrstaVozila"] = new SelectList(_context.VrstaVozilas, "VrstaId", "Naziv", vozilo.VrstaVozila);
            return View(vozilo);
        }

        // POST: Vozilo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVozila,ModelVozila,BrojSasije,RegistracijskaOznaka,GodinaProizvodnje,VrstaVozila,IdLokacije,Gorivo,Kategorija")] Vozilo vozilo)
        {
            if (id != vozilo.IdVozila)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vozilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoziloExists(vozilo.IdVozila))
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
            ViewData["IdLokacije"] = new SelectList(_context.LokacijaVozilas, "Id", "NazivLokacije", vozilo.IdLokacije);
            ViewData["ModelVozila"] = new SelectList(_context.ModelVozilas, "Id", "Naziv", vozilo.ModelVozila);
            ViewData["VrstaVozila"] = new SelectList(_context.VrstaVozilas, "VrstaId", "Naziv", vozilo.VrstaVozila);
            return View(vozilo);
        }

        // GET: Vozilo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vozilos == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilos
                .Include(v => v.IdLokacijeNavigation)
                .Include(v => v.ModelVozilaNavigation)
                .Include(v => v.VrstaVozilaNavigation)
                .FirstOrDefaultAsync(m => m.IdVozila == id);
            if (vozilo == null)
            {
                return NotFound();
            }

            return View(vozilo);
        }

        // POST: Vozilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vozilos == null)
            {
                return Problem("Entity set 'SustaviBpContext.Vozilos'  is null.");
            }
            var vozilo = await _context.Vozilos.FindAsync(id);
            if (vozilo != null)
            {
                _context.Vozilos.Remove(vozilo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoziloExists(int id)
        {
          return (_context.Vozilos?.Any(e => e.IdVozila == id)).GetValueOrDefault();
        }
    }
}
