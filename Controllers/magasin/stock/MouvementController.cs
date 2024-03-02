using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mikolo;

namespace mikolo.Controllers.magasin
{
    public class MouvementController : Controller
    {
        private readonly MikoloContext _context;

        public MouvementController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Mouvement
        public async Task<IActionResult> Index()
        {
            var mikoloContext = _context.Mouvements.Include(m => m.IdLaptopNavigation);
            return View(await mikoloContext.ToListAsync());
        }

        // GET: Mouvement/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvement = await _context.Mouvements
                .Include(m => m.IdLaptopNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouvement == null)
            {
                return NotFound();
            }

            return View(mouvement);
        }

        // GET: Mouvement/Create
        public IActionResult Create()
        {
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id");
            return View();
        }

        // POST: Mouvement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateMouvement,IdLaptop,Entree,Sortie")] Mouvement mouvement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouvement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", mouvement.IdLaptop);
            return View(mouvement);
        }

        // GET: Mouvement/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvement = await _context.Mouvements.FindAsync(id);
            if (mouvement == null)
            {
                return NotFound();
            }
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", mouvement.IdLaptop);
            return View(mouvement);
        }

        // POST: Mouvement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DateMouvement,IdLaptop,Entree,Sortie")] Mouvement mouvement)
        {
            if (id != mouvement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouvement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouvementExists(mouvement.Id))
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
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", mouvement.IdLaptop);
            return View(mouvement);
        }

        // GET: Mouvement/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvement = await _context.Mouvements
                .Include(m => m.IdLaptopNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouvement == null)
            {
                return NotFound();
            }

            return View(mouvement);
        }

        // POST: Mouvement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mouvement = await _context.Mouvements.FindAsync(id);
            if (mouvement != null)
            {
                _context.Mouvements.Remove(mouvement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouvementExists(string id)
        {
            return _context.Mouvements.Any(e => e.Id == id);
        }
    }
}
