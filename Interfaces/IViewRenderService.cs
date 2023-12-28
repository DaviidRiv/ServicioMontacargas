using System.Threading.Tasks;

namespace ServicioMontacargas.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
        string GetViewPath(string viewName);
    }
}
