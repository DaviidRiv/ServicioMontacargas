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
    public class AlmacenController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public AlmacenController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.AlmacenModel != null ?
                        View(await _context.AlmacenModel.ToListAsync()) :
                        Problem("Entity set 'ServicioMontacargasContext.AlmacenModel'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlmacenModel == null)
            {
                return NotFound();
            }

            var almacenModel = await _context.AlmacenModel
                .FirstOrDefaultAsync(m => m.IdAlmacen == id);
            if (almacenModel == null)
            {
                return NotFound();
            }

            return View(almacenModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlmacen,Producto,Nombre,Medida")] AlmacenModel almacenModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(almacenModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index",almacenModel);
        }

        // GET: Almacen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlmacenModel == null)
            {
                return NotFound();
            }

            var almacenModel = await _context.AlmacenModel.FindAsync(id);
            if (almacenModel == null)
            {
                return NotFound();
            }
            return View(almacenModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlmacen,Producto,Nombre,Medida")] AlmacenModel almacenModel)
        {
            if (id != almacenModel.IdAlmacen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacenModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenModelExists(almacenModel.IdAlmacen))
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
            return View(almacenModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlmacenModel == null)
            {
                return NotFound();
            }

            var almacenModel = await _context.AlmacenModel
                .FirstOrDefaultAsync(m => m.IdAlmacen == id);
            if (almacenModel == null)
            {
                return NotFound();
            }

            return View(almacenModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlmacenModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.AlmacenModel'  is null.");
            }
            var almacenModel = await _context.AlmacenModel.FindAsync(id);
            if (almacenModel != null)
            {
                _context.AlmacenModel.Remove(almacenModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenModelExists(int id)
        {
            return (_context.AlmacenModel?.Any(e => e.IdAlmacen == id)).GetValueOrDefault();
        }
    }
}
