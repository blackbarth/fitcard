using FitCard.Data.Context;
using FitCard.Data.Repository;
using FitCard.Domain.Entities;
using FitCard.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FitCard.Data.Implementations
{
    public class CategoriaImplementation : BaseRepository<CategoriaEntity>, ICategoriaRepository
    {
        private DbSet<CategoriaEntity> _dataset;
        public CategoriaImplementation(FitCardContext context) : base(context)
        {
            _dataset = context.Set<CategoriaEntity>();
        }
    }
}