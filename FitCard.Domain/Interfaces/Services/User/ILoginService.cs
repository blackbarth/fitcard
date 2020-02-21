using FitCard.Domain.DTOs.User;
using System.Threading.Tasks;

namespace FitCard.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}