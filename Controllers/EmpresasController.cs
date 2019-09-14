using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitCard.Context;
using FitCard.Models;

namespace FitCard.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly FitCardDBContext _context;

        public EmpresasController(FitCardDBContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var fitCardDBContext = _context.Empresas.Include(e => e.Categoria);
            return View(await fitCardDBContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Novo()
        {

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");

            var status = new[]{
                new SelectListItem(){ Value = "A", Text = "Ativo"},
                new SelectListItem(){ Value = "I", Text = "Inativo"}
                };
            ViewData["EmpresaStatus"] = new SelectList(status, "Value", "Text");

            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo([Bind("Id,EmpresaRazao,EmpresaNomeFantasia,EmpresaCNPJ,EmpresaEmail,EmpresaEndereco,EmpresaCidade,EmpresaEstado,EmpresaTelefone,EmpresaDataCadastro,EmpresaStatus,EmpresaAgencia,EmpresaConta,DataCadastro,CategoriaId")] Empresa empresa)
        {


            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", empresa.CategoriaId);
            var status = new[]{
                new SelectListItem(){ Value = "A", Text = "Ativo"},
                new SelectListItem(){ Value = "I", Text = "Inativo"}
                };
            ViewData["EmpresaStatus"] = new SelectList(status, "Value", "Text", empresa.EmpresaStatus);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", empresa.CategoriaId);
            var status = new[]{
                new SelectListItem(){ Value = "A", Text = "Ativo"},
                new SelectListItem(){ Value = "I", Text = "Inativo"}
                };
            ViewData["EmpresaStatus"] = new SelectList(status, "Value", "Text", empresa.EmpresaStatus);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,EmpresaRazao,EmpresaNomeFantasia,EmpresaCNPJ,EmpresaEmail,EmpresaEndereco,EmpresaCidade,EmpresaEstado,EmpresaTelefone,EmpresaDataCadastro,EmpresaStatus,EmpresaAgencia,EmpresaConta,DataCadastro,CategoriaId")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", empresa.CategoriaId);
            var status = new[]{
                new SelectListItem(){ Value = "A", Text = "Ativo"},
                new SelectListItem(){ Value = "I", Text = "Inativo"}
                };
            ViewData["EmpresaStatus"] = new SelectList(status, "Value", "Text", empresa.EmpresaStatus);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
