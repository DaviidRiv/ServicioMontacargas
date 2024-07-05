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
    [AutorizacionAdmin]
    public class RevisionCamionController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public RevisionCamionController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.RevisionCamionModel.Include(r => r.Montacargas);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RevisionCamionModel == null)
            {
                return NotFound();
            }

            var revisionCamionModel = await _context.RevisionCamionModel
                .Include(r => r.Montacargas)
                .FirstOrDefaultAsync(m => m.IdRevisionCamion == id);
            if (revisionCamionModel == null)
            {
                return NotFound();
            }

            return View(revisionCamionModel);
        }

        public IActionResult Create()
        {
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRevisionCamion,NivelCombustible,Fecha,Kilometraje,IdMontacargas,Comentarios,NivelAceiteMotor,NivelAceiteTrans,NivelAceiteDirec,NivelAceiteHidrau,RefrigeranteMotor,LiquidoFrenos,Radiador,IndicadorCombus,IndicadorTemp,IndicadorPresionA,BateriayTerminales,Direccion,Frenos,FrenosEstac,LineasAire,SuspensionD,Muelles,PinturayC,OrdenyLG,LlantasDelanteras,LlantasTraserasLD,LlantasTraserasLI,LucesDelanterasB,LucesDelanterasA,LucesTraseras,LucesFreno,LucesIntermitentes,LucesDireccionales,Claxon,AlarmaReversa,Limpiaparabrisas,EspejosRetrovisores,ParabrisasVD,MedallonVT,VidrioLD,VidrioLI,AleronD,AleronI,Extintor,TaponC,NombreOperador,FirmaOperador,NombreInspector,FirmaInspector")] RevisionCamionModel revisionCamionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revisionCamionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", revisionCamionModel.IdMontacargas);
            return View(revisionCamionModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RevisionCamionModel == null)
            {
                return NotFound();
            }

            var revisionCamionModel = await _context.RevisionCamionModel
                .Include(s => s.Montacargas)
                .FirstOrDefaultAsync(m => m.IdRevisionCamion == id);

            if (revisionCamionModel == null)
            {
                return NotFound();
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", revisionCamionModel.IdMontacargas);
            return View(revisionCamionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRevisionCamion,NivelCombustible,Fecha,Kilometraje,IdMontacargas,Comentarios,NivelAceiteMotor,NivelAceiteTrans,NivelAceiteDirec,NivelAceiteHidrau,RefrigeranteMotor,LiquidoFrenos,Radiador,IndicadorCombus,IndicadorTemp,IndicadorPresionA,BateriayTerminales,Direccion,Frenos,FrenosEstac,LineasAire,SuspensionD,Muelles,PinturayC,OrdenyLG,LlantasDelanteras,LlantasTraserasLD,LlantasTraserasLI,LucesDelanterasB,LucesDelanterasA,LucesTraseras,LucesFreno,LucesIntermitentes,LucesDireccionales,Claxon,AlarmaReversa,Limpiaparabrisas,EspejosRetrovisores,ParabrisasVD,MedallonVT,VidrioLD,VidrioLI,AleronD,AleronI,Extintor,TaponC,NombreOperador,FirmaOperador,NombreInspector,FirmaInspector")] RevisionCamionModel revisionCamionModel)
        {
            if (id != revisionCamionModel.IdRevisionCamion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revisionCamionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevisionCamionModelExists(revisionCamionModel.IdRevisionCamion))
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
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", revisionCamionModel.IdMontacargas);
            return View(revisionCamionModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RevisionCamionModel == null)
            {
                return NotFound();
            }

            var revisionCamionModel = await _context.RevisionCamionModel
                .Include(r => r.Montacargas)
                .FirstOrDefaultAsync(m => m.IdRevisionCamion == id);
            if (revisionCamionModel == null)
            {
                return NotFound();
            }

            return View(revisionCamionModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RevisionCamionModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.RevisionCamionModel'  is null.");
            }
            var revisionCamionModel = await _context.RevisionCamionModel.FindAsync(id);
            if (revisionCamionModel != null)
            {
                _context.RevisionCamionModel.Remove(revisionCamionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevisionCamionModelExists(int id)
        {
          return (_context.RevisionCamionModel?.Any(e => e.IdRevisionCamion == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> RevisionCamionPDF(int? id)
        {
            if (id == null || _context.RevisionCamionModel == null)
            {
                return NotFound();
            }

            var revisionCamionModel = await _context.RevisionCamionModel
                .Include(r => r.Montacargas)
                .FirstOrDefaultAsync(m => m.IdRevisionCamion == id);

            if (revisionCamionModel == null)
            {
                return NotFound();
            }

            return View(revisionCamionModel);
        }
    }
}
