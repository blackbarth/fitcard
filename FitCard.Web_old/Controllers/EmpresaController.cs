using Microsoft.AspNetCore.Mvc;

namespace FitCard.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}