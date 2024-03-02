using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mikolo
{
    public class ProcesseurController : Controller
    {
        private readonly MikoloContext _context;

        public ProcesseurController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Processeur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Processeurs.ToListAsync());
        }

        // GET: Processeur/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processeur = await _context.Processeurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processeur == null)
            {
                return NotFound();
            }

            return View(processeur);
        }

        // GET: Processeur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processeur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Frequence,Coeur,Gravure")] Processeur processeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processeur);
        }

        // GET: Processeur/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processeur = await _context.Processeurs.FindAsync(id);
            if (processeur == null)
            {
                return NotFound();
            }
            return View(processeur);
        }

        // POST: Processeur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Label,Frequence,Coeur,Gravure")] Processeur processeur)
        {
            if (id != processeur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesseurExists(processeur.Id))
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
            return View(processeur);
        }

        // GET: Processeur/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processeur = await _context.Processeurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processeur == null)
            {
                return NotFound();
            }

            return View(processeur);
        }

        // POST: Processeur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var processeur = await _context.Processeurs.FindAsync(id);
            if (processeur != null)
            {
                _context.Processeurs.Remove(processeur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesseurExists(string id)
        {
            return _context.Processeurs.Any(e => e.Id == id);
        }
    }
}
