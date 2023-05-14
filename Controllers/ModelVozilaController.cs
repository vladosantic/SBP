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
    public class ModelVozilaController : Controller
    {
        private readonly SustaviBpContext _context;

        public ModelVozilaController(SustaviBpContext context)
        {
            _context = context;
        }

        // GET: ModelVozila
        public async Task<IActionResult> Index()
        {
            var sustaviBpContext = _context.ModelVozilas.Include(m => m.IdMarkeNavigation);
            return View(await sustaviBpContext.ToListAsync());
        }

        // GET: ModelVozila/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelVozilas == null)
            {
                return NotFound();
            }

            var modelVozila = await _context.ModelVozilas
                .Include(m => m.IdMarkeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelVozila == null)
            {
                return NotFound();
            }

            return View(modelVozila);
        }

        // GET: ModelVozila/Create
        public IActionResult Create()
        {
            ViewData["IdMarke"] = new SelectList(_context.Markas, "Id", "Id");
            return View();
        }

        // POST: ModelVozila/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,IdMarke")] ModelVozila modelVozila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelVozila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarke"] = new SelectList(_context.Markas, "Id", "Id", modelVozila.IdMarke);
            return View(modelVozila);
        }

        // GET: ModelVozila/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelVozilas == null)
            {
                return NotFound();
            }

            var modelVozila = await _context.ModelVozilas.FindAsync(id);
            if (modelVozila == null)
            {
                return NotFound();
            }
            ViewData["IdMarke"] = new SelectList(_context.Markas, "Id", "Id", modelVozila.IdMarke);
            return View(modelVozila);
        }

        // POST: ModelVozila/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,IdMarke")] ModelVozila modelVozila)
        {
            if (id != modelVozila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelVozila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelVozilaExists(modelVozila.Id))
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
            ViewData["IdMarke"] = new SelectList(_context.Markas, "Id", "Id", modelVozila.IdMarke);
            return View(modelVozila);
        }

        // GET: ModelVozila/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelVozilas == null)
            {
                return NotFound();
            }

            var modelVozila = await _context.ModelVozilas
                .Include(m => m.IdMarkeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelVozila == null)
            {
                return NotFound();
            }

            return View(modelVozila);
        }

        // POST: ModelVozila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelVozilas == null)
            {
                return Problem("Entity set 'SustaviBpContext.ModelVozilas'  is null.");
            }
            var modelVozila = await _context.ModelVozilas.FindAsync(id);
            if (modelVozila != null)
            {
                _context.ModelVozilas.Remove(modelVozila);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelVozilaExists(int id)
        {
          return (_context.ModelVozilas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
