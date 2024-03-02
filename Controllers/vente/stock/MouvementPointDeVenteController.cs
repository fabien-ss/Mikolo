using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mikolo;

namespace mikolo.Controllers.vente.stock
{
    public class MouvementPointDeVenteController : Controller
    {
        private readonly MikoloContext _context;

        public MouvementPointDeVenteController(MikoloContext context)
        {
            _context = context;
        }

        // GET: MouvementPointDeVente
        public async Task<IActionResult> Index()
        {
            var mikoloContext = _context.MouvementPointDeVentes.Include(m => m.IdLaptopNavigation).Include(m => m.IdPointDeVenteNavigation);
            return View(await mikoloContext.ToListAsync());
        }

        // GET: MouvementPointDeVente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvementPointDeVente = await _context.MouvementPointDeVentes
                .Include(m => m.IdLaptopNavigation)
                .Include(m => m.IdPointDeVenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouvementPointDeVente == null)
            {
                return NotFound();
            }

            return View(mouvementPointDeVente);
        }

        // GET: MouvementPointDeVente/Create
        public IActionResult Create()
        {
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id");
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id");
            return View();
        }

        // POST: MouvementPointDeVente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdLaptop,IdPointDeVente,Entree,Sortie")] MouvementPointDeVente mouvementPointDeVente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouvementPointDeVente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", mouvementPointDeVente.IdLaptop);
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", mouvementPointDeVente.IdPointDeVente);
            return View(mouvementPointDeVente);
        }

        // GET: MouvementPointDeVente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvementPointDeVente = await _context.MouvementPointDeVentes.FindAsync(id);
            if (mouvementPointDeVente == null)
            {
                return NotFound();
            }
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", mouvementPointDeVente.IdLaptop);
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", mouvementPointDeVente.IdPointDeVente);
            return View(mouvementPointDeVente);
        }

        // POST: MouvementPointDeVente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdLaptop,IdPointDeVente,Entree,Sortie")] MouvementPointDeVente mouvementPointDeVente)
        {
            if (id != mouvementPointDeVente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouvementPointDeVente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouvementPointDeVenteExists(mouvementPointDeVente.Id))
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
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", mouvementPointDeVente.IdLaptop);
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", mouvementPointDeVente.IdPointDeVente);
            return View(mouvementPointDeVente);
        }

        // GET: MouvementPointDeVente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvementPointDeVente = await _context.MouvementPointDeVentes
                .Include(m => m.IdLaptopNavigation)
                .Include(m => m.IdPointDeVenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouvementPointDeVente == null)
            {
                return NotFound();
            }

            return View(mouvementPointDeVente);
        }

        // POST: MouvementPointDeVente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mouvementPointDeVente = await _context.MouvementPointDeVentes.FindAsync(id);
            if (mouvementPointDeVente != null)
            {
                _context.MouvementPointDeVentes.Remove(mouvementPointDeVente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouvementPointDeVenteExists(int id)
        {
            return _context.MouvementPointDeVentes.Any(e => e.Id == id);
        }
    }
}
