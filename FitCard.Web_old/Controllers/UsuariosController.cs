using Microsoft.AspNetCore.Mvc;

namespace FitCard.Web.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}