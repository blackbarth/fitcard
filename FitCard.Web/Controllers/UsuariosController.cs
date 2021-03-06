﻿using AutoMapper;
using FitCard.Domain.DTOs.User;
using FitCard.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FitCard.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private IUserService _serService;
        private readonly IMapper _mapper;

        public UsuariosController(IUserService service, IMapper mapper)
        {
            _serService = service;
            _mapper = mapper;
        }

        // GET: User
        public async Task<ActionResult> Index([FromForm]string BuscarString, int pagina = 1)
        {
            var usuarios = await  _serService.GetAll();

            var usa = from m in usuarios
                      select m;



            if (!string.IsNullOrEmpty(BuscarString))
            {
                usuarios = usa.Where(s => s.Nome.ToUpper().Contains(BuscarString.ToUpper()));
            }
            usuarios = usuarios.OrderBy(c => c.Nome).ToPagedList(pagina, 5);


            return View(usuarios);
        }


        // GET: Usuarios/NovoOuEditar
        public async Task<ActionResult> NovoOuEditar(int id = 0)
        {
            if (id == 0)
            {
                return View(new UserDTOCreate());
            }
            else
            {
                var user = await _serService.Get(id);
                var u = _mapper.Map<UserDTOCreate>(user);

                return View(u);
            }

        }

        // POST: Usuarios/NovoOuEditar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NovoOuEditar([Bind("Nome,Email,Id,CreateAt,UpdateAt")] UserDTOCreate usuario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (usuario.Id == 0)
                    {
                        await _serService.Post(usuario);
                    }
                    else
                    {
                        var usr = _mapper.Map<UserDTO>(usuario);
                        var u = _mapper.Map<UserDTOUpdate>(usr);
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

        [HttpPost]
        public async Task<JsonResult> Delete(int Id)
        {
            await _serService.Delete(Id);
            return Json(new { status = "Success" });
        }
    }
}