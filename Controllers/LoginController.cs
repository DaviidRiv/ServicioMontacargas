﻿using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ServicioMontacargas.Data;
using ServicioMontacargas.Models;
using System.Security.Claims;

namespace ServicioMontacargas.Controllers
{
    public class LoginController : Controller
    {
        private readonly ServicioMontacargasContext _context;
        private readonly IDistributedCache _cache;

        public LoginController(ServicioMontacargasContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public IActionResult Login()
        {
            if (TempData.ContainsKey("ErrorSession"))
            {
                ViewBag.ErrorSession = TempData["ErrorSession"]?.ToString();
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string nombre, string apellidoP, string apellidoM, string password)
        {
            // Buscar al usuario en la base de datos
            var usuario = _context.UsuariosModel.FirstOrDefault(u =>
                u.Nombre == nombre &&
                u.ApellidoP == apellidoP &&
                u.ApellidoM == apellidoM &&
                u.Password == password);

            if (usuario != null)
            {
                HttpContext.Session.SetString("IdUsuario", usuario.IdUsuario.ToString());
                HttpContext.Session.SetString("Nombre", usuario.Nombre);
                HttpContext.Session.SetString("ApellidoP", usuario.ApellidoP);
                HttpContext.Session.SetString("ApellidoM", usuario.ApellidoM);
                HttpContext.Session.SetString("RolUser", usuario.rolUser);
                HttpContext.Session.SetString("NombreC", usuario.Nombre + " " + usuario.ApellidoP + " " + usuario.ApellidoM);

                if(usuario.rolUser == "Administrador")
                {
                    await _context.ActualizarHorasMtto();
                    return RedirectToAction("Index", "Home");
                }
                else if (usuario.rolUser == "Técnico" || usuario.rolUser == "Operador Grua" || usuario.rolUser == "Montacarguista")
                {
                    return RedirectToAction("Modulos", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Autenticación fallida
                ViewBag.ErrorMessage = "Nombre, Apellidos o Contraseña Incorrectos.";
                return View("Login");
            }
        }

        public IActionResult LogOut()
        {
            // Elimina los datos de la sesión al cerrar sesión
            HttpContext.Session.Remove("IdUsuario");
            HttpContext.Session.Remove("Nombre");
            HttpContext.Session.Remove("ApellidoP");
            HttpContext.Session.Remove("ApellidoM");
            HttpContext.Session.Remove("RolUser");

            // Puedes también invalidar completamente la sesión si lo deseas
             HttpContext.Session.Clear();

            ViewBag.CerrarSesion = "Sesión Cerrada Correctamente.";
            return View("Login");
        }

    }
}
