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
    public class ProcesosCorrectivoController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ProcesosCorrectivoController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        // GET: ProcesosCorrectivo
        public async Task<IActionResult> Index()
        {
              return _context.ProcesosCorrectivoModel != null ? 
                          View(await _context.ProcesosCorrectivoModel.ToListAsync()) :
                          Problem("Entity set 'ServicioMontacargasContext.ProcesosCorrectivoModel'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcesosCorrectivoModel == null)
            {
                return NotFound();
            }

            var procesosCorrectivoModel = await _context.ProcesosCorrectivoModel
                .FirstOrDefaultAsync(m => m.ComponenteId == id);
            if (procesosCorrectivoModel == null)
            {
                return NotFound();
            }

            return View(procesosCorrectivoModel);
        }

        public IActionResult Create()
        {
            var procesosCorrectivoModel = new ProcesosCorrectivoModel();
            // Inicializar una lista vacía de tareas
            procesosCorrectivoModel.Tareas = new List<Tarea>();
            return View(procesosCorrectivoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComponenteId,Nombre")] ProcesosCorrectivoModel procesosCorrectivoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesosCorrectivoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesosCorrectivoModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcesosCorrectivoModel == null)
            {
                return NotFound();
            }

            var procesosCorrectivoModel = await _context.ProcesosCorrectivoModel.FindAsync(id);
            if (procesosCorrectivoModel == null)
            {
                return NotFound();
            }
            return View(procesosCorrectivoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComponenteId,Nombre")] ProcesosCorrectivoModel procesosCorrectivoModel)
        {
            if (id != procesosCorrectivoModel.ComponenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesosCorrectivoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesosCorrectivoModelExists(procesosCorrectivoModel.ComponenteId))
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
            return View(procesosCorrectivoModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcesosCorrectivoModel == null)
            {
                return NotFound();
            }

            var procesosCorrectivoModel = await _context.ProcesosCorrectivoModel
                .FirstOrDefaultAsync(m => m.ComponenteId == id);
            if (procesosCorrectivoModel == null)
            {
                return NotFound();
            }

            return View(procesosCorrectivoModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcesosCorrectivoModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ProcesosCorrectivoModel'  is null.");
            }
            var procesosCorrectivoModel = await _context.ProcesosCorrectivoModel.FindAsync(id);
            if (procesosCorrectivoModel != null)
            {
                _context.ProcesosCorrectivoModel.Remove(procesosCorrectivoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesosCorrectivoModelExists(int id)
        {
          return (_context.ProcesosCorrectivoModel?.Any(e => e.ComponenteId == id)).GetValueOrDefault();
        }
    }
}
