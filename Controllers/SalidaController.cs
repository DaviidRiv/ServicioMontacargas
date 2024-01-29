using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;

namespace ServicioMontacargas.Controllers
{
    public class SalidaController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public SalidaController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        // GET: Salida
        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.SalidaModel.Include(s => s.Montacargas);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        // GET: Salida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalidaModel == null)
            {
                return NotFound();
            }

            var salidaModel = await _context.SalidaModel
                .Include(s => s.Montacargas)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }

        public IActionResult Create()
        {
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "IdMontacargas");
            ViewData["Salida"] = new SelectList(_context.MontacargasModel, "IdAlmacen", "IdAlmacen");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSalidaA,Cliente,Fecha,IdMontacargas,Cantidad,FirmaRecibio,FirmaEntrego")] SalidaModel salidaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salidaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "IdMontacargas", salidaModel.IdMontacargas);
            return View(salidaModel);
        }

        // GET: Salida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalidaModel == null)
            {
                return NotFound();
            }

            var salidaModel = await _context.SalidaModel.FindAsync(id);
            if (salidaModel == null)
            {
                return NotFound();
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "IdMontacargas", salidaModel.IdMontacargas);
            return View(salidaModel);
        }

        // POST: Salida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSalidaA,Cliente,Fecha,IdMontacargas,Cantidad,FirmaRecibio,FirmaEntrego")] SalidaModel salidaModel)
        {
            if (id != salidaModel.IdSalidaA)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salidaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalidaModelExists(salidaModel.IdSalidaA))
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
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "IdMontacargas", salidaModel.IdMontacargas);
            return View(salidaModel);
        }

        // GET: Salida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalidaModel == null)
            {
                return NotFound();
            }

            var salidaModel = await _context.SalidaModel
                .Include(s => s.Montacargas)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }

        // POST: Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalidaModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.SalidaModel'  is null.");
            }
            var salidaModel = await _context.SalidaModel.FindAsync(id);
            if (salidaModel != null)
            {
                _context.SalidaModel.Remove(salidaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalidaModelExists(int id)
        {
          return (_context.SalidaModel?.Any(e => e.IdSalidaA == id)).GetValueOrDefault();
        }
    }
}
