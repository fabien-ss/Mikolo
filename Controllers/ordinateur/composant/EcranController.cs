using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mikolo
{
    public class EcranController : Controller
    {
        private readonly MikoloContext _context;

        public EcranController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Ecran
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ecrans.ToListAsync());
        }

        // GET: Ecran/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecran = await _context.Ecrans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecran == null)
            {
                return NotFound();
            }

            return View(ecran);
        }

        // GET: Ecran/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ecran/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Taille")] Ecran ecran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ecran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ecran);
        }

        // GET: Ecran/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecran = await _context.Ecrans.FindAsync(id);
            if (ecran == null)
            {
                return NotFound();
            }
            return View(ecran);
        }

        // POST: Ecran/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Label,Taille")] Ecran ecran)
        {
            if (id != ecran.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcranExists(ecran.Id))
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
            return View(ecran);
        }

        // GET: Ecran/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecran = await _context.Ecrans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecran == null)
            {
                return NotFound();
            }

            return View(ecran);
        }

        // POST: Ecran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ecran = await _context.Ecrans.FindAsync(id);
            if (ecran != null)
            {
                _context.Ecrans.Remove(ecran);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcranExists(string id)
        {
            return _context.Ecrans.Any(e => e.Id == id);
        }
    }
}
