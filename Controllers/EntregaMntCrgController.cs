using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ServicioMontacargas.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace ServicioMontacargas.Controllers
{
    public class EntregaMntCrgController : Controller
    {
        private readonly ServicioMontacargasContext _context;
        private readonly IConverter _converter;
        private readonly IViewRenderService _viewRenderService;

        public EntregaMntCrgController(ServicioMontacargasContext context, IConverter converter, IViewRenderService viewRenderService)
        {
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
        }

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

        private List<SelectListItem> ObtenerMontacargasOptions()
        {
            var montacargasDesdeBD = _context.MontacargasModel.ToList();

            // Mapea los resultados a SelectListItem
            var opciones = montacargasDesdeBD.Select(m => new SelectListItem
            {
                Value = m.IdMontacargas.ToString(),
                Text = $"{m.IdMontacargas} - {m.NumeroEconomico} - {m.Marca} - {m.Modelo} - {m.NumeroSerie}"
            }).ToList();

            return opciones;
        }

        // GET: EntregaMntCrg/Create
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
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
            return View(entregaMntCrgModel);
        }

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
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MontacargasOptions = ObtenerMontacargasOptions();
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

        public IActionResult MostrarPDFenPagina()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/EntregaMntCrg/ViewReportePDF/13";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);


            return File(archivoPDF, "application/pdf");
        }

        public async Task<IActionResult> DescargarPDF(int id)
        {
            // Obtén el modelo completo antes de renderizar la vista
            var entregaMntCrgModel = await _context.EntregaMntCrgModel
                .Include(e => e.Montacarga)
                .FirstOrDefaultAsync(m => m.IdEntregaMntCrg == id);

            if (entregaMntCrgModel == null)
            {
                return NotFound();
            }

            // Obtén el contenido HTML de la vista
            var viewHtml = await _viewRenderService.RenderToStringAsync("~/Views/EntregaMntCrg/ViewReportePDF.cshtml", entregaMntCrgModel);

            // Configuración para el PDF
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        HtmlContent = viewHtml
                    },
                    new ObjectSettings() // Objeto adicional para el pie de página
                    {
                        PagesCount = true,
                        HtmlContent = "<div style='text-align:center;'>Folio " + entregaMntCrgModel.IdEntregaMntCrg + "</div>",
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            // Conversión y descarga del PDF
            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "Entrega Equipo en Renta " + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }

    }
}
