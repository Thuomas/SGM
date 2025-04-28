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
    public class ControlEquipoController : Controller
    {
        private readonly StockContext _context;

        public ControlEquipoController(StockContext context)
        {
            _context = context;
        }

        // GET: ControlEquipo
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.ControlEquipo.Include(c => c.Modelo);
            return View(await stockContext.ToListAsync());
        }

        // GET: ControlEquipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlEquipo = await _context.ControlEquipo
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlEquipo == null)
            {
                return NotFound();
            }

            return View(controlEquipo);
        }

        // GET: ControlEquipo/Create
        public IActionResult Create()
        {
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Nombre");
            return View();
        }

        // POST: ControlEquipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Resonsable,ModeloId")] ControlEquipo controlEquipo)
        {
            ModelState.Remove("Modelo");
            if (ModelState.IsValid)
            {
                _context.Add(controlEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Nombre", controlEquipo.ModeloId);
            return View(controlEquipo);
        }

        // GET: ControlEquipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlEquipo = await _context.ControlEquipo.FindAsync(id);
            if (controlEquipo == null)
            {
                return NotFound();
            }
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Nombre", controlEquipo.ModeloId);
            return View(controlEquipo);
        }

        // POST: ControlEquipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Resonsable,ModeloId")] ControlEquipo controlEquipo)
        {
            if (id != controlEquipo.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Modelo");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlEquipoExists(controlEquipo.Id))
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
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Nombre", controlEquipo.ModeloId);
            return View(controlEquipo);
        }

        // GET: ControlEquipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlEquipo = await _context.ControlEquipo
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlEquipo == null)
            {
                return NotFound();
            }

            return View(controlEquipo);
        }

        // POST: ControlEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlEquipo = await _context.ControlEquipo.FindAsync(id);
            if (controlEquipo != null)
            {
                _context.ControlEquipo.Remove(controlEquipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlEquipoExists(int id)
        {
            return _context.ControlEquipo.Any(e => e.Id == id);
        }
    }
}
