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
            if (ModelState.IsValid)
            {
                try
                {
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

                    // Iterar sobre los productos existentes
                    foreach (var productoExistente in productosAsociados)
                    {
                        // Verificar si el producto existente está en la lista recibida
                        var productoEnSolicitud = productos.FirstOrDefault(np => np.idProductoSP == productoExistente.idProductoSP);

                        // Si el producto existente no está en la lista recibida, eliminarlo
                        if (productoEnSolicitud == null)
                        {
                            _context.Producto.Remove(productoExistente);
                        }
                    }

                    // Actualizar o agregar nuevos productos
                    foreach (var nuevoProducto in productos)
                    {
                        if (nuevoProducto.idProductoSP != 0)
                        {
                            _context.Update(nuevoProducto);
                        }
                        else
                        {
                            servicioPModel.Productos.Add(nuevoProducto);
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
