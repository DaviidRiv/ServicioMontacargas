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
    public class ChequeoDiarioController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ChequeoDiarioController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ChequeoDiarioModel.Include(c => c.Montacargas);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChequeoDiarioModel == null)
            {
                return NotFound();
            }

            var chequeoDiarioModel = await _context.ChequeoDiarioModel
                .Include(c => c.Montacargas)
                .FirstOrDefaultAsync(m => m.IdChequeoDiario == id);
            if (chequeoDiarioModel == null)
            {
                return NotFound();
            }

            return View(chequeoDiarioModel);
        }

        public IActionResult Create()
        {
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChequeoDiario,Fecha,HorometroActual,IdMontacargas,NivelAceiteMotor,NivelRefrigerante,FugaLineaGas,FuncPedestalFreno,FrenoMano,FugasAceiteH,FuncDireccion,IndicadoresTemp,IndicadoresVolt,IndicadoresPA,TensionCadenas,LlantasBirlos,CondicionesGnrls,PalancaAvanceReversa,SistemaLevante,EquipoSeguridad,LucesTrabajo,Claxon,Torreta,Extintor,CinturonSeguridad,EspejoRetrovisor,Alarma,PlafonStop,CapacidadCarga,Comentarios,NombreOperador,FirmaOperador")] ChequeoDiarioModel chequeoDiarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chequeoDiarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", chequeoDiarioModel.IdMontacargas);
            return View(chequeoDiarioModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChequeoDiarioModel == null)
            {
                return NotFound();
            }

            var chequeoDiarioModel = await _context.ChequeoDiarioModel.FindAsync(id);
            if (chequeoDiarioModel == null)
            {
                return NotFound();
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", chequeoDiarioModel.IdMontacargas);
            return View(chequeoDiarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChequeoDiario,Fecha,HorometroActual,IdMontacargas,NivelAceiteMotor,NivelRefrigerante,FugaLineaGas,FuncPedestalFreno,FrenoMano,FugasAceiteH,FuncDireccion,IndicadoresTemp,IndicadoresVolt,IndicadoresPA,TensionCadenas,LlantasBirlos,CondicionesGnrls,PalancaAvanceReversa,SistemaLevante,EquipoSeguridad,LucesTrabajo,Claxon,Torreta,Extintor,CinturonSeguridad,EspejoRetrovisor,Alarma,PlafonStop,CapacidadCarga,Comentarios,NombreOperador,FirmaOperador")] ChequeoDiarioModel chequeoDiarioModel)
        {
            if (id != chequeoDiarioModel.IdChequeoDiario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chequeoDiarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChequeoDiarioModelExists(chequeoDiarioModel.IdChequeoDiario))
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
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "NumeroEconomico", chequeoDiarioModel.IdMontacargas);
            return View(chequeoDiarioModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChequeoDiarioModel == null)
            {
                return NotFound();
            }

            var chequeoDiarioModel = await _context.ChequeoDiarioModel
                .Include(c => c.Montacargas)
                .FirstOrDefaultAsync(m => m.IdChequeoDiario == id);
            if (chequeoDiarioModel == null)
            {
                return NotFound();
            }

            return View(chequeoDiarioModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChequeoDiarioModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ChequeoDiarioModel'  is null.");
            }
            var chequeoDiarioModel = await _context.ChequeoDiarioModel.FindAsync(id);
            if (chequeoDiarioModel != null)
            {
                _context.ChequeoDiarioModel.Remove(chequeoDiarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChequeoDiarioModelExists(int id)
        {
          return (_context.ChequeoDiarioModel?.Any(e => e.IdChequeoDiario == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> ChequeoDiarioPDF(int? id)
        {
            if (id == null || _context.ChequeoDiarioModel == null)
            {
                return NotFound();
            }

            var chequeoDiarioModel = await _context.ChequeoDiarioModel
                .Include(c => c.Montacargas)
                .FirstOrDefaultAsync(m => m.IdChequeoDiario == id);

            if (chequeoDiarioModel == null)
            {
                return NotFound();
            }

            return View(chequeoDiarioModel);
        }
    }
}
