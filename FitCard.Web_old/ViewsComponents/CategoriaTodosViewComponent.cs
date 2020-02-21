using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.Interfaces.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitCard.Web.ViewsComponents
{
    public class CategoriaTodosViewComponent : ViewComponent
    {
        private ICategoriaService _service;

        public CategoriaTodosViewComponent(ICategoriaService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoriaDTO> lista = _service.Todos();
            return View(lista);
        }
    }
}