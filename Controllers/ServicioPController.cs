using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Commons.Actions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Auths;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;
using static ServicioMontacargas.Models.ServicioPModel;

namespace ServicioMontacargas.Controllers
{
    [AutorizacionTecnicoMntcAd]
    public class ServicioPController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ServicioPController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ServicioPModel.Include(s => s.Clientes).Include(s => s.Montacargas).Include(s => s.Productos);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioPModel == null)
            {
                return NotFound();
            }

            var servicioPModel = await _context.ServicioPModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .Include(s => s.Productos)
                .FirstOrDefaultAsync(m => m.IdServicioP == id);
            if (servicioPModel == null)
            {
                return NotFound();
            }

            return View(servicioPModel);
        }

        public IActionResult Create()
        {
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre");
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicioPModel servicioPModel, List<Producto> productos)
        {
            var montacargas = await _context.MontacargasModel.FindAsync(servicioPModel.IdMontacargas);

            if (servicioPModel.Horometro < montacargas.HorometroMtto)
            {
                ModelState.AddModelError("Horometro", "El Horometro del Servicio Preventivo no puede ser menor que el horometro del mantenimiento anterior del montacargas.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar el horómetro del montacargas
                    await UpdateHorometro(servicioPModel.IdMontacargas, servicioPModel.Horometro);

                    _context.Add(servicioPModel);
                    await _context.SaveChangesAsync();                    
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioPModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioPModel.IdMontacargas);
            return View(servicioPModel);
        }

        private async Task UpdateHorometro(int montacargasId, int? newHorometro)
        {
            if (newHorometro.HasValue)
            {
                var montacargas = await _context.MontacargasModel.FindAsync(montacargasId);
                string horasMtto = (newHorometro.Value - montacargas.Horometro + 500).ToString();

                if (montacargas != null)
                {
                    montacargas.HorometroMtto = newHorometro.Value;
                    montacargas.HorasMtto = horasMtto;
                    _context.Update(montacargas);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioPModel == null)
            {
                return NotFound();
            }

            var servicioPModel = await _context.ServicioPModel.FindAsync(id);
            if (servicioPModel == null)
            {
                return NotFound();
            }

            var productos = await _context.Producto.Where(p => p.ServicioPModelIdServicioP == id).ToListAsync();
            ViewData["Productos"] = productos;

            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioPModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioPModel.IdMontacargas);
            return View(servicioPModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicioPModel servicioPModel, List<Producto> productos)
        {
            if (id != servicioPModel.IdServicioP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener todos los productos asociados al servicio
                    var productosAsociados = await _context.Producto
                        .Where(p => p.ServicioPModelIdServicioP == id)
                        .ToListAsync();

                    // Actualizar productos existentes y agregar nuevos productos
                    foreach (var producto in productos)
                    {
                        if (producto.idProductoSP != 0)
                        {
                            var existingProduct = await _context.Producto.FindAsync(producto.idProductoSP);
                            if (existingProduct != null)
                            {
                                _context.Entry(existingProduct).CurrentValues.SetValues(producto);
                            }
                        }
                        else
                        {
                            servicioPModel.Productos.Add(producto);
                        }

                        // Aplicar cambios en el modelo ServicioPModel
                        _context.Entry(servicioPModel).State = EntityState.Modified;
                    }

                    // Eliminar productos que ya no están presentes en la vista de edición
                    foreach (var productoExistente in productosAsociados)
                    {
                        if (!productos.Any(p => p.idProductoSP == productoExistente.idProductoSP))
                        {
                            _context.Producto.Remove(productoExistente);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioPModelExists(servicioPModel.IdServicioP))
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
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioPModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioPModel.IdMontacargas);
            return View(servicioPModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioPModel == null)
            {
                return NotFound();
            }

            var servicioPModel = await _context.ServicioPModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .FirstOrDefaultAsync(m => m.IdServicioP == id);
            if (servicioPModel == null)
            {
                return NotFound();
            }

            return View(servicioPModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioPModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ServicioPModel'  is null.");
            }
            var servicioPModel = await _context.ServicioPModel.FindAsync(id);
            if (servicioPModel != null)
            {
                _context.ServicioPModel.Remove(servicioPModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioPModelExists(int id)
        {
          return (_context.ServicioPModel?.Any(e => e.IdServicioP == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> ServicioPPDF(int? id)
        {
            if (id == null || _context.ServicioPModel == null)
            {
                return NotFound();
            }

            var servicioPModel = await _context.ServicioPModel
                .Include(s => s.Clientes)
                .Include(s => s.Montacargas)
                .Include(s => s.Productos)
                .FirstOrDefaultAsync(m => m.IdServicioP == id);
            if (servicioPModel == null)
            {
                return NotFound();
            }

            return View(servicioPModel);
        }
    }
}
