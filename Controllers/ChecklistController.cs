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
    public class ChecklistController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ChecklistController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioMontacargasContext = _context.ChecklistModel
                .Include(c => c.Montacargas)
                .Include(c => c.Clientes); // Incluye la información de los clientes

            return View(await servicioMontacargasContext.ToListAsync());
        }
        
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
            if (ModelState.IsValid)
            {
                _context.Add(checklistModel);
                await _context.SaveChangesAsync();
                TempData["ExitoChecklist"] = "Creacion exitosa";
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", checklistModel.IdMontacargas);
            ViewData["IdClientes"] = new SelectList(_context.ClientesModel, "IdClientes", "DisplayInfoCl", checklistModel.IdClientes);
            TempData["FailChecklist"] = "La creacion no pudo ser completada";
            return View(checklistModel);
        }

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

            var existingEntrega = await _context.ChecklistModel.FindAsync(id);

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
                checklistModel.EvidenciaImagen1 = existingEntrega.EvidenciaImagen1;
                checklistModel.EvidenciaImagen1Base64 = existingEntrega.EvidenciaImagen1Base64;
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
                checklistModel.EvidenciaImagen2 = existingEntrega.EvidenciaImagen2;
                checklistModel.EvidenciaImagen2Base64 = existingEntrega.EvidenciaImagen2Base64;
            }

            // Actualiza solo los campos necesarios (propiedades escalares)
            _context.Entry(existingEntrega).CurrentValues.SetValues(checklistModel);

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
            ViewData["IdMontacargas"] = new SelectList(_context.MontacargasModel, "IdMontacargas", "DisplayInfoMntCrg", checklistModel.IdMontacargas);
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
