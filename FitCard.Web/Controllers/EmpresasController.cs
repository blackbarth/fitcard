using System;
using AutoMapper;
using FitCard.Domain.DTOs.Empresa;
using FitCard.Domain.Interfaces.Services.Categoria;
using FitCard.Domain.Interfaces.Services.Empresa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FitCard.Web.Controllers
{
    public class EmpresasController : Controller
    {
        private IEmpresaService _service;
        private ICategoriaService _serviceCategoria;
        private IMapper _mapper;

        public EmpresasController(IEmpresaService service, ICategoriaService serviceCategoria, IMapper mapper)
        {
            _service = service;
            _serviceCategoria = serviceCategoria;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index([FromForm]string BuscarString, int pagina = 1)
        {
            var empresas = await _service.GetAll();


            var emp = from m in empresas
                      select m;



            if (!string.IsNullOrEmpty(BuscarString))
            {
                empresas = emp.Where(s => s.EmpresaRazao.ToUpper().Contains(BuscarString.ToUpper()));
            }

            empresas = empresas.OrderBy(c => c.EmpresaRazao).ToPagedList(pagina, 5);


            return View(empresas);
        }


        // GET: empresas/NovoOuEditar
        public async Task<ActionResult> NovoOuEditar(int id)
        {
            var itemsCategorias = await _serviceCategoria.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();



            foreach (var categoriaDto in itemsCategorias)
            {
                items.Add(new SelectListItem { Text = categoriaDto.CategoriaNome, Value = categoriaDto.Id.ToString() });
            }


            ViewData["CategoriaId"] = new SelectList(items, "Value", "Text");

            var status = new[]{
                new SelectListItem(){ Value = "ATIVO", Text = "Ativo"},
                new SelectListItem(){ Value = "INATIVO", Text = "Inativo"}
            };
            ViewData["EmpresaStatus"] = new SelectList(status, "Value", "Text");


            if (id == 0)
            {
                return View(new EmpresaDTOCreate());
            }
            else
            {
                var emp = await _service.Get(id);
                var e = _mapper.Map<EmpresaDTOCreate>(emp);

                return View(e);
            }

        }

        // POST: empresas/NovoOuEditar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NovoOuEditar([Bind("EmpresaRazao,EmpresaNomeFantasia,EmpresaCNPJ,EmpresaEmail,EmpresaEndereco,EmpresaCidade,EmpresaEstado,EmpresaTelefone,EmpresaDataCadastro,EmpresaStatus,EmpresaAgencia,EmpresaConta,CategoriaId,Id,CreateAt,UpdateAt")] EmpresaDTOCreate empresa)
        {


            if (ModelState.IsValid)
            {
                if (empresa.Id == 0)
                {
                    empresa.EmpresaDataCadastro = DateTime.UtcNow;
                    await _service.Post(empresa);
                }
                else
                {
                    var usr = _mapper.Map<EmpresaDTO>(empresa);
                    var u = _mapper.Map<EmpresaDTOUpdate>(usr);
                    await _service.Put(u);
                }

                return RedirectToAction(nameof(Index));

            }
            var itemsCategorias = await _serviceCategoria.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();



            foreach (var categoriaDto in itemsCategorias)
            {
                items.Add(new SelectListItem { Text = categoriaDto.CategoriaNome, Value = categoriaDto.Id.ToString() });
            }

            //ViewData["CategoriaId"] = new SelectList(itemsCategorias, "CategoriaId", "CategoriaNome");
            ViewData["CategoriaId"] = new SelectList(items, "Value", "Text");

            var status = new[]{
                new SelectListItem(){ Value = "ATIVO", Text = "Ativo"},
                new SelectListItem(){ Value = "INATIVO", Text = "Inativo"}
            };
            ViewData["EmpresaStatus"] = new SelectList(status, "Value", "Text");

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int Id)
        {
            await _service.Delete(Id);
            return Json(new { status = "Success" });
        }
    }
}