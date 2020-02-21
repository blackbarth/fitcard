using AutoMapper;
using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.Interfaces.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitCard.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private ICategoriaService _serService;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaService serService, IMapper mapper)
        {
            _serService = serService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categorias = _serService.GetAll();
            return View(await categorias);

        }

        // GET: User/NovoOuEditar
        public async Task<ActionResult> NovoOuEditar(int id=0)
        {
            if (id == 0)
            {
                return View(new CategoriaDTOCreate());
            }
            else
            {
                var user = await _serService.Get(id);
                var u = _mapper.Map<CategoriaDTOCreate>(user);

                return View(u);
            }

        }

        // POST: Usuario/NovoOuEditar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NovoOuEditar([Bind("CategoriaNome,CategoriaFotoUrl,Id,CreateAt,UpdateAt")] CategoriaDTOCreate categoria)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (categoria.Id == 0)
                    {
                        await _serService.Post(categoria);
                    }
                    else
                    {
                        var usr = _mapper.Map<CategoriaDTO>(categoria);
                        var u = _mapper.Map<CategoriaDTOUpdate>(usr);
                        await _serService.Put(u);
                    }

                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public JsonResult Delete(int Id)
        {
            _serService.Delete(Id);
            return Json(new { status = "Success" });
        }
    }
}