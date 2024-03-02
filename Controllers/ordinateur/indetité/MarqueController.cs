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
    public class MarqueController : Controller
    {
        private MikoloContext _context;

        public MarqueController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Marque
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marques.ToListAsync());
        }

        // GET: Marque/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marque == null)
            {
                return NotFound();
            }

            return View(marque);
        }

        // GET: Marque/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] Marque marque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marque);
        }

        // GET: Marque/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques.FindAsync(id);
            if (marque == null)
            {
                return NotFound();
            }
            return View(marque);
        }

        // POST: Marque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Label")] Marque marque)
        {
            if (id != marque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarqueExists(marque.Id))
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
            return View(marque);
        }

        // GET: Marque/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marque == null)
            {
                return NotFound();
            }

            return View(marque);
        }

        // POST: Marque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var marque = await _context.Marques.FindAsync(id);
            if (marque != null)
            {
                _context.Marques.Remove(marque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarqueExists(string id)
        {
            return _context.Marques.Any(e => e.Id == id);
        }
    }
}
