using System.Threading.Tasks;
using FitCard.Domain.Entities;
using FitCard.Domain.Interfaces;

namespace FitCard.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}