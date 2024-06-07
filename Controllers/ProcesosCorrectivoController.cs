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

        public async Task<IActionResult> Index()
        {
            var procesosConTareas = await _context.ProcesosCorrectivoModel
                                                .Include(p => p.Tareas) // Cargar las tareas asociadas a cada proceso
                                                .ToListAsync();

            return View(procesosConTareas);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcesosCorrectivoModel == null)
            {
                return NotFound();
            }

            var procesosCorrectivoModel = await _context.ProcesosCorrectivoModel
                .Include(t => t.Tareas)
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
        public async Task<IActionResult> Create([Bind("ComponenteId,Nombre,Tareas")] ProcesosCorrectivoModel procesosCorrectivoModel)
        {
            if (ModelState.IsValid)
            {
                // Agregar las tareas al modelo ProcesosCorrectivoModel
                foreach (var tarea in procesosCorrectivoModel.Tareas)
                {
                    tarea.ComponenteId = procesosCorrectivoModel.ComponenteId;
                    _context.Add(tarea);
                }

                // Agregar el modelo ProcesosCorrectivoModel y guardar los cambios
                _context.Add(procesosCorrectivoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesosCorrectivoModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesosCorrectivoModel = await _context.ProcesosCorrectivoModel
                .Include(p => p.Tareas) // Cargar las tareas asociadas al componente
                .FirstOrDefaultAsync(p => p.ComponenteId == id);

            if (procesosCorrectivoModel == null)
            {
                return NotFound();
            }

            return View(procesosCorrectivoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcesosCorrectivoModel procesosCorrectivoModel)
        {
            if (id != procesosCorrectivoModel.ComponenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProceso = await _context.ProcesosCorrectivoModel
                        .Include(pc => pc.Tareas)
                        .FirstOrDefaultAsync(pc => pc.ComponenteId == id);

                    if (existingProceso == null)
                    {
                        return NotFound();
                    }

                    existingProceso.Nombre = procesosCorrectivoModel.Nombre;

                    // Recargar las tareas desde la base de datos
                    foreach (var tarea in existingProceso.Tareas)
                    {
                        _context.Entry(tarea).State = EntityState.Detached; // Desvincular la tarea existente
                    }

                    // Actualizar tareas existentes y agregar nuevas tareas
                    foreach (var tarea in procesosCorrectivoModel.Tareas)
                    {
                        var existingTarea = existingProceso.Tareas.FirstOrDefault(t => t.TareaId == tarea.TareaId);
                        if (existingTarea != null)
                        {
                            existingTarea.Descripcion = tarea.Descripcion;
                        }
                        else
                        {
                            existingProceso.Tareas.Add(tarea);
                        }
                    }

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
