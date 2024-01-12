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
    public class ClientesController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public ClientesController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return _context.ClientesModel != null ?
                        View(await _context.ClientesModel.ToListAsync()) :
                        Problem("Entity set 'ServicioMontacargasContext.ClientesModel'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientesModel == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.ClientesModel
                .FirstOrDefaultAsync(m => m.IdClientes == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClientes,Nombre,FechaRegistro,Ubicacion")] ClientesModel clientesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientesModel == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.ClientesModel.FindAsync(id);
            if (clientesModel == null)
            {
                return NotFound();
            }
            return View(clientesModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClientes,Nombre,FechaRegistro,Ubicacion")] ClientesModel clientesModel)
        {
            if (id != clientesModel.IdClientes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesModelExists(clientesModel.IdClientes))
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
            return View(clientesModel);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientesModel == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.ClientesModel
                .FirstOrDefaultAsync(m => m.IdClientes == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientesModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.ClientesModel'  is null.");
            }
            var clientesModel = await _context.ClientesModel.FindAsync(id);
            if (clientesModel != null)
            {
                _context.ClientesModel.Remove(clientesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesModelExists(int id)
        {
            return (_context.ClientesModel?.Any(e => e.IdClientes == id)).GetValueOrDefault();
        }
    }
}
