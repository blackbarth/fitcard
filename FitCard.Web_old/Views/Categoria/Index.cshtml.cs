using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitCard.Data.Context;
using FitCard.Domain.Entities;

namespace FitCard.Web
{
    public class IndexModel : PageModel
    {
        private readonly FitCard.Data.Context.FitCardContext _context;

        public IndexModel(FitCard.Data.Context.FitCardContext context)
        {
            _context = context;
        }

        public IList<CategoriaEntity> CategoriaEntity { get;set; }

        public async Task OnGetAsync()
        {
            CategoriaEntity = await _context.Categoria.ToListAsync();
        }
    }
}
