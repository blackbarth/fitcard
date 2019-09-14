using FitCard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitCard.Context
{
    public class FitCardDBContext : DbContext
    {


        public FitCardDBContext(DbContextOptions<FitCardDBContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
