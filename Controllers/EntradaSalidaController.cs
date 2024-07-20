using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Auths;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;

namespace ServicioMontacargas.Controllers
{
    [AutorizacionAll]
    public class EntradaSalidaController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public EntradaSalidaController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var iduser = HttpContext.Session.GetString("IdUsuario");
            var nombreCompleto = HttpContext.Session.GetString("NombreC");
            var rol = HttpContext.Session.GetString("RolUser");

            // Buscar el último registro del usuario que no tiene FechaSalida registrada
            var ultimoRegistro = await _context.EntradaSalidaModel
                .Where(e => e.IdUser.ToString() == iduser && e.Personal == nombreCompleto && e.FechaSalida == null)
                .OrderByDescending(e => e.FechaEntrada)
                .FirstOrDefaultAsync();

            // Asignar el tipo al ViewBag basado en la existencia de FechaSalida
            if (ultimoRegistro != null)
            {
                ViewBag.UltimoTipo = "Salida"; 
            }
            else
            {
                ViewBag.UltimoTipo = "Entrada";
            }

            return _context.EntradaSalidaModel != null ?
                View(await _context.EntradaSalidaModel.ToListAsync()) :
                Problem("Entity set 'ServicioMontacargasContext.EntradaSalidaModels' is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradaSalidaModel == null)
            {
                return NotFound();
            }

            var entradaSalidaModel = await _context.EntradaSalidaModel
                .FirstOrDefaultAsync(m => m.IdEntradaSalida == id);
            if (entradaSalidaModel == null)
            {
                return NotFound();
            }

            return View(entradaSalidaModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntradaSalida,Personal,FechaEntrada,FechaSalida,Tipo,IdUser")] EntradaSalidaModel entradaSalidaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaSalidaModel);
                await _context.SaveChangesAsync();
                TempData["SuccessEntrada"] = "Creación Exitosa.";
                return RedirectToAction(nameof(Index));
            }
            TempData["FailEntrada"] = "La creación no pudo ser completada.";
            return View(entradaSalidaModel);
        }

        [HttpPost]
        public async Task<IActionResult> Entrada(int? iduser, string? personal, string? tipo, double? latitud, double? longitud)
        {
            if (ModelState.IsValid)
            {
                TimeZoneInfo mexicoCityTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, mexicoCityTimeZone);
                string formattedDateTime = localDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                var entradaSalidaModel = new EntradaSalidaModel
                {
                    Personal = personal,
                    FechaEntrada = formattedDateTime,
                    Tipo = tipo,
                    IdUser = iduser,
                    LatitudE = latitud,
                    LongitudE = longitud
                };

                _context.Add(entradaSalidaModel);
                await _context.SaveChangesAsync();
                TempData["SuccessEntrada"] = "Entrada Registrada Correctamente.";
                return RedirectToAction(nameof(Index));
            }
            TempData["FailEntrada"] = "La Entrada no pudo ser Registrada.";
            return RedirectToAction(nameof(Index));
        }
      

        [HttpPost]
        public async Task<IActionResult> Salida(int? IdUser, string? Tipo, double? latitud, double? longitud)
        {
            if (IdUser == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid user ID or form data.");
            }

            // Buscar el último registro de entrada correspondiente al IdUser
            var entradaSalidaModel = await _context.EntradaSalidaModel
                .Where(e => e.IdUser == IdUser && e.Tipo == "Entrada" && e.FechaSalida == null)
                .OrderByDescending(e => e.FechaEntrada)
                .FirstOrDefaultAsync();

            if (entradaSalidaModel == null)
            {
                return NotFound("No matching entry found for the given user.");
            }
            TimeZoneInfo mexicoCityTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, mexicoCityTimeZone);
            string formattedDateTime = localDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            entradaSalidaModel.FechaSalida = formattedDateTime;
            entradaSalidaModel.Tipo = Tipo;
            entradaSalidaModel.LatitudS = latitud;
            entradaSalidaModel.LongitudS = longitud;

            try
            {
                _context.Update(entradaSalidaModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaSalidaModelExists(entradaSalidaModel.IdEntradaSalida))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["SuccessEntrada"] = "Salida Registrada Correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradaSalidaModel == null)
            {
                return NotFound();
            }

            var entradaSalidaModel = await _context.EntradaSalidaModel.FindAsync(id);
            if (entradaSalidaModel == null)
            {
                return NotFound();
            }
            return View(entradaSalidaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntradaSalida,Personal,FechaEntrada,FechaSalida,Tipo,IdUser")] EntradaSalidaModel entradaSalidaModel)
        {
            if (id != entradaSalidaModel.IdEntradaSalida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaSalidaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaSalidaModelExists(entradaSalidaModel.IdEntradaSalida))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessEntrada"] = "Registro Modificado Correctamente.";
                return RedirectToAction(nameof(Index));
            }
            TempData["FailEntrada"] = "Hubo un error al modificar el registro.";
            return View(entradaSalidaModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradaSalidaModel == null)
            {
                return NotFound();
            }

            var entradaSalidaModel = await _context.EntradaSalidaModel
                .FirstOrDefaultAsync(m => m.IdEntradaSalida == id);
            if (entradaSalidaModel == null)
            {
                return NotFound();
            }

            return View(entradaSalidaModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradaSalidaModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.EntradaSalidaModel'  is null.");
            }
            var entradaSalidaModel = await _context.EntradaSalidaModel.FindAsync(id);
            if (entradaSalidaModel != null)
            {
                _context.EntradaSalidaModel.Remove(entradaSalidaModel);
            }
            
            await _context.SaveChangesAsync();
            TempData["SuccessEntrada"] = "Registro Borrado Correctamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaSalidaModelExists(int id)
        {
          return (_context.EntradaSalidaModel?.Any(e => e.IdEntradaSalida == id)).GetValueOrDefault();
        }
    }
}
