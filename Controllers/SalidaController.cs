using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            var servicioMontacargasContext = _context.SalidaModel
                .Include(s => s.Montacargas)
                .Include(s => s.Clientes)
                .Include(s => s.Almacen)
                .Include(s => s.SalidaItems)
                    .ThenInclude(si => si.Almacen) // Incluir datos relacionados para SalidaItems y Almacen
                .ToList();

            return View(servicioMontacargasContext);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalidaModel == null)
            {
                return NotFound();
            }

            var salidaModel = await _context.SalidaModel
                .Include(s => s.Montacargas)
                .Include(s => s.Clientes)
                .Include(a => a.Almacen)
                .Include(s => s.SalidaItems)
                    .ThenInclude(si => si.Almacen)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }

        public IActionResult Create()
        {
            // Obtener el ID del cliente JACSA si está presente en la base de datos
            var clienteJacsa = _context.ClientesModel.FirstOrDefault(c => c.Nombre == "JACSA");

            // Establecer el valor predeterminado en el ID del cliente JACSA si se encontró
            var defaultClienteId = clienteJacsa != null ? clienteJacsa.IdClientes : 0;

            var almacenList = _context.AlmacenModel
               .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
               .ToList();

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg");
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen");
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", defaultClienteId);
            ViewBag.Admins = GetAdmins();
            ViewBag.Operadores = GetOperadores();

            return View();
        }

        [HttpGet]
        public List<string> GetAdmins()
        {
            // Obtener los nombres de los usuarios administradores
            var adminNames = _context.UsuariosModel
                .Where(m => m.rolUser == "Administrador")
                .Select(u => $"{u.Nombre} {u.ApellidoP} {u.ApellidoM}")
                .ToList();

            return adminNames;
        }

        [HttpGet]
        public List<string> GetOperadores()
        {
            // Obtener los nombres de los usuarios administradores
            var adminNames = _context.UsuariosModel
                .Where(m => m.rolUser == "Técnico" || m.rolUser == "Operador Grua" || m.rolUser == "Publico")
                .Select(u => $"{u.Nombre} {u.ApellidoP} {u.ApellidoM}")
                .ToList();

            return adminNames;
        }

        [HttpGet]
        public IActionResult GetAlmacenData(string term)
        {
            var results = _context.AlmacenModel
                .Where(m => m.Producto.Contains(term) || m.Nombre.Contains(term))
                .Select(m => new { id = m.IdAlmacen, text = $"{m.IdAlmacen} - {m.Producto} - {m.Nombre} - {m.Medida}" })
                .ToList();

            return Json(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSalidaA,IdClientes,Fecha,IdMontacargas,IdAlmacen,FirmaRecibio,FirmaEntrego,NombreRecibio,NombreEntrego")] SalidaModel salidaModel, string selectedProducts, string? otroOperador)
        {

            try
            {
                var almacenList = _context.AlmacenModel
                   .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
                   .ToList();

                if (!string.IsNullOrEmpty(selectedProducts))
                {
                    List<SelectedProductModel> selectedProductsList = JsonConvert.DeserializeObject<List<SelectedProductModel>>(selectedProducts);
                    salidaModel.SalidaItems = selectedProductsList.Select(p => new SalidaItem
                    {
                        IdAlmacen = p.idAlmacen,
                        Cantidad = p.Quantity
                    }).ToList();
                }

                if (salidaModel.NombreRecibio == "otro")
                {
                    salidaModel.NombreRecibio = otroOperador;
                }

                if (ModelState.IsValid)
                {
                    _context.Add(salidaModel);
                    await _context.SaveChangesAsync();

                    // Obtener el IdSalidaA recién creado
                    var idSalidaA = salidaModel.IdSalidaA;

                    // Asignar el IdSalidaA a cada SalidaItem y agregarlos al contexto
                    foreach (var salidaItem in salidaModel.SalidaItems)
                    {
                        salidaItem.IdSalidaA = idSalidaA;
                        _context.SalidaItem.Add(salidaItem);
                    }

                    await _context.SaveChangesAsync();

                    // Redirigir a la vista Index como si todo hubiera sido exitoso
                    return RedirectToAction(nameof(Index));
                }

                // Resto del código para manejar ModelState.IsValid == false
                ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", salidaModel.IdMontacargas);
                ViewData["IdAlmacen"] = new SelectList(_context.AlmacenModel, "IdAlmacen", "Producto", salidaModel.IdAlmacen);
                ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre");
                ViewBag.Admins = GetAdmins();
                ViewBag.Operadores = GetOperadores();

                return View(salidaModel);
            }
            catch (DbUpdateException ex)
            {
                // Capturar la excepción específica
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 544)
                {
                    // Continuar con la redirección si es el error relacionado con IDENTITY_INSERT
                    return RedirectToAction(nameof(Index));
                }

                // Re-lanzar la excepción si no es la esperada
                throw;
            }
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

            var salidaModel = await _context.SalidaModel
                .Include(s => s.Montacargas)
                .Include(a => a.Almacen)
                .Include(s => s.Clientes)
                .Include(s => s.SalidaItems)
                    .ThenInclude(si => si.Almacen)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", salidaModel.IdMontacargas);
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen", salidaModel.IdAlmacen);
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre");
            ViewBag.Admins = GetAdmins();
            ViewBag.Operadores = GetOperadores();

            return View(salidaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSalidaA,IdClientes,Fecha,IdMontacargas,IdAlmacen,FirmaRecibio,FirmaEntrego,NombreRecibio,NombreEntrego")] SalidaModel salidaModel, string selectedProducts, string? otroOperador)
        {
            var almacenList = _context.AlmacenModel
               .Select(m => new { m.IdAlmacen, DisplayInfoAlmacen = $"{m.Producto} - {m.Nombre}" })
               .ToList();

            if (id != salidaModel.IdSalidaA)
            {
                return NotFound();
            }

            // Obtener el SalidaModel de la base de datos incluyendo los SalidaItems relacionados
            var existingSalidaModel = await _context.SalidaModel
                .Include(s => s.SalidaItems)
                .FirstOrDefaultAsync(s => s.IdSalidaA == id);

            if (existingSalidaModel == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(selectedProducts))
            {
                List<SelectedProductModel> selectedProductsList = JsonConvert.DeserializeObject<List<SelectedProductModel>>(selectedProducts);

                // Verificar si los IdAlmacen existen en la base de datos
                var existingAlmacenIds = _context.AlmacenModel.Select(a => a.IdAlmacen).ToList();
                var invalidAlmacenIds = selectedProductsList.Where(p => !existingAlmacenIds.Contains(p.idAlmacen)).Select(p => p.idAlmacen).ToList();

                if (invalidAlmacenIds.Any())
                {
                    // Manejar el caso en que hay IdAlmacen inválidos
                    // Puedes lanzar una excepción, redirigir a una página de error, o realizar cualquier otra acción apropiada.
                    // Por ejemplo, podrías mostrar un mensaje de error en la vista.
                    ModelState.AddModelError("IdAlmacen", $"Los siguientes IdAlmacen no son válidos: {string.Join(", ", invalidAlmacenIds)}");
                    // Vuelve a cargar la vista con los datos actuales
                    return View(existingSalidaModel);
                }

                // Actualizar cantidades y manejar adición/eliminación de SalidaItems
                foreach (var selectedProduct in selectedProductsList)
                {
                    var existingSalidaItem = existingSalidaModel.SalidaItems.FirstOrDefault(si => si.IdAlmacen == selectedProduct.idAlmacen);

                    if (existingSalidaItem != null)
                    {
                        // Actualizar la cantidad existente
                        existingSalidaItem.Cantidad = selectedProduct.Quantity;
                    }
                    else
                    {
                        // Agregar nuevo SalidaItem
                        existingSalidaModel.SalidaItems.Add(new SalidaItem
                        {
                            IdAlmacen = selectedProduct.idAlmacen,
                            Cantidad = selectedProduct.Quantity
                        });
                    }
                }

                // Eliminar SalidaItems que se quitaron
                var removedSalidaItems = existingSalidaModel.SalidaItems.Where(si => !selectedProductsList.Any(sp => sp.idAlmacen == si.IdAlmacen)).ToList();
                foreach (var removedSalidaItem in removedSalidaItems)
                {
                    existingSalidaModel.SalidaItems.Remove(removedSalidaItem);
                }
            }

            if (salidaModel.NombreRecibio == "otro")
            {
                existingSalidaModel.NombreRecibio = otroOperador;
            }
            else
            {
                existingSalidaModel.NombreRecibio = salidaModel.NombreRecibio;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar el SalidaModel existente en lugar de agregarlo nuevamente
                    _context.Update(existingSalidaModel);
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
                catch (DbUpdateException ex)
                {
                    // Capturar la excepción específica
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 544)
                    {
                        // Continuar con la redirección si es el error relacionado con IDENTITY_INSERT
                        return RedirectToAction(nameof(Index));
                    }

                    // Re-lanzar la excepción si no es la esperada
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", existingSalidaModel.IdMontacargas);
            ViewData["IdAlmacen"] = new SelectList(almacenList, "IdAlmacen", "DisplayInfoAlmacen", existingSalidaModel.IdAlmacen);
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre");
            ViewBag.Admins = GetAdmins();
            ViewBag.Operadores = GetOperadores();

            TempData["FailEditSalida"] = "La edición no pudo ser completada";
            return View(existingSalidaModel);
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
                .Include(s => s.Clientes)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);
            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salidaModel = await _context.SalidaModel.FindAsync(id);

            if (salidaModel == null)
            {
                return NotFound();
            }

            _context.SalidaModel.Remove(salidaModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool SalidaModelExists(int id)
        {
            return (_context.SalidaModel?.Any(e => e.IdSalidaA == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> SalidaPDF(int? id)
        {
            if (id == null || _context.SalidaModel == null)
            {
                return NotFound();
            }

            var salidaModel = await _context.SalidaModel
                .Include(s => s.Montacargas)
                .Include(a => a.Almacen)
                .Include(s => s.Clientes)
                .Include(s => s.SalidaItems)
                    .ThenInclude(si => si.Almacen)
                .FirstOrDefaultAsync(m => m.IdSalidaA == id);

            if (salidaModel == null)
            {
                return NotFound();
            }

            return View(salidaModel);
        }
    }
}
