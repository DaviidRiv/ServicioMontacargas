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
    public class ServicioCoController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ServicioCoController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ServicioCoModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .Include(s => s.Tareas)
                .Include(s => s.TareasSeleccionadas)
                .Include(s => s.Productos);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioCoModel == null)
            {
                return NotFound();
            }

            var servicioCoModel = await _context.ServicioCoModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .Include(s => s.Tareas)
                .Include(s => s.TareasSeleccionadas)
                .Include(s => s.Productos)
                .FirstOrDefaultAsync(m => m.IdServicioCo == id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }

            return View(servicioCoModel);
        }

        public IActionResult Create()
        {
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre");
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg");
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId");
            ViewData["ComponenteId"] = new SelectList(
                                        _context.Tarea
                                            .Select(t => t.ComponenteId)
                                            .Distinct()
                                            .Join(_context.ProcesosCorrectivoModel, tareaComponenteId => tareaComponenteId, procesoComponenteId => procesoComponenteId.ComponenteId, (tareaComponenteId, procesoComponenteId) => new { TareaComponenteId = tareaComponenteId, ProcesoComponenteNombre = procesoComponenteId.Nombre }),
                                        "TareaComponenteId",
                                        "ProcesoComponenteNombre"
                                    );

            return View();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicioCoModel servicioCoModel, string tareasseleccionadas, List<ProductoSCo> productos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(servicioCoModel);
                    await _context.SaveChangesAsync();

                    var tareasSeleccionadas = tareasseleccionadas
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                    foreach (var tareaId in tareasSeleccionadas)
                    {
                        var tarea = new Tarea { TareaId = tareaId };
                        _context.Attach(tarea);
                        servicioCoModel.TareasSeleccionadas.Add(tarea);
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioCoModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioCoModel.IdMontacargas);
            ViewData["ComponenteId"] = new SelectList(
                                       _context.Tarea
                                           .Select(t => t.ComponenteId)
                                           .Distinct()
                                           .Join(_context.ProcesosCorrectivoModel, tareaComponenteId => tareaComponenteId, procesoComponenteId => procesoComponenteId.ComponenteId, (tareaComponenteId, procesoComponenteId) => new { TareaComponenteId = tareaComponenteId, ProcesoComponenteNombre = procesoComponenteId.Nombre }),
                                       "TareaComponenteId",
                                       "ProcesoComponenteNombre"
                                   );
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCoModel.TareaId);
            return View(servicioCoModel);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioCoModel == null)
            {
                return NotFound();
            }

            var servicioCoModel = await _context.ServicioCoModel.FindAsync(id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "IdClientes", servicioCoModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "IdMontacargas", servicioCoModel.IdMontacargas);
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCoModel.TareaId);
            return View(servicioCoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicioCo,IdClientes,TareaId,CausaFalla,IdMontacargas,FechaReg,FechaR,FechaE,Refacciones,ServicioD,FirmaJ,FirmaC,NombreJ,NombreC,Status")] ServicioCoModel servicioCoModel)
        {
            if (id != servicioCoModel.IdServicioCo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioCoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioCoModelExists(servicioCoModel.IdServicioCo))
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
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "IdClientes", servicioCoModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "IdMontacargas", servicioCoModel.IdMontacargas);
            ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCoModel.TareaId);
            return View(servicioCoModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioCoModel == null)
            {
                return NotFound();
            }

            var servicioCoModel = await _context.ServicioCoModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .Include(s => s.Tareas)
                .FirstOrDefaultAsync(m => m.IdServicioCo == id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }

            return View(servicioCoModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioCoModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ServicioCoModel'  is null.");
            }
            var servicioCoModel = await _context.ServicioCoModel.FindAsync(id);
            if (servicioCoModel != null)
            {
                _context.ServicioCoModel.Remove(servicioCoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioCoModelExists(int id)
        {
            return (_context.ServicioCoModel?.Any(e => e.IdServicioCo == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> ServicioCPDF(int? id)
        {
            if (id == null || _context.ServicioCoModel == null)
            {
                return NotFound();
            }

            var servicioCoModel = await _context.ServicioCoModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .Include(s => s.Tareas)
                .Include(s => s.TareasSeleccionadas)
                .Include(s => s.Productos)
                .FirstOrDefaultAsync(m => m.IdServicioCo == id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }

            return View(servicioCoModel);
        }
    }
}
