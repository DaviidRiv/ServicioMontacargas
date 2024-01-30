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


        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.SalidaModel.Include(s => s.Montacargas).Include(a => a.Almacen);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalidaModel == null)
            {
                return NotFound();
            }

            var salidaModel = await _context.SalidaModel
                .Include(s => s.Montacargas)
                .Include(a => a.Almacen)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }

        public IActionResult Create()
        {
            var almacenList = _context.AlmacenModel
               .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
               .ToList();

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico");
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen");
            return View();
        }

        [HttpGet]
        public IActionResult GetAlmacenData(string term)
        {
            var results = _context.AlmacenModel
                .Where(m => m.Producto.Contains(term) || m.Nombre.Contains(term))
                .Select(m => new { id = m.IdAlmacen, text = $"{m.Producto} - {m.Nombre}" })
                .ToList();

            return Json(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSalidaA,Cliente,Fecha,IdMontacargas,IdAlmacen,Cantidad,FirmaRecibio,FirmaEntrego")] SalidaModel salidaModel)
        {
            var almacenList = _context.AlmacenModel
               .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
               .ToList();
            if (ModelState.IsValid)
            {
                _context.Add(salidaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", salidaModel.IdMontacargas);
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen", salidaModel.IdAlmacen);
            return View(salidaModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var almacenList = _context.AlmacenModel
               .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
               .ToList();
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
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen", salidaModel.IdAlmacen);
            return View(salidaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSalidaA,Cliente,Fecha,IdMontacargas,IdAlmacen,Cantidad,FirmaRecibio,FirmaEntrego")] SalidaModel salidaModel)
        {
            var almacenList = _context.AlmacenModel
               .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
               .ToList();

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
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen", salidaModel.IdAlmacen);

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
                .Include(a => a.Almacen)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }

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
