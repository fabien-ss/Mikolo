using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mikolo;

namespace mikolo.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly MikoloContext _context;

        public ReferenceController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Reference
        public async Task<IActionResult> Index()
        {
            var mikoloContext = _context.References.Include(r => r.IdMarqueNavigation);
            return View(await mikoloContext.ToListAsync());
        }

        // GET: Reference/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .Include(r => r.IdMarqueNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: Reference/Create
        public IActionResult Create()
        {
            ViewData["IdMarque"] = new SelectList(_context.Marques, "Id", "Id");
            return View();
        }

        // POST: Reference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMarque,Label")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarque"] = new SelectList(_context.Marques, "Id", "Id", reference.IdMarque);
            return View(reference);
        }

        // GET: Reference/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }
            ViewData["IdMarque"] = new SelectList(_context.Marques, "Id", "Id", reference.IdMarque);
            return View(reference);
        }

        // POST: Reference/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IdMarque,Label")] Reference reference)
        {
            if (id != reference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.Id))
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
            ViewData["IdMarque"] = new SelectList(_context.Marques, "Id", "Id", reference.IdMarque);
            return View(reference);
        }

        // GET: Reference/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .Include(r => r.IdMarqueNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: Reference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reference = await _context.References.FindAsync(id);
            if (reference != null)
            {
                _context.References.Remove(reference);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceExists(string id)
        {
            return _context.References.Any(e => e.Id == id);
        }
    }
}
