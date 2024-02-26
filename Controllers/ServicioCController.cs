﻿using System;
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
    public class ServicioCController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ServicioCController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ServicioCModel
                .Include(s => s.TareasSeleccionadas)
                .Include(s => s.Salidas) // Incluye la tabla Salidas
                    .ThenInclude(salida => salida.Montacargas); // Incluye la relación con Montacargas

            return View(await servicioMontacargasContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioCModel == null)
            {
                return NotFound();
            }

            var servicioCModel = await _context.ServicioCModel
                .Include(s => s.TareasSeleccionadas)
                .Include(s => s.Salidas) 
                    .ThenInclude(salida => salida.Montacargas)
                .FirstOrDefaultAsync(m => m.idServicioC == id);
            if (servicioCModel == null)
            {
                return NotFound();
            }

            return View(servicioCModel);
        }

        [HttpGet]
        public IActionResult GetTareasByComponenteId(int componenteId)
        {
            var tareas = _context.Tarea
                                .Where(t => t.ComponenteId == componenteId)
                                .Select(t => new { value = t.TareaId, text = t.Descripcion })
                                .ToList();
            return Json(tareas);
        }


        public IActionResult Create()
        {
            
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "ComponenteId");
            //ViewData["ComponenteId"] = new SelectList(_context.Tarea.Select(t => t.ComponenteId).Distinct());
            ViewData["ComponenteId"] = new SelectList(
                                        _context.Tarea
                                            .Select(t => t.ComponenteId)
                                            .Distinct()
                                            .Join(_context.ProcesosCorrectivoModel, tareaComponenteId => tareaComponenteId, procesoComponenteId => procesoComponenteId.ComponenteId, (tareaComponenteId, procesoComponenteId) => new { TareaComponenteId = tareaComponenteId, ProcesoComponenteNombre = procesoComponenteId.Nombre }),
                                        "TareaComponenteId",
                                        "ProcesoComponenteNombre"
                                    );



            ViewData["IdSalidaA"] = new SelectList(_context.SalidaModel, "IdSalidaA", "FolioSalida");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicioCModel servicioCModel, string tareasseleccionadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioCModel);
                await _context.SaveChangesAsync();

                var tareasSeleccionadas = tareasseleccionadas
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                foreach (var tareaId in tareasSeleccionadas)
                {
                    var tarea = new Tarea { TareaId = tareaId };
                    _context.Attach(tarea);
                    servicioCModel.TareasSeleccionadas.Add(tarea);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["TareaId"] = new SelectList(_context.Tarea, "ComponenteId", "ComponenteId", servicioCModel.TareaId);
            ViewData["TareaId"] = new SelectList(_context.Tarea, "IdSalidaA", "FolioSalida", servicioCModel.TareaId);
            return View(servicioCModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioCModel == null)
            {
                return NotFound();
            }

            var servicioCModel = await _context.ServicioCModel.FindAsync(id);
            if (servicioCModel == null)
            {
                return NotFound();
            }
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCModel.TareaId);
            return View(servicioCModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idServicioC,TareaId,FechaR,FechaE,Refacciones,ServicioD,Status")] ServicioCModel servicioCModel)
        {
            if (id != servicioCModel.idServicioC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioCModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioCModelExists(servicioCModel.idServicioC))
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
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCModel.TareaId);
            return View(servicioCModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioCModel == null)
            {
                return NotFound();
            }

            var servicioCModel = await _context.ServicioCModel
                .Include(s => s.Tareas)
                .FirstOrDefaultAsync(m => m.idServicioC == id);
            if (servicioCModel == null)
            {
                return NotFound();
            }

            return View(servicioCModel);
        }

        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioCModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ServicioCModel'  is null.");
            }
            var servicioCModel = await _context.ServicioCModel.FindAsync(id);
            if (servicioCModel != null)
            {
                _context.ServicioCModel.Remove(servicioCModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioCModelExists(int id)
        {
          return (_context.ServicioCModel?.Any(e => e.idServicioC == id)).GetValueOrDefault();
        }
    }
}