using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
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
                .Include(s => s.Productos)
                .Include(s => s.ServicioTareas)
                    .ThenInclude(st => st.Tarea);  // Incluir las tareas a través de ServicioTareas

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
                .Include(s => s.Productos)
                .Include(s => s.ServicioTareas)
                .ThenInclude(st => st.Tarea)
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

        private async Task UpdateHorometro(int montacargasId, int? newHorometro)
        {
            if (newHorometro.HasValue)
            {
                var montacargas = await _context.MontacargasModel.FindAsync(montacargasId);
                if (montacargas != null)
                {
                    montacargas.Horometro = newHorometro.Value;
                    _context.Update(montacargas);
                    await _context.SaveChangesAsync();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicioCoModel servicioCoModel, string TareasSeleccionadas, List<ProductoSCo> productos)
        {
            var montacargas = await _context.MontacargasModel.FindAsync(servicioCoModel.IdMontacargas);

            if (servicioCoModel.Horometro < montacargas.Horometro)
            {
                ModelState.AddModelError("Horometro", "El Horometro del Servicio Correctivo no puede ser menor que el actual.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await UpdateHorometro(servicioCoModel.IdMontacargas, servicioCoModel.Horometro);

                    // Guardar el servicio primero
                    _context.Add(servicioCoModel);
                    await _context.SaveChangesAsync();

                    // Separar las tareas seleccionadas
                    var tareasSeleccionadas = TareasSeleccionadas
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                    foreach (var tareaId in tareasSeleccionadas)
                    {
                        var servicioTarea = new ServicioTarea
                        {
                            ServicioCoModelId = servicioCoModel.IdServicioCo,
                            TareaId = tareaId
                        };
                        _context.Add(servicioTarea);
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Log or handle the error as needed
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(ex.Message);
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

            return View(servicioCoModel);
        }




        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioCoModel == null)
            {
                return NotFound();
            }

            var servicioCoModel = await _context.ServicioCoModel
                                    .Include(s => s.ServicioTareas)
                                        .ThenInclude(st => st.Tarea)
                                    .FirstOrDefaultAsync(m => m.IdServicioCo == id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }

            var productosCo = await _context.ProductoSCo.Where(p => p.ServicioCoModelIdServicioCo == id).ToListAsync();
            ViewData["ProductosCo"] = productosCo;

            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioCoModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioCoModel.IdMontacargas);
            //ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCoModel.TareaId);
            ViewData["ComponenteId"] = new SelectList(
                                       _context.Tarea
                                           .Select(t => t.ComponenteId)
                                           .Distinct()
                                           .Join(_context.ProcesosCorrectivoModel, tareaComponenteId => tareaComponenteId, procesoComponenteId => procesoComponenteId.ComponenteId, (tareaComponenteId, procesoComponenteId) => new { TareaComponenteId = tareaComponenteId, ProcesoComponenteNombre = procesoComponenteId.Nombre }),
                                       "TareaComponenteId",
                                       "ProcesoComponenteNombre"
                                   );
            return View(servicioCoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicioCoModel servicioCoModel, string tareasseleccionadas, List<ProductoSCo> productos)
        {
            if (id != servicioCoModel.IdServicioCo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    var productosAsociados = await _context.ProductoSCo
                        .Where(p => p.ServicioCoModelIdServicioCo == id)
                        .ToListAsync();

                    // Actualizar productos existentes y agregar nuevos productos
                    foreach (var producto in productos)
                    {
                        if (producto.idProductoSP != 0)
                        {
                            var existingProduct = await _context.ProductoSCo.FindAsync(producto.idProductoSP);
                            if (existingProduct != null)
                            {
                                _context.Entry(existingProduct).CurrentValues.SetValues(producto);
                            }
                        }
                        else
                        {
                            servicioCoModel.Productos.Add(producto);
                        }

                        // Aplicar cambios en el modelo ServicioPModel
                        _context.Entry(servicioCoModel).State = EntityState.Modified;
                    }

                    // Eliminar productos que ya no están presentes en la vista de edición
                    foreach (var productoExistente in productosAsociados)
                    {
                        if (!productos.Any(p => p.idProductoSP == productoExistente.idProductoSP))
                        {
                            _context.ProductoSCo.Remove(productoExistente);
                        }
                    }

                    // Actualizar las tareas seleccionadas del servicioCModel
                    if (!string.IsNullOrEmpty(tareasseleccionadas))
                    {
                        var tareaIds = tareasseleccionadas.Split(',').Select(int.Parse).ToList();
                        //servicioCoModel.TareasSeleccionadas = await _context.Tarea.Where(t => tareaIds.Contains(t.TareaId)).ToListAsync();
                    }
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
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioCoModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioCoModel.IdMontacargas);
            //ViewData["TareaId"] = new SelectList(_context.Tarea, "TareaId", "TareaId", servicioCoModel.TareaId);
            ViewData["ComponenteId"] = new SelectList(
                                       _context.Tarea
                                           .Select(t => t.ComponenteId)
                                           .Distinct()
                                           .Join(_context.ProcesosCorrectivoModel, tareaComponenteId => tareaComponenteId, procesoComponenteId => procesoComponenteId.ComponenteId, (tareaComponenteId, procesoComponenteId) => new { TareaComponenteId = tareaComponenteId, ProcesoComponenteNombre = procesoComponenteId.Nombre }),
                                       "TareaComponenteId",
                                       "ProcesoComponenteNombre"
                                   );
            return View(servicioCoModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioCoModel = await _context.ServicioCoModel.FindAsync(id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }

            // Busca todos los registros relacionados en la tabla "Tarea" y los elimina
            var tareasRelacionadas = _context.Tarea.Where(t => t.TareaId == id);
            _context.Tarea.RemoveRange(tareasRelacionadas);

            // Elimina el registro en "ServicioCoModel"
            _context.ServicioCoModel.Remove(servicioCoModel);

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
                .Include(s => s.Productos)
                .Include(s => s.ServicioTareas)
                .ThenInclude(st => st.Tarea)
                .FirstOrDefaultAsync(m => m.IdServicioCo == id);
            if (servicioCoModel == null)
            {
                return NotFound();
            }

            return View(servicioCoModel);
        }
    }
}
