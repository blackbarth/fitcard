using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitCard.Domain.DTOs;
using FitCard.Domain.DTOs.User;
using FitCard.Domain.Entities;
using FitCard.Domain.Interfaces;
using FitCard.Domain.Interfaces.Services.User;
using FitCard.Domain.Models;

namespace FitCard.Service.Services
{
    public class UserService : IUserService
    {
        public IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            var user = _mapper.Map<UserDTO>(entity);
            return user ?? new UserDTO();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            var dto = _mapper.Map<IEnumerable<UserDTO>>(listEntity);
            return dto;
        }

        public async Task<UserDTOCreateResult> Post(UserDTOCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDTOCreateResult>(result);
        }

        public async Task<UserDTOUpdateResult> Put(UserDTOUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDTOUpdateResult>(result);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public IEnumerable<UserDTO> GetAllNoAsync()
        {
            var listEntity = _repository.Select();
            var dto = _mapper.Map<IEnumerable<UserDTO>>(listEntity);
            return dto;
        }
    }
}