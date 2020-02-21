using FitCard.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitCard.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTO> Get(int id);
        Task<IEnumerable<UserDTO>> GetAll();
        IEnumerable<UserDTO> GetAllNoAsync();
        Task<UserDTOCreateResult> Post(UserDTOCreate user);
        Task<UserDTOUpdateResult> Put(UserDTOUpdate user);
        Task<bool> Delete(int id);
    }
}