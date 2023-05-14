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
    public class VrstaVozilaController : Controller
    {
        private readonly SustaviBpContext _context;

        public VrstaVozilaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: VrstaVozila
        public async Task<IActionResult> Index()
        {
              return _context.VrstaVozilas != null ? 
                          View(await _context.VrstaVozilas.ToListAsync()) :
                          Problem("Entity set 'SustaviBpContext.VrstaVozilas'  is null.");
        }

        // GET: VrstaVozila/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VrstaVozilas == null)
            {
                return NotFound();
            }

            var vrstaVozila = await _context.VrstaVozilas
                .FirstOrDefaultAsync(m => m.VrstaId == id);
            if (vrstaVozila == null)
            {
                return NotFound();
            }

            return View(vrstaVozila);
        }

        // GET: VrstaVozila/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VrstaVozila/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VrstaId,Naziv")] VrstaVozila vrstaVozila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vrstaVozila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vrstaVozila);
        }

        // GET: VrstaVozila/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VrstaVozilas == null)
            {
                return NotFound();
            }

            var vrstaVozila = await _context.VrstaVozilas.FindAsync(id);
            if (vrstaVozila == null)
            {
                return NotFound();
            }
            return View(vrstaVozila);
        }

        // POST: VrstaVozila/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VrstaId,Naziv")] VrstaVozila vrstaVozila)
        {
            if (id != vrstaVozila.VrstaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vrstaVozila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VrstaVozilaExists(vrstaVozila.VrstaId))
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
            return View(vrstaVozila);
        }

        // GET: VrstaVozila/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VrstaVozilas == null)
            {
                return NotFound();
            }

            var vrstaVozila = await _context.VrstaVozilas
                .FirstOrDefaultAsync(m => m.VrstaId == id);
            if (vrstaVozila == null)
            {
                return NotFound();
            }

            return View(vrstaVozila);
        }

        // POST: VrstaVozila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VrstaVozilas == null)
            {
                return Problem("Entity set 'SustaviBpContext.VrstaVozilas'  is null.");
            }
            var vrstaVozila = await _context.VrstaVozilas.FindAsync(id);
            if (vrstaVozila != null)
            {
                _context.VrstaVozilas.Remove(vrstaVozila);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VrstaVozilaExists(int id)
        {
          return (_context.VrstaVozilas?.Any(e => e.VrstaId == id)).GetValueOrDefault();
        }
    }
}
