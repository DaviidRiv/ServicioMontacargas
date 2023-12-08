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
    public class EntregaMntCrgController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public EntregaMntCrgController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        // GET: EntregaMntCrg
        public async Task<IActionResult> Index()
        {
            return _context.EntregaMntCrgModel != null ?
                        View(await _context.EntregaMntCrgModel.ToListAsync()) :
                        Problem("Entity set 'ServicioMontacargasContext.EntregaMntCrgModel'  is null.");
        }

        // GET: EntregaMntCrg/Details/5
        public async Task<IActionResult> Details(int? id)
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

        private List<SelectListItem> ObtenerMontacargasOptionsDesdeBD()
        {
            var montacargasDesdeBD = _context.MontacargasModel.ToList();

            // Mapea los resultados a SelectListItem
            var opciones = montacargasDesdeBD.Select(m => new SelectListItem
            {
                Value = m.IdMontacargas.ToString(),
                Text = $"{m.IdMontacargas} - {m.NumeroEconomico} - {m.Marca} - {m.Modelo} - {m.NumeroSerie}" // Personaliza el texto según tus necesidades
            }).ToList();

            return opciones;
        }

        // GET: EntregaMntCrg/Create
        public IActionResult Create()
        {
            ViewBag.MontacargasOptions = ObtenerMontacargasOptionsDesdeBD();
            return View(new EntregaMntCrgModel());
        }

        // POST: EntregaMntCrg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            if (ModelState.IsValid)
            {
                _context.Add(entregaMntCrgModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(entregaMntCrgModel);
        }


        // GET: EntregaMntCrg/Edit/5
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
            return View(entregaMntCrgModel);
        }

        // POST: EntregaMntCrg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntregaMntCrg,FechaEntrega,HorometroEntrega,idMontacargas,NivelAceiteMotor,NivelAnticongelante,NivelAceiteHidraulico,NivelLiquidoFrenos,TanqueGasSoportes,FrenoEstacionamiento,FugaSistemaGas,ElementoAire,DistanciaFrenado,CapacidadCarga,RespaldoCarga,Horquillas,Tablero,PinturaGeneral,CubiertaPiston,LlantasDireccion,LlantasTraccion,BateriaTerminales,LimpiezaGeneral,SistemaArranque,LucesTrabajo,LucesTraseras,Torreta,AlarmaReversa,Claxon,Extintor,Espejos,CinturonSeguridad,Asiento,FaroProximidad,Observaciones,Llave,NombreCliente,EmpresaCliente,FirmaCliente,EvidenciaImagen1,EvidenciaImagen2")] EntregaMntCrgModel entregaMntCrgModel)
        {
            if (id != entregaMntCrgModel.IdEntregaMntCrg)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregaMntCrgModel);
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
                return RedirectToAction(nameof(Index));
            }
            return View(entregaMntCrgModel);
        }

        // GET: EntregaMntCrg/Delete/5
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
    }
}
