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
    public class MontacargaController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public MontacargaController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        // GET: Montacarga
        public async Task<IActionResult> Index()
        {
              return _context.MontacargasModel != null ? 
                          View(await _context.MontacargasModel.ToListAsync()) :
                          Problem("Entity set 'ServicioMontacargasContext.MontacargasModel'  is null.");
        }

        // GET: Montacarga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MontacargasModel == null)
            {
                return NotFound();
            }

            var montacargasModel = await _context.MontacargasModel
                .FirstOrDefaultAsync(m => m.IdMontacargas == id);
            if (montacargasModel == null)
            {
                return NotFound();
            }

            return View(montacargasModel);
        }

        // GET: Montacarga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Montacarga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMontacargas,NumeroSerie,NumeroEconomico,Marca,Modelo,Horometro,Status,Equipo,HorometroMtto,HorasMtto,cliente,tipo,capacidad,fases")] MontacargasModel montacargasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montacargasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(montacargasModel);
        }

        // GET: Montacarga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MontacargasModel == null)
            {
                return NotFound();
            }

            var montacargasModel = await _context.MontacargasModel.FindAsync(id);
            if (montacargasModel == null)
            {
                return NotFound();
            }
            return View(montacargasModel);
        }

        // POST: Montacarga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMontacargas,NumeroSerie,NumeroEconomico,Marca,Modelo,Horometro,Status,Equipo,HorometroMtto,HorasMtto,cliente,tipo,capacidad,fases")] MontacargasModel montacargasModel)
        {
            if (id != montacargasModel.IdMontacargas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(montacargasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MontacargasModelExists(montacargasModel.IdMontacargas))
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
            return View(montacargasModel);
        }

        // GET: Montacarga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MontacargasModel == null)
            {
                return NotFound();
            }

            var montacargasModel = await _context.MontacargasModel
                .FirstOrDefaultAsync(m => m.IdMontacargas == id);
            if (montacargasModel == null)
            {
                return NotFound();
            }

            return View(montacargasModel);
        }

        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MontacargasModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.MontacargasModel'  is null.");
            }
            var montacargasModel = await _context.MontacargasModel.FindAsync(id);
            if (montacargasModel != null)
            {
                _context.MontacargasModel.Remove(montacargasModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontacargasModelExists(int id)
        {
          return (_context.MontacargasModel?.Any(e => e.IdMontacargas == id)).GetValueOrDefault();
        }
    }
}
