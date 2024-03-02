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
    public class ReportPointDeVenteController : Controller
    {
        private readonly MikoloContext _context;

        public ReportPointDeVenteController(MikoloContext context)
        {
            _context = context;
        }

        // GET: ReportPointDeVente
        public async Task<IActionResult> Index()
        {
            var mikoloContext = _context.ReportPointDeVentes.Include(r => r.IdLaptopNavigation).Include(r => r.IdPointDeVenteNavigation);
            return View(await mikoloContext.ToListAsync());
        }

        // GET: ReportPointDeVente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportPointDeVente = await _context.ReportPointDeVentes
                .Include(r => r.IdLaptopNavigation)
                .Include(r => r.IdPointDeVenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportPointDeVente == null)
            {
                return NotFound();
            }

            return View(reportPointDeVente);
        }

        // GET: ReportPointDeVente/Create
        public IActionResult Create()
        {
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id");
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id");
            return View();
        }

        // POST: ReportPointDeVente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPointDeVente,IdLaptop,DateReport,Nombre")] ReportPointDeVente reportPointDeVente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportPointDeVente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", reportPointDeVente.IdLaptop);
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", reportPointDeVente.IdPointDeVente);
            return View(reportPointDeVente);
        }

        // GET: ReportPointDeVente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportPointDeVente = await _context.ReportPointDeVentes.FindAsync(id);
            if (reportPointDeVente == null)
            {
                return NotFound();
            }
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", reportPointDeVente.IdLaptop);
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", reportPointDeVente.IdPointDeVente);
            return View(reportPointDeVente);
        }

        // POST: ReportPointDeVente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPointDeVente,IdLaptop,DateReport,Nombre")] ReportPointDeVente reportPointDeVente)
        {
            if (id != reportPointDeVente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportPointDeVente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportPointDeVenteExists(reportPointDeVente.Id))
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
            ViewData["IdLaptop"] = new SelectList(_context.Laptops, "Id", "Id", reportPointDeVente.IdLaptop);
            ViewData["IdPointDeVente"] = new SelectList(_context.PointDeVentes, "Id", "Id", reportPointDeVente.IdPointDeVente);
            return View(reportPointDeVente);
        }

        // GET: ReportPointDeVente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportPointDeVente = await _context.ReportPointDeVentes
                .Include(r => r.IdLaptopNavigation)
                .Include(r => r.IdPointDeVenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportPointDeVente == null)
            {
                return NotFound();
            }

            return View(reportPointDeVente);
        }

        // POST: ReportPointDeVente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportPointDeVente = await _context.ReportPointDeVentes.FindAsync(id);
            if (reportPointDeVente != null)
            {
                _context.ReportPointDeVentes.Remove(reportPointDeVente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportPointDeVenteExists(int id)
        {
            return _context.ReportPointDeVentes.Any(e => e.Id == id);
        }
    }
}
