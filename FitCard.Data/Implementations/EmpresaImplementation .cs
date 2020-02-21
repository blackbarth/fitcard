using FitCard.Data.Context;
using FitCard.Data.Repository;
using FitCard.Domain.Entities;
using FitCard.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FitCard.Data.Implementations
{
    public class EmpresaImplementation : BaseRepository<EmpresaEntity>, IEmpresaRepository
    {
        private DbSet<EmpresaEntity> _dataset;
        public EmpresaImplementation(FitCardContext context) : base(context)
        {
            _dataset = context.Set<EmpresaEntity>();
        }
    }
}