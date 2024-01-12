using Microsoft.AspNetCore.Mvc;

namespace ServicioMontacargas.Controllers
{
    public class ChecklistController : Controller
    {
        public IActionResult Proceso()
        {
            return View();
        }
    }
}
