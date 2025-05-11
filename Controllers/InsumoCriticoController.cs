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
    public class InsumoCriticoController : Controller
    {
        private readonly StockContext _context;

        public InsumoCriticoController(StockContext context)
        {
            _context = context;
        }

        // GET: InsumoCritico
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsumoCritico.ToListAsync());
        }

        // GET: InsumoCritico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoCritico = await _context.InsumoCritico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insumoCritico == null)
            {
                return NotFound();
            }

            return View(insumoCritico);
        }

        // GET: InsumoCritico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsumoCritico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] InsumoCritico insumoCritico)
        {
            ModelState.Remove("Fecha");
            if (ModelState.IsValid)
            {
                insumoCritico.Fecha = DateOnly.FromDateTime(DateTime.Now) ;
                _context.Add(insumoCritico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insumoCritico);
        }

        // GET: InsumoCritico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoCritico = await _context.InsumoCritico.FindAsync(id);
            if (insumoCritico == null)
            {
                return NotFound();
            }
            return View(insumoCritico);
        }

        // POST: InsumoCritico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Fecha")] InsumoCritico insumoCritico)
        {
            if (id != insumoCritico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insumoCritico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsumoCriticoExists(insumoCritico.Id))
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
            return View(insumoCritico);
        }

        // GET: InsumoCritico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoCritico = await _context.InsumoCritico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insumoCritico == null)
            {
                return NotFound();
            }

            return View(insumoCritico);
        }

        // POST: InsumoCritico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumoCritico = await _context.InsumoCritico.FindAsync(id);
            if (insumoCritico != null)
            {
                _context.InsumoCritico.Remove(insumoCritico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumoCriticoExists(int id)
        {
            return _context.InsumoCritico.Any(e => e.Id == id);
        }
    }
}
