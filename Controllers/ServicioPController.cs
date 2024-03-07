using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Commons.Actions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;
using static ServicioMontacargas.Models.ServicioPModel;

namespace ServicioMontacargas.Controllers
{
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
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "Nombre", servicioPModel.IdClientes);
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", servicioPModel.IdMontacargas);
            return View(servicioPModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicioP,IdClientes,IdMontacargas,Fecha,NivelAceiteMotor,FiltroAceiteMotor,ElementosAire,VálvulasPCV,Limpieza,Fugas,CapuchoBujia,SelloCapBujia,Tiempo,Vaporizador,ValvulaVacio,Mezclador,RepuestoVaporizador,RepuestoMezclador,RespuestoValVacio,Selenoide,Filtro,TanqueGas,MangueConex,FugasSistema,Alternador,BateriaTermi,Indicadores,Anticongelante,BandaV,MangueraRS,MangueraRI,Radiador,Ventilador,MotorA,Bobina,CablesB,TapaD,RotorD,PastillaC,Distribuidor,SwitchE,EdoNivelA,FiltroT,FugasA,Mangueras,CablePedal,MangosDire,Eslabon,PernosEslabon,Llantas,BirlosTurcas,EdoyNivelA,FugasSH,NivelLiquidoF,CilindroM,Ajuste,Purgar,FugasF,FrenoEst,AceiteDif,Crucetas,LlantasTM,LucesTrab,PlafonAssy,Torreta,AlarmaReversa,Claxon,Extintor,Espejos,CinturonS,RespaldoC,Horquillas,Asiento,Golpes,Tablero,Pintura,CubiertaP,ServicioLyE,FirmaJ,FirmaC,Cantidad,NoParte,Descripcion,Comentarios")] ServicioPModel servicioPModel)
        {
            if (id != servicioPModel.IdServicioP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioPModel);
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
    }
}
