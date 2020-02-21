using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.Interfaces.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitCard.Web.ViewsComponents
{
    public class CategoriaNovoViewComponent : ViewComponent
    {
        private ICategoriaService _service;

        public CategoriaNovoViewComponent(ICategoriaService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CategoriaDTO novo = new CategoriaDTO();
            return View(novo);
        }
    }
}