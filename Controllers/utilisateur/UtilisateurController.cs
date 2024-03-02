using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mikolo;

namespace mikolo.Controllers.utilisateur
{
    public class UtilisateurController : Controller
    {
        private readonly MikoloContext _context;

        public UtilisateurController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Utilisateur
        public async Task<IActionResult> Index()
        {
            var mikoloContext = _context.Utilisateurs.Include(u => u.IdPointDeVenteNavigation);
            return View(await mikoloContext.ToListAsync());
        }

        // GET: Utilisateur/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs
                .Include(u => u.IdPointDeVenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: Utilisateur/Create
        public IActionResult Create()
        {
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id");
            return View();
        }

        // POST: Utilisateur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,DateEmbauche,DateResilliation,IdPointDeVente")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", utilisateur.IdPointDeVente);
            return View(utilisateur);
        }

        // GET: Utilisateur/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", utilisateur.IdPointDeVente);
            return View(utilisateur);
        }

        // POST: Utilisateur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Prenom,DateEmbauche,DateResilliation,IdPointDeVente")] Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.Id))
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
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", utilisateur.IdPointDeVente);
            return View(utilisateur);
        }

        // GET: Utilisateur/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs
                .Include(u => u.IdPointDeVenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: Utilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(string id)
        {
            return _context.Utilisateurs.Any(e => e.Id == id);
        }
    }
}
