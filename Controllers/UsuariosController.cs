using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ServicioMontacargas.Auths;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;

namespace ServicioMontacargas.Controllers
{
    [AutorizacionAdmin]
    public class UsuariosController : Controller
    {
        private readonly ServicioMontacargasContext _context;

        public UsuariosController(ServicioMontacargasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.UsuariosModel != null ?
                      View(await _context.UsuariosModel.ToListAsync()) :
                      Problem("Entity set 'ServicioMontacargasContext.UsuariosModel'  is null.");
        }


        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosModel == null)
            {
                return NotFound();
            }

            var usuariosModel = await _context.UsuariosModel
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuariosModel == null)
            {
                return NotFound();
            }

            return View(usuariosModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,ApellidoP,ApellidoM,Password,rolUser")] UsuariosModel usuariosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuariosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuariosModel);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuariosModel == null)
            {
                return NotFound();
            }

            var usuariosModel = await _context.UsuariosModel.FindAsync(id);
            if (usuariosModel == null)
            {
                return NotFound();
            }
            return View(usuariosModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,ApellidoP,ApellidoM,Password,rolUser")] UsuariosModel usuariosModel)
        {
            if (id != usuariosModel.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosModelExists(usuariosModel.IdUsuario))
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
            return View(usuariosModel);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosModel == null)
            {
                return NotFound();
            }

            var usuariosModel = await _context.UsuariosModel
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuariosModel == null)
            {
                return NotFound();
            }

            return View(usuariosModel);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuariosModel == null)
            {
                return Problem("Entity set 'ServicioMontacargasContext.UsuariosModel'  is null.");
            }
            var usuariosModel = await _context.UsuariosModel.FindAsync(id);
            if (usuariosModel != null)
            {
                _context.UsuariosModel.Remove(usuariosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosModelExists(int id)
        {
            return (_context.UsuariosModel?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
