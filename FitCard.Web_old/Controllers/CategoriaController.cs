using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.Interfaces.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FitCard.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult SwitchToTabs(string tabname)
        //{
        //    var vm = new CategoriaTabViewModel();
        //    switch (tabname)
        //    {
        //        case "Todos":
        //            vm.ActiveTab = Tab.Todos;
        //            break;
        //        case "Novo":
        //            vm.ActiveTab = Tab.Novo;
        //            break;
        //        default:
        //            vm.ActiveTab = Tab.Todos;
        //            break;
        //    }

        //    return RedirectToAction(nameof(CategoriaController.Index));
        //}

        public ActionResult Todos()
        {
            List<CategoriaDTO> lista = new List<CategoriaDTO>();
            return View(lista);
        }
    }
}