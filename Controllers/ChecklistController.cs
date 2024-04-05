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
    public class ChecklistController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ChecklistController(ServicioMontacargasContext context)
        {
            _context = context;
        }
        [AutorizacionAdmin]
        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ChecklistModel
                .Include(c => c.Montacargas)
                .Include(c => c.Clientes)
                .Select(c => new ChecklistViewModel
                { 
                    IdChecklist = c.IdChecklist,
                    nombreOperador = c.nombreOperador,
                    nombreJacsa = c.nombreJacsa,
                    IdClientes = c.IdClientes,
                    Clientes = c.Clientes,
                    turno = c.turno,
                    IdMontacargas = c.IdMontacargas,
                    Montacargas = c.Montacargas,
                    NumeroEconomicoMontacargas = c.NumeroEconomicoMontacargas,
                    horometro = c.horometro,
                    fecha = c.fecha,
                    NivelAceiteMotor = c.NivelAceiteMotor,
                    NivelAnticongelante = c.NivelAnticongelante,
                    NivelAceiteHidraulico = c.NivelAceiteHidraulico,
                    NivelLiquidoFrenos = c.NivelLiquidoFrenos,
                    BandaVentilador = c.BandaVentilador,
                    TanqueGasSoportes = c.TanqueGasSoportes,
                    FrenoEstacionamiento = c.FrenoEstacionamiento,
                    FugaSistemaGas = c.FugaSistemaGas,
                    DistanciaFrenado = c.DistanciaFrenado,
                    RespaldoCarga = c.RespaldoCarga,
                    Horquillas = c.Horquillas,
                    Golpes = c.Golpes,
                    Tablero = c.Tablero,
                    PinturaGeneral = c.PinturaGeneral,
                    CubiertaPiston = c.CubiertaPiston,
                    LlantasDireccion = c.LlantasDireccion,
                    LlantasTraccion = c.LlantasTraccion,
                    BateriaTerminales = c.BateriaTerminales,
                    LimpiezaGeneral = c.LimpiezaGeneral,
                    Radiador = c.Radiador,
                    SistemaArranque = c.SistemaArranque,
                    LucesTrabajo = c.LucesTrabajo,
                    LucesTraseras = c.LucesTraseras,
                    Torreta = c.Torreta,
                    AlarmaReversa = c.AlarmaReversa,
                    Claxon = c.Claxon,
                    Extintor = c.Extintor,
                    Espejos = c.Espejos,
                    CinturonSeguridad = c.CinturonSeguridad,
                    Asiento = c.Asiento,
                    FaroProximidad = c.FaroProximidad,
                    Ruidos = c.Ruidos,
                    Llave = c.Llave,
                    Observaciones = c.Observaciones,
                });

            return View(await servicioMontacargasContext.ToListAsync());
        }
        [AutorizacionAdmin]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChecklistModel == null)
            {
                return NotFound();
            }

            var checklistModel = await _context.ChecklistModel
                .Include(c => c.Montacargas)
                .Include(c => c.Clientes)
                .FirstOrDefaultAsync(m => m.IdChecklist == id);

            if (checklistModel == null)
            {
                return NotFound();
            }

            return View(checklistModel);
        }
        [AutorizacionTecnicoMntcAd]
        public IActionResult Create()
        {
            var montacargasList = _context.MontacargasModel
                .Select(m => new { m.IdMontacargas, DisplayInfoMntCrg = $"{m.NumeroEconomico} - {m.Marca} - {m.Modelo} - {m.NumeroSerie}" })
                .ToList();

            var clientesList = _context.ClientesModel
                .Select(m => new { m.IdClientes, DisplayInfoCl = $"{m.IdClientes} - {m.Nombre}" })
                .ToList();

            ViewData["IdMontacargas"] = new SelectList(montacargasList, "IdMontacargas", "DisplayInfoMntCrg");
            ViewData["IdClientes"] = new SelectList(clientesList, "IdClientes", "DisplayInfoCl");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChecklistModel checklistModel)
        {
            if (checklistModel.EvidenciaImagen1File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await checklistModel.EvidenciaImagen1File.CopyToAsync(ms);
                    checklistModel.EvidenciaImagen1 = ms.ToArray();
                    checklistModel.EvidenciaImagen1Base64 = Convert.ToBase64String(checklistModel.EvidenciaImagen1);
                }
            }

            if (checklistModel.EvidenciaImagen2File != null)
            {
                // Convierte IFormFile a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    await checklistModel.EvidenciaImagen2File.CopyToAsync(ms);
                    checklistModel.EvidenciaImagen2 = ms.ToArray();
                    checklistModel.EvidenciaImagen2Base64 = Convert.ToBase64String(checklistModel.EvidenciaImagen2);
                }
            }

            // Obtener Montacargas correspondiente al número económico
            var montacargas = _context.MontacargasModel.FirstOrDefault(m => m.NumeroEconomico == checklistModel.NumeroEconomicoMontacargas);

            if (montacargas != null)
            {
                checklistModel.Montacargas = montacargas;

                if (ModelState.IsValid)
                {
                    _context.Add(checklistModel);
                    await _context.SaveChangesAsync();
                    TempData["ExitoChecklist"] = "Creacion Exitosa";
                    return RedirectToAction(nameof(Create));
                }
            }
            else
            {
                // Mostrar mensaje de error si el Montacargas no existe
                ModelState.AddModelError("NumeroEconomicoMontacargas", "El número económico del montacargas no existe.");
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", checklistModel.IdMontacargas);
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "DisplayInfoCl", checklistModel.IdClientes);
            TempData["FailChecklist"] = "La creacion no pudo ser completada";
            return View(checklistModel);
        }

        [AutorizacionAdmin]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChecklistModel == null)
            {
                return NotFound();
            }

            var checklistModel = await _context.ChecklistModel.FindAsync(id);
            if (checklistModel == null)
            {
                return NotFound();
            }

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", checklistModel.IdMontacargas);
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "DisplayInfoCl", checklistModel.IdClientes);

            return View(checklistModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChecklistModel checklistModel)
        {
            if (id != checklistModel.IdChecklist)
            {
                return NotFound();
            }

            var existingChecklist = await _context.ChecklistModel.FindAsync(id);

            // Verificar si se proporciona un nuevo número económico de montacargas
            if (!string.IsNullOrWhiteSpace(checklistModel.NumeroEconomicoMontacargas))
            {
                // Obtener Montacargas correspondiente al número económico
                var montacargas = _context.MontacargasModel.FirstOrDefault(m => m.NumeroEconomico == checklistModel.NumeroEconomicoMontacargas);

                if (montacargas != null)
                {
                    // Asignar el Montacargas al modelo
                    checklistModel.Montacargas = montacargas;

                    // Asegurarse de que el IdMontacargas en el modelo tenga el valor correcto
                    checklistModel.IdMontacargas = montacargas.IdMontacargas;
                }
                else
                {
                    // Mostrar mensaje de error o tomar alguna acción
                    ModelState.AddModelError("NumeroEconomicoMontacargas", "El número económico del montacargas no existe.");
                    // Puedes regresar a la vista sin intentar guardar los cambios
                    return View(checklistModel);
                }
            }
            else
            {
                // Si no se proporciona un nuevo número económico, mantener el existente
                checklistModel.Montacargas = existingChecklist.Montacargas;
                // Asegurarse de que el IdMontacargas en el modelo tenga el valor correcto
                checklistModel.IdMontacargas = existingChecklist.Montacargas.IdMontacargas;
            }


            // Verificar si se proporciona una nueva imagen1
            if (checklistModel.EvidenciaImagen1File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await checklistModel.EvidenciaImagen1File.CopyToAsync(ms);
                    checklistModel.EvidenciaImagen1 = ms.ToArray();
                    checklistModel.EvidenciaImagen1Base64 = Convert.ToBase64String(checklistModel.EvidenciaImagen1);
                }
            }
            else
            {
                // Si no se proporciona una nueva imagen1, mantener la existente
                checklistModel.EvidenciaImagen1 = existingChecklist.EvidenciaImagen1;
                checklistModel.EvidenciaImagen1Base64 = existingChecklist.EvidenciaImagen1Base64;
            }

            // Verificar si se proporciona una nueva imagen2
            if (checklistModel.EvidenciaImagen2File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await checklistModel.EvidenciaImagen2File.CopyToAsync(ms);
                    checklistModel.EvidenciaImagen2 = ms.ToArray();
                    checklistModel.EvidenciaImagen2Base64 = Convert.ToBase64String(checklistModel.EvidenciaImagen2);
                }
            }
            else
            {
                // Si no se proporciona una nueva imagen2, mantener la existente
                checklistModel.EvidenciaImagen2 = existingChecklist.EvidenciaImagen2;
                checklistModel.EvidenciaImagen2Base64 = existingChecklist.EvidenciaImagen2Base64;
            }

            // Actualizar solo los campos necesarios (propiedades escalares)
            _context.Entry(existingChecklist).CurrentValues.SetValues(checklistModel);

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChecklistModelExists(checklistModel.IdChecklist))
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

            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", checklistModel.Montacargas?.IdMontacargas);
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "DisplayInfoCl", checklistModel.IdClientes);

            return View(checklistModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChecklistModel == null)
            {
                return NotFound();
            }

            var checklistModel = await _context.ChecklistModel
                .Include(c => c.Montacargas)
                .FirstOrDefaultAsync(m => m.IdChecklist == id);
            if (checklistModel == null)
            {
                return NotFound();
            }

            return View(checklistModel);
        }
        [AutorizacionAdmin]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChecklistModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ChecklistModel'  is null.");
            }
            var checklistModel = await _context.ChecklistModel.FindAsync(id);
            if (checklistModel != null)
            {
                _context.ChecklistModel.Remove(checklistModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChecklistModelExists(int id)
        {
            return (_context.ChecklistModel?.Any(e => e.IdChecklist == id)).GetValueOrDefault();
        }
        [AutorizacionAdmin]
        public async Task<IActionResult> ReportePDF(int? id)
        {
            if (id == null || _context.ChecklistModel == null)
            {
                return NotFound();
            }

            var checklistModel = await _context.ChecklistModel
                .Include(c => c.Montacargas)
                .Include(c => c.Clientes)
                .FirstOrDefaultAsync(m => m.IdChecklist == id);

            if (checklistModel == null)
            {
                return NotFound();
            }

            return View(checklistModel);
        }
    }
}
