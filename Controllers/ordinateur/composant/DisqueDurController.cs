using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mikolo
{
    public class DisqueDurController : Controller
    {
        private readonly MikoloContext _context;

        public DisqueDurController(MikoloContext context)
        {
            _context = context;
        }

        // GET: DisqueDur
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisqueDurs.ToListAsync());
        }

        // GET: DisqueDur/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disqueDur = await _context.DisqueDurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disqueDur == null)
            {
                return NotFound();
            }

            return View(disqueDur);
        }

        // GET: DisqueDur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisqueDur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Stockage,Rotation,Taille")] DisqueDur disqueDur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disqueDur);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(disqueDur);
        }

        // GET: DisqueDur/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disqueDur = await _context.DisqueDurs.FindAsync(id);
            if (disqueDur == null)
            {
                return NotFound();
            }
            return View(disqueDur);
        }

        // POST: DisqueDur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Label,Stockage,Rotation,Taille")] DisqueDur disqueDur)
        {
            if (id != disqueDur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disqueDur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisqueDurExists(disqueDur.Id))
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
            return View(disqueDur);
        }

        // GET: DisqueDur/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disqueDur = await _context.DisqueDurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disqueDur == null)
            {
                return NotFound();
            }

            return View(disqueDur);
        }

        // POST: DisqueDur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var disqueDur = await _context.DisqueDurs.FindAsync(id);
            if (disqueDur != null)
            {
                _context.DisqueDurs.Remove(disqueDur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisqueDurExists(string id)
        {
            return _context.DisqueDurs.Any(e => e.Id == id);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}
