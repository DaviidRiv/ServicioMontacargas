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
    public class EntregaMntCrgController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public EntregaMntCrgController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        [AutorizacionAdmin]
        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.EntregaMntCrgModel
                .Include(e => e.Montacargas)
                .Select(e => new EntregaMontacargaViewModel
                {
                    IdEntregaMntCrg = e.IdEntregaMntCrg,
                    FechaEntrega = e.FechaEntrega,
                    HorometroEntrega = e.HorometroEntrega,
                    FechaRecoleccion = e.FechaRecoleccion,
                    HorometroRecoleccion = e.HorometroRecoleccion,
                    IdMontacargas = e.IdMontacargas,
                    Montacargas = e.Montacargas,
                    NivelAceiteMotor = e.NivelAceiteMotor,
                    NivelAnticongelante = e.NivelAnticongelante,
                    NivelAceiteHidraulico = e.NivelAceiteHidraulico,
                    NivelLiquidoFrenos = e.NivelLiquidoFrenos,
                    AceiteDiferencial = e.AceiteDiferencial,
                    TanqueGasSoportes = e.TanqueGasSoportes,
                    FrenoEstacionamiento = e.FrenoEstacionamiento,
                    FugaSistemaGas = e.FugaSistemaGas,
                    ElementoAire = e.ElementoAire,
                    DistanciaFrenado = e.DistanciaFrenado,
                    CapacidadCarga = e.CapacidadCarga,
                    RespaldoCarga = e.RespaldoCarga,
                    Horquillas = e.Horquillas,
                    Tablero = e.Tablero,
                    PinturaGeneral = e.PinturaGeneral,
                    CubiertaPiston = e.CubiertaPiston,
                    LlantasDireccion = e.LlantasDireccion,
                    LlantasTraccion = e.LlantasTraccion,
                    BateriaTerminales = e.BateriaTerminales,
                    LimpiezaGeneral = e.LimpiezaGeneral,
                    SistemaArranque = e.SistemaArranque,
                    LucesTrabajo = e.LucesTrabajo,
                    LucesTraseras = e.LucesTraseras,
                    Torreta = e.Torreta,
                    AlarmaReversa = e.AlarmaReversa,
                    Claxon = e.Claxon,
                    Extintor = e.Extintor,
                    Espejos = e.Espejos,
                    CinturonSeguridad = e.CinturonSeguridad,
                    Asiento = e.Asiento,
                    FaroProximidad = e.FaroProximidad,
                    Observaciones = e.Observaciones,
                    Llave = e.Llave,
                    NombreCliente = e.NombreCliente,
                    EmpresaCliente = e.EmpresaCliente,
                    NombreJacsa = e.NombreJacsa,                    
                });

            return View(await servicioMontacargasContext.ToListAsync());
        }

        [AutorizacionAdmin]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntregaMntCrgModel == null)
            {
                return NotFound();
            }

            var entregaMntCrgModel = await _context.EntregaMntCrgModel
                .Include(c => c.Montacargas)
                .FirstOrDefaultAsync(m => m.IdEntregaMntCrg == id);

            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }

            return View(entregaMntCrgModel);
        }

        private List<SelectListItem> ObtenerMontacargasOptions()
        {
            var montacargasDesdeBD = _context.MontacargasModel.ToList();

            // Mapea los resultados a SelectListItem
            var opciones = montacargasDesdeBD.Select(m => new SelectListItem
            {
                Value = m.IdMontacargas.ToString(),
                Text = $"{m.NumeroEconomico} - {m.Marca} - {m.Modelo} - {m.NumeroSerie}"
            }).ToList();

            return opciones;
        }

        [AutorizacionOperadorG]
        public IActionResult Create()
        {
            var montacargasList = _context.MontacargasModel
                .Select(m => new { m.IdMontacargas, DisplayInfoMntCrg = $"{m.NumeroEconomico} - {m.Marca} - {m.Modelo} - {m.NumeroSerie}" })
                .ToList();

            ViewData["IdMontacargas"] = new SelectList(montacargasList, "IdMontacargas", "DisplayInfoMntCrg");
            return View(new EntregaMntCrgModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntregaMntCrgModel entregaMntCrgModel)
        {
            if (entregaMntCrgModel.EvidenciaImagen1File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen1File.CopyToAsync(ms);
                    entregaMntCrgModel.EvidenciaImagen1 = ms.ToArray();
                    entregaMntCrgModel.EvidenciaImagen1Base64 = Convert.ToBase64String(entregaMntCrgModel.EvidenciaImagen1);
                }
            }

            if (entregaMntCrgModel.EvidenciaImagen2File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen2File.CopyToAsync(ms);
                    entregaMntCrgModel.EvidenciaImagen2 = ms.ToArray();
                    entregaMntCrgModel.EvidenciaImagen2Base64 = Convert.ToBase64String(entregaMntCrgModel.EvidenciaImagen2);
                }
            }

            var montacargas = await _context.MontacargasModel.FindAsync(entregaMntCrgModel.IdMontacargas);

            if (entregaMntCrgModel.HorometroEntrega < montacargas.Horometro)
            {
                ModelState.AddModelError("HorometroEntrega", "El Horometro de Entrega no puede ser menor que el actual.");
            }

            if (ModelState.IsValid)
            {
                // Actualizar el horómetro del montacargas
                await UpdateHorometro(entregaMntCrgModel.IdMontacargas, entregaMntCrgModel.HorometroEntrega);

                _context.Add(entregaMntCrgModel);
                await _context.SaveChangesAsync();
                // Agregar mensaje de éxito a TempData
                TempData["ExitoEntrega"] = "Creacion exitosa";
                return RedirectToAction(nameof(Create));
            }

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", entregaMntCrgModel.IdMontacargas);
            TempData["FailEntrega"] = "La creacion no pudo ser completada";
            return View(entregaMntCrgModel);
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


        [AutorizacionAdmin]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntregaMntCrgModel == null)
            {
                return NotFound();
            }

            var entregaMntCrgModel = await _context.EntregaMntCrgModel.FindAsync(id);
            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", entregaMntCrgModel.IdMontacargas);
            return View(entregaMntCrgModel);
        }
        [AutorizacionOperadorG]
        public async Task<IActionResult> Entrega(int? id)
        {
            if (id == null || _context.EntregaMntCrgModel == null)
            {
                return NotFound();
            }

            var entregaMntCrgModel = await _context.EntregaMntCrgModel.FindAsync(id);
            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", entregaMntCrgModel.IdMontacargas);
            return View(entregaMntCrgModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntregaMntCrgModel entregaMntCrgModel)
        {
            if (id != entregaMntCrgModel.IdEntregaMntCrg)
            {
                return NotFound();
            }

            var existingEntrega = await _context.EntregaMntCrgModel.FindAsync(id);

            if (existingEntrega == null)
            {
                return NotFound();
            }

            // Guardar los valores de las imágenes entrega antes de llamar a SetValues
            byte[] existingEvidenciaImagen1 = existingEntrega.EvidenciaImagen1;
            string existingEvidenciaImagen1Base64 = existingEntrega.EvidenciaImagen1Base64;
            byte[] existingEvidenciaImagen2 = existingEntrega.EvidenciaImagen2;
            string existingEvidenciaImagen2Base64 = existingEntrega.EvidenciaImagen2Base64;

            // Guardar los valores de las imágenes recoleccion antes de llamar a SetValues
            byte[] existingEvidenciaRImagen1 = existingEntrega.EvidenciaRImagen1;
            string existingEvidenciaRImagen1Base64 = existingEntrega.EvidenciaRImagen1Base64;
            byte[] existingEvidenciaRImagen2 = existingEntrega.EvidenciaRImagen2;
            string existingEvidenciaRImagen2Base64 = existingEntrega.EvidenciaRImagen2Base64;

            if (entregaMntCrgModel.EvidenciaImagen1File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen1File.CopyToAsync(ms);
                    entregaMntCrgModel.EvidenciaImagen1 = ms.ToArray();
                    entregaMntCrgModel.EvidenciaImagen1Base64 = Convert.ToBase64String(entregaMntCrgModel.EvidenciaImagen1);
                }
            }
            else
            {
                // Si no se proporciona un nuevo archivo, mantener el valor existente
                entregaMntCrgModel.EvidenciaImagen1 = existingEvidenciaImagen1;
                entregaMntCrgModel.EvidenciaImagen1Base64 = existingEvidenciaImagen1Base64;
            }

            if (entregaMntCrgModel.EvidenciaImagen2File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen2File.CopyToAsync(ms);
                    entregaMntCrgModel.EvidenciaImagen2 = ms.ToArray();
                    entregaMntCrgModel.EvidenciaImagen2Base64 = Convert.ToBase64String(entregaMntCrgModel.EvidenciaImagen2);
                }
            }
            else
            {
                // Si no se proporciona un nuevo archivo, mantener el valor existente
                entregaMntCrgModel.EvidenciaImagen2 = existingEvidenciaImagen2;
                entregaMntCrgModel.EvidenciaImagen2Base64 = existingEvidenciaImagen2Base64;
            }

            // Conservar los valores existentes para EvidenciaRImagen1 y EvidenciaRImagen2
            entregaMntCrgModel.EvidenciaRImagen1 = existingEvidenciaRImagen1;
            entregaMntCrgModel.EvidenciaRImagen1Base64 = existingEvidenciaRImagen1Base64;
            entregaMntCrgModel.EvidenciaRImagen2 = existingEvidenciaRImagen2;
            entregaMntCrgModel.EvidenciaRImagen2Base64 = existingEvidenciaRImagen2Base64;

            // Actualiza solo los campos necesarios (propiedades escalares)
            _context.Entry(existingEntrega).CurrentValues.SetValues(entregaMntCrgModel);

            if (ModelState.IsValid)
            {
                try
                {
                    // Guardar los cambios en la base de datos
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaMntCrgModelExists(entregaMntCrgModel.IdEntregaMntCrg))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
            return View(entregaMntCrgModel);
        }



        [HttpPost]
        public async Task<IActionResult> Recoleccion(int id, EntregaMntCrgModel entregaMntCrgModel)
        {
            if (id != entregaMntCrgModel.IdEntregaMntCrg)
            {
                return NotFound();
            }

            // Carga la entrega actual desde la base de datos
            var existingEntrega = await _context.EntregaMntCrgModel.FindAsync(id);
            if (existingEntrega == null)
            {
                return NotFound();
            }

            // Guardar los valores de las imágenes entrega antes de llamar a SetValues
            byte[] existingEvidenciaImagen1 = existingEntrega.EvidenciaImagen1;
            string existingEvidenciaImagen1Base64 = existingEntrega.EvidenciaImagen1Base64;
            byte[] existingEvidenciaImagen2 = existingEntrega.EvidenciaImagen2;
            string existingEvidenciaImagen2Base64 = existingEntrega.EvidenciaImagen2Base64;

            // Guardar los valores de las imágenes recoleccion antes de llamar a SetValues
            byte[] existingEvidenciaRImagen1 = existingEntrega.EvidenciaRImagen1;
            string existingEvidenciaRImagen1Base64 = existingEntrega.EvidenciaRImagen1Base64;
            byte[] existingEvidenciaRImagen2 = existingEntrega.EvidenciaRImagen2;
            string existingEvidenciaRImagen2Base64 = existingEntrega.EvidenciaRImagen2Base64;


            if (entregaMntCrgModel.EvidenciaRImagen1File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaRImagen1File.CopyToAsync(ms);
                    entregaMntCrgModel.EvidenciaRImagen1 = ms.ToArray();
                    entregaMntCrgModel.EvidenciaRImagen1Base64 = Convert.ToBase64String(entregaMntCrgModel.EvidenciaRImagen1);
                }
            }
            else
            {
                // Si no se proporciona un nuevo archivo, mantener el valor existente
                entregaMntCrgModel.EvidenciaRImagen1 = existingEvidenciaRImagen1;
                entregaMntCrgModel.EvidenciaRImagen1Base64 = existingEvidenciaRImagen1Base64;
            }

            if (entregaMntCrgModel.EvidenciaRImagen2File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaRImagen2File.CopyToAsync(ms);
                    entregaMntCrgModel.EvidenciaRImagen2 = ms.ToArray();
                    entregaMntCrgModel.EvidenciaRImagen2Base64 = Convert.ToBase64String(entregaMntCrgModel.EvidenciaRImagen2);
                }
            }
            else
            {
                // Si no se proporciona un nuevo archivo, mantener el valor existente
                entregaMntCrgModel.EvidenciaRImagen2 = existingEvidenciaRImagen2;
                entregaMntCrgModel.EvidenciaRImagen2Base64 = existingEvidenciaRImagen2Base64;
            }

            // Conservar los valores existentes para EvidenciaImagen1 y EvidenciaImagen2
            entregaMntCrgModel.EvidenciaImagen1 = existingEvidenciaImagen1;
            entregaMntCrgModel.EvidenciaImagen1Base64 = existingEvidenciaImagen1Base64;
            entregaMntCrgModel.EvidenciaImagen2 = existingEvidenciaImagen2;
            entregaMntCrgModel.EvidenciaImagen2Base64 = existingEvidenciaImagen2Base64;

            // Actualiza solo los campos necesarios (propiedades escalares)
            _context.Entry(existingEntrega).CurrentValues.SetValues(entregaMntCrgModel);

            var montacargas = await _context.MontacargasModel.FindAsync(entregaMntCrgModel.IdMontacargas);

            if (entregaMntCrgModel.HorometroRecoleccion < montacargas.Horometro)
            {
                ModelState.AddModelError("HorometroRecoleccion", "El Horometro de recoleccion no puede ser menor que el actual.");
                TempData["FailHoroRecoleccion"] = "El Horometro de recoleccion no puede ser menor que el actual.";

            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar el horómetro del montacargas
                    await UpdateHorometro(entregaMntCrgModel.IdMontacargas, entregaMntCrgModel.HorometroRecoleccion);

                    // Guarda los cambios en la base de datos
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaMntCrgModelExists(entregaMntCrgModel.IdEntregaMntCrg))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["ExitoRecoleccion"] = "Recoleccion exitosa";
                return RedirectToAction(nameof(Entrega), new { id = entregaMntCrgModel.IdEntregaMntCrg });
            }

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", entregaMntCrgModel.IdMontacargas);
            TempData["FailRecoleccion"] = "La recoleccion no pudo ser completada";
            return RedirectToAction(nameof(Entrega), new { id = entregaMntCrgModel.IdEntregaMntCrg });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntregaMntCrgModel == null)
            {
                return NotFound();
            }

            var entregaMntCrgModel = await _context.EntregaMntCrgModel
                .FirstOrDefaultAsync(m => m.IdEntregaMntCrg == id);
            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }

            return View(entregaMntCrgModel);
        }
        [AutorizacionAdmin]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntregaMntCrgModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.EntregaMntCrgModel'  is null.");
            }
            var entregaMntCrgModel = await _context.EntregaMntCrgModel.FindAsync(id);
            if (entregaMntCrgModel != null)
            {
                _context.EntregaMntCrgModel.Remove(entregaMntCrgModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaMntCrgModelExists(int id)
        {
            return (_context.EntregaMntCrgModel?.Any(e => e.IdEntregaMntCrg == id)).GetValueOrDefault();
        }

        [AutorizacionAdmin]
        public async Task<IActionResult> ViewReportePDF(int? id)
        {
            if (id == null || _context.EntregaMntCrgModel == null)
            {
                return NotFound();
            }

            var entregaMntCrgModel = await _context.EntregaMntCrgModel
                .Include(e => e.Montacargas)
                .FirstOrDefaultAsync(m => m.IdEntregaMntCrg == id);

            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }

            return View(entregaMntCrgModel);
        }



    }

}
