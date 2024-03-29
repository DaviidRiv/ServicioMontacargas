﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace ServicioMontacargas.Auths
{
    public class AutorizacionOperadorGAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Obtener datos del usuario actual
            var userId = context.HttpContext.Session.GetString("IdUsuario");
            var rol = context.HttpContext.Session.GetString("RolUser");

            if (userId == null || (rol != "Administrador" && rol != "Operador Grua"))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);

                // Intenta realizar un cast a tu controlador específico
                if (context.Controller is Controller Login)
                {
                    // Almacena el mensaje en TempData del controlador específico
                    Login.TempData["ErrorSession"] = "Usuario No Autorizado.";
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
