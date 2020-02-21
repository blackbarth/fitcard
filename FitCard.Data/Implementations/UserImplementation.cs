using System.Threading.Tasks;
using FitCard.Data.Context;
using FitCard.Data.Repository;
using FitCard.Domain.Entities;
using FitCard.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FitCard.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(FitCardContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}