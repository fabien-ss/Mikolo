using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mikolo;

namespace mikolo.Controllers.vente
{
    public class PointDeVenteController : Controller
    {
        private readonly MikoloContext _context;

        public PointDeVenteController(MikoloContext context)
        {
            _context = context;
        }

        // GET: PointDeVente
        public async Task<IActionResult> Index()
        {
            return View(await _context.PointDeVentes.ToListAsync());
        }

        // GET: PointDeVente/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointDeVente = await _context.PointDeVentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointDeVente == null)
            {
                return NotFound();
            }

            return View(pointDeVente);
        }

        // GET: PointDeVente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PointDeVente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Adresse,Longitude,Latitude")] PointDeVente pointDeVente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointDeVente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pointDeVente);
        }

        // GET: PointDeVente/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointDeVente = await _context.PointDeVentes.FindAsync(id);
            if (pointDeVente == null)
            {
                return NotFound();
            }
            return View(pointDeVente);
        }

        // POST: PointDeVente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Label,Adresse,Longitude,Latitude")] PointDeVente pointDeVente)
        {
            if (id != pointDeVente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointDeVente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointDeVenteExists(pointDeVente.Id))
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
            return View(pointDeVente);
        }

        // GET: PointDeVente/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointDeVente = await _context.PointDeVentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointDeVente == null)
            {
                return NotFound();
            }

            return View(pointDeVente);
        }

        // POST: PointDeVente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pointDeVente = await _context.PointDeVentes.FindAsync(id);
            if (pointDeVente != null)
            {
                _context.PointDeVentes.Remove(pointDeVente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointDeVenteExists(string id)
        {
            return _context.PointDeVentes.Any(e => e.Id == id);
        }
    }
}
