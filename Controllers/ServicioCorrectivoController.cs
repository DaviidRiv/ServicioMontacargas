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
    public class ServicioCorrectivoController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ServicioCorrectivoController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        // GET: ServicioCorrectivo
        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ServicioCorrectivoModel.Include(s => s.Salidas).Include(s => s.Tareas);
            return View(await servicioMontacargasContext.ToListAsync());
        }

        // GET: ServicioCorrectivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioCorrectivoModel == null)
            {
                return NotFound();
            }

            var servicioCorrectivoModel = await _context.ServicioCorrectivoModel
                .Include(s => s.Salidas)
                .Include(s => s.Tareas)
                .FirstOrDefaultAsync(m => m.idServicioC == id);
            if (servicioCorrectivoModel == null)
            {
                return NotFound();
            }

            return View(servicioCorrectivoModel);
        }

        // GET: ServicioCorrectivo/Create
        public IActionResult Create()
        {
            ViewData["IdSalidaA"] = new SelectList(_context.SalidaModel, "IdSalidaA", "IdSalidaA");
            ViewData["ComponenteId"] = new SelectList(_context.ProcesosCorrectivoModel, "ComponenteId", "ComponenteId");
            return View();
        }

        // POST: ServicioCorrectivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idServicioC,IdSalidaA,ComponenteId,FechaR,FechaE,Refacciones,ServicioD")] ServicioCorrectivoModel servicioCorrectivoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioCorrectivoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSalidaA"] = new SelectList(_context.SalidaModel, "IdSalidaA", "IdSalidaA", servicioCorrectivoModel.IdSalidaA);
            ViewData["ComponenteId"] = new SelectList(_context.ProcesosCorrectivoModel, "ComponenteId", "ComponenteId", servicioCorrectivoModel.ComponenteId);
            return View(servicioCorrectivoModel);
        }

        // GET: ServicioCorrectivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioCorrectivoModel == null)
            {
                return NotFound();
            }

            var servicioCorrectivoModel = await _context.ServicioCorrectivoModel.FindAsync(id);
            if (servicioCorrectivoModel == null)
            {
                return NotFound();
            }
            ViewData["IdSalidaA"] = new SelectList(_context.SalidaModel, "IdSalidaA", "IdSalidaA", servicioCorrectivoModel.IdSalidaA);
            ViewData["ComponenteId"] = new SelectList(_context.ProcesosCorrectivoModel, "ComponenteId", "ComponenteId", servicioCorrectivoModel.ComponenteId);
            return View(servicioCorrectivoModel);
        }

        // POST: ServicioCorrectivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idServicioC,IdSalidaA,ComponenteId,FechaR,FechaE,Refacciones,ServicioD")] ServicioCorrectivoModel servicioCorrectivoModel)
        {
            if (id != servicioCorrectivoModel.idServicioC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioCorrectivoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioCorrectivoModelExists(servicioCorrectivoModel.idServicioC))
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
            ViewData["IdSalidaA"] = new SelectList(_context.SalidaModel, "IdSalidaA", "IdSalidaA", servicioCorrectivoModel.IdSalidaA);
            ViewData["ComponenteId"] = new SelectList(_context.ProcesosCorrectivoModel, "ComponenteId", "ComponenteId", servicioCorrectivoModel.ComponenteId);
            return View(servicioCorrectivoModel);
        }

        // GET: ServicioCorrectivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioCorrectivoModel == null)
            {
                return NotFound();
            }

            var servicioCorrectivoModel = await _context.ServicioCorrectivoModel
                .Include(s => s.Salidas)
                .Include(s => s.Tareas)
                .FirstOrDefaultAsync(m => m.idServicioC == id);
            if (servicioCorrectivoModel == null)
            {
                return NotFound();
            }

            return View(servicioCorrectivoModel);
        }

        // POST: ServicioCorrectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioCorrectivoModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ServicioCorrectivoModel'  is null.");
            }
            var servicioCorrectivoModel = await _context.ServicioCorrectivoModel.FindAsync(id);
            if (servicioCorrectivoModel != null)
            {
                _context.ServicioCorrectivoModel.Remove(servicioCorrectivoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioCorrectivoModelExists(int id)
        {
          return (_context.ServicioCorrectivoModel?.Any(e => e.idServicioC == id)).GetValueOrDefault();
        }
    }
}
