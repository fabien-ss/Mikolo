using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mikolo
{
    public class RamController : Controller
    {
        private readonly MikoloContext _context;

        public RamController(MikoloContext context)
        {
            _context = context;
        }

        // GET: Ram
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rams.ToListAsync());
        }

        // GET: Ram/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        // GET: Ram/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Puissance")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ram);
        }

        // GET: Ram/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams.FindAsync(id);
            if (ram == null)
            {
                return NotFound();
            }
            return View(ram);
        }

        // POST: Ram/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Label,Puissance")] Ram ram)
        {
            if (id != ram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamExists(ram.Id))
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
            return View(ram);
        }

        // GET: Ram/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        // POST: Ram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ram = await _context.Rams.FindAsync(id);
            if (ram != null)
            {
                _context.Rams.Remove(ram);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamExists(string id)
        {
            return _context.Rams.Any(e => e.Id == id);
        }
    }
}
