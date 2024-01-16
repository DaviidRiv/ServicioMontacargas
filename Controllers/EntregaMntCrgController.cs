using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;
using ServicioMontacargas.Auths;
using iText.Kernel.Pdf;
using iText.Layout;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using iText.Html2pdf;
using System.IO;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc.ViewEngines;

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
                .Include(c => c.Montacarga);

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
            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
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

            if (ModelState.IsValid)
            {
                _context.Add(entregaMntCrgModel);
                await _context.SaveChangesAsync();
                // Agregar mensaje de éxito a TempData
                TempData["ExitoEntrega"] = "Creacion exitosa";
                return RedirectToAction(nameof(Create));
            }

            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
            TempData["FailEntrega"] = "La creacion no pudo ser completada";
            return View(entregaMntCrgModel);
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
            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
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
            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
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

            // Obtener la entidad existente desde la base de datos
            var existingEntrega = await _context.EntregaMntCrgModel
                                                .FirstOrDefaultAsync(e => e.IdEntregaMntCrg == id);

            if (existingEntrega == null)
            {
                return NotFound();
            }

            // Actualizar las propiedades de la entidad con los nuevos valores
            existingEntrega.EvidenciaImagen1File = entregaMntCrgModel.EvidenciaImagen1File;
            existingEntrega.EvidenciaImagen2File = entregaMntCrgModel.EvidenciaImagen2File;
            // ... (actualizar otras propiedades)

            // Actualizar las imágenes solo si se proporcionan nuevos archivos
            if (entregaMntCrgModel.EvidenciaImagen1File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen1File.CopyToAsync(ms);
                    existingEntrega.EvidenciaImagen1 = ms.ToArray();
                    existingEntrega.EvidenciaImagen1Base64 = Convert.ToBase64String(existingEntrega.EvidenciaImagen1);
                }
            }

            if (entregaMntCrgModel.EvidenciaImagen2File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen2File.CopyToAsync(ms);
                    existingEntrega.EvidenciaImagen2 = ms.ToArray();
                    existingEntrega.EvidenciaImagen2Base64 = Convert.ToBase64String(existingEntrega.EvidenciaImagen2);
                }
            }

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
            // Carga la entrega actual desde la base de datos
            var existingEntrega = await _context.EntregaMntCrgModel.FindAsync(id);

            // Actualiza solo los campos necesarios (propiedades escalares)
            _context.Entry(existingEntrega).CurrentValues.SetValues(entregaMntCrgModel);

            // Actualiza las propiedades específicas de las imágenes si se proporcionan nuevas
            if (entregaMntCrgModel.EvidenciaImagen1File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen1File.CopyToAsync(ms);
                    existingEntrega.EvidenciaImagen1 = ms.ToArray();
                    existingEntrega.EvidenciaImagen1Base64 = Convert.ToBase64String(existingEntrega.EvidenciaImagen1);
                }
            }

            if (entregaMntCrgModel.EvidenciaImagen2File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await entregaMntCrgModel.EvidenciaImagen2File.CopyToAsync(ms);
                    existingEntrega.EvidenciaImagen2 = ms.ToArray();
                    existingEntrega.EvidenciaImagen2Base64 = Convert.ToBase64String(existingEntrega.EvidenciaImagen2);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
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

            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
            TempData["FailRecoleccion"] = "La recoleccion no pudo ser completada";
            return View(entregaMntCrgModel);
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
                .Include(e => e.Montacarga)
                .FirstOrDefaultAsync(m => m.IdEntregaMntCrg == id);

            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }

            // Obtén el IdMontacargas de la entidad principal
            var idMontacargas = entregaMntCrgModel.idMontacargas;

            // Realiza una segunda consulta para obtener el MontacargasModel
            var montacargasModel = await _context.MontacargasModel
                .FirstOrDefaultAsync(m => m.IdMontacargas == idMontacargas);

            if (montacargasModel == null)
            {
                return NotFound();
            }

            // Almacena los datos en ViewBag
            entregaMntCrgModel.MarcaMontacargas = montacargasModel.Marca;
            entregaMntCrgModel.ModeloMontacargas = montacargasModel.Modelo;
            entregaMntCrgModel.NumeroSerieMontacargas = montacargasModel.NumeroSerie;
            entregaMntCrgModel.NumeroEconomicoMontacargas = montacargasModel.NumeroEconomico;

            //return new ViewAsPdf("ViewReportePDF", entregaMntCrgModel)
            //{
            //    FileName = $"Entrega Equipo en Renta {entregaMntCrgModel.IdEntregaMntCrg}.pdf",
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            //    PageSize = Rotativa.AspNetCore.Options.Size.A4,
            //    CustomSwitches = $"--footer-center \"Folio {entregaMntCrgModel.IdEntregaMntCrg} - Página [page]\" --footer-font-size 10",
            //};

            return View(entregaMntCrgModel);
        }



    }

}
