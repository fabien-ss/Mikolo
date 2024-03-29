using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mikolo
{
    public class LaptopController : Controller
    {
        private MikoloContext _context;

        public LaptopController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Laptop
        public async Task<IActionResult> Index()
        {
            var mikoloContext = _context.Laptops.Include(l => l.IdDisqueDurNavigation).Include(l => l.IdEcranNavigation).Include(l => l.IdProcesseurNavigation).Include(l => l.IdRamNavigation).Include(l => l.IdReferenceNavigation);
            return View(await mikoloContext.ToListAsync());
        }

        // GET: Laptop/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.IdDisqueDurNavigation)
                .Include(l => l.IdEcranNavigation)
                .Include(l => l.IdProcesseurNavigation)
                .Include(l => l.IdRamNavigation)
                .Include(l => l.IdReferenceNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptop/Create
        public IActionResult Create()
        {
            ViewData["IdDisqueDur"] = new SelectList(_context.DisqueDurs, "Id", "Label");
            ViewData["IdEcran"] = new SelectList(_context.Ecrans, "Id", "Label");
            ViewData["IdProcesseur"] = new SelectList(_context.Processeurs, "Id", "Label");
            ViewData["IdRam"] = new SelectList(_context.Rams, "Id", "Label");
            ViewData["IdReference"] = new SelectList(_context.References, "Id", "Label");
            return View();
        }

        // POST: Laptop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReference,IdProcesseur,IdRam,IdEcran,IdDisqueDur")] Laptop laptop)
        {
            Console.WriteLine("Read");
            Console.WriteLine("json object id proc "+ laptop.IdProcesseur);
            Console.WriteLine("json object id " + laptop.Id);
            if (ModelState.IsValid)
            {
                Console.WriteLine("try to insert");
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDisqueDur"] = new SelectList(_context.DisqueDurs, "Id", "Label", laptop.IdDisqueDur);
            ViewData["IdEcran"] = new SelectList(_context.Ecrans, "Id", "Label", laptop.IdEcran);
            ViewData["IdProcesseur"] = new SelectList(_context.Processeurs, "Id", "Label", laptop.IdProcesseur);
            ViewData["IdRam"] = new SelectList(_context.Rams, "Id", "Label", laptop.IdRam);
            ViewData["IdReference"] = new SelectList(_context.References, "Id", "Label", laptop.IdReference);
            return View(laptop);
        }

        // GET: Laptop/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewData["IdDisqueDur"] = new SelectList(_context.DisqueDurs, "Id", "Label", laptop.IdDisqueDur);
            ViewData["IdEcran"] = new SelectList(_context.Ecrans, "Id", "Label", laptop.IdEcran);
            ViewData["IdProcesseur"] = new SelectList(_context.Processeurs, "Id", "Label", laptop.IdProcesseur);
            ViewData["IdRam"] = new SelectList(_context.Rams, "Id", "Label", laptop.IdRam);
            ViewData["IdReference"] = new SelectList(_context.References, "Id", "Label", laptop.IdReference);
            return View(laptop);
        }

        // POST: Laptop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IdReference,IdProcesseur,IdRam,IdEcran,IdDisqueDur")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
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
            ViewData["IdDisqueDur"] = new SelectList(_context.DisqueDurs, "Id", "Label", laptop.IdDisqueDur);
            ViewData["IdEcran"] = new SelectList(_context.Ecrans, "Id", "Label", laptop.IdEcran);
            ViewData["IdProcesseur"] = new SelectList(_context.Processeurs, "Id", "Label", laptop.IdProcesseur);
            ViewData["IdRam"] = new SelectList(_context.Rams, "Id", "Label", laptop.IdRam);
            ViewData["IdReference"] = new SelectList(_context.References, "Id", "Label", laptop.IdReference);
            return View(laptop);
        }

        // GET: Laptop/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.IdDisqueDurNavigation)
                .Include(l => l.IdEcranNavigation)
                .Include(l => l.IdProcesseurNavigation)
                .Include(l => l.IdRamNavigation)
                .Include(l => l.IdReferenceNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptops.Remove(laptop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(string id)
        {
            return _context.Laptops.Any(e => e.Id == id);
        }
    }
}
