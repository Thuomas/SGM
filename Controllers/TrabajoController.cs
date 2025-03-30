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
    public class TrabajoController : Controller
    {
        private readonly StockContext _context;

        public TrabajoController(StockContext context)
        {
            _context = context;
        }

        // GET: Trabajo
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.Trabajo.Include(t => t.Modelo);
            return View(await stockContext.ToListAsync());
        }

        // GET: Trabajo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajo = await _context.Trabajo
                .Include(t => t.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajo == null)
            {
                return NotFound();
            }

            return View(trabajo);
        }

        // GET: Trabajo/Create
        public IActionResult Create()
        {
            ViewBag.ModeloId = new SelectList(_context.Modelo, "Id","Nombre");
            return View();
        }

        // POST: Trabajo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,OrdenTrabajo,ModeloId,Cantidad")] Trabajo trabajo)
        {
            ModelState.Remove("Modelo");
            if (ModelState.IsValid)
            {
                _context.Add(trabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModeloId = new SelectList(_context.Modelo, "Id", "Nombre", trabajo.ModeloId);
            return View(trabajo);
        }

        // GET: Trabajo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajo = await _context.Trabajo.FindAsync(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            //ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Id", trabajo.ModeloId);
            ViewBag.ModeloId = new SelectList(_context.Modelo, "Id","Nombre");
            return View(trabajo);
        }

        // POST: Trabajo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,OrdenTrabajo,ModeloId,Cantidad")] Trabajo trabajo)
        {
            if (id != trabajo.Id)
            {
                return NotFound();
            }
                
            ModelState.Remove("Modelo");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajoExists(trabajo.Id))
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
            //ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Id", trabajo.ModeloId);
            ViewBag.ModeloId = new SelectList(_context.Modelo, "Id","Nombre");
            return View(trabajo);
        }

        // GET: Trabajo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajo = await _context.Trabajo
                .Include(t => t.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajo == null)
            {
                return NotFound();
            }

            return View(trabajo);
        }

        // POST: Trabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajo = await _context.Trabajo.FindAsync(id);
            if (trabajo != null)
            {
                _context.Trabajo.Remove(trabajo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajoExists(int id)
        {
            return _context.Trabajo.Any(e => e.Id == id);
        }
    }
}
