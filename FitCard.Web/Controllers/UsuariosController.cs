using AutoMapper;
using FitCard.Domain.DTOs.User;
using FitCard.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index()
        {
            var usuarios = _serService.GetAll();
            return View(await usuarios);
        }


        // GET: Usuarios/NovoOuEditar
        public async Task<ActionResult> NovoOuEditar(Guid id)
        {
            if (id == Guid.Empty)
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
                    if (usuario.Id == Guid.Empty)
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


        public JsonResult Delete(Guid Id)
        {
            _serService.Delete(Id);
            return Json(new { status = "Success" });
        }
    }
}