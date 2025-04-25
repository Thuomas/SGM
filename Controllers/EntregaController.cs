using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGM.Data;
using SGM.Models;

namespace SGM.Controllers
{
    public class EntregaController : Controller
    {
        private readonly StockContext _context;

        public EntregaController(StockContext context)
        {
            _context = context;
        }

        // GET: Entrega
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.Entrega.Include(e => e.OrdenTrabajo);
            return View(await stockContext.ToListAsync());
        }

        // GET: Entrega/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entrega
                .Include(e => e.OrdenTrabajo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

        // GET: Entrega/Create
        public IActionResult Create()
        {
            ViewData["TrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajo");
            return View();
        }

        // POST: Entrega/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Remito,TrabajoId,Cantidad,CantidadRestante")] Entrega entrega)
        {
            ModelState.Remove("OrdenTrabajo");
            if (ModelState.IsValid)
            {
                _context.Add(entrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajo", entrega.TrabajoId);
            return View(entrega);
        }

        // GET: Entrega/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entrega.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }
            ViewData["TrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajo", entrega.TrabajoId);
            return View(entrega);
        }

        // POST: Entrega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Remito,TrabajoId,Cantidad,CantidadRestante")] Entrega entrega)
        {
            if (id != entrega.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaExists(entrega.Id))
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
            ViewData["TrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajo", entrega.TrabajoId);
            return View(entrega);
        }

        // GET: Entrega/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entrega
                .Include(e => e.OrdenTrabajo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

        // POST: Entrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrega = await _context.Entrega.FindAsync(id);
            if (entrega != null)
            {
                _context.Entrega.Remove(entrega);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaExists(int id)
        {
            return _context.Entrega.Any(e => e.Id == id);
        }
    }
}
