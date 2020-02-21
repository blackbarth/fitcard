using AutoMapper;
using FitCard.Domain.DTOs.Empresa;
using FitCard.Domain.Interfaces.Services.Categoria;
using FitCard.Domain.Interfaces.Services.Empresa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitCard.Domain.Entities;

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

        public async Task<ActionResult> Index()
        {
            var empresas = await _service.GetAll();
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
    }
}