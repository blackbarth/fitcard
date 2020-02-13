using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitCard.Domain.DTOs;
using FitCard.Domain.Entities;
using FitCard.Domain.Interfaces;
using FitCard.Domain.Interfaces.Services.Categoria;

namespace FitCard.Service.Services
{
    public class CategoriaService : ICategoriaService
    {
        public IRepository<CategoriaEntity> _repository;
        private readonly IMapper _mapper;
        public CategoriaService(IRepository<CategoriaEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<CategoriaDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaDTOCreateResult> Post(CategoriaDTOCreate user)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaDTOUpdateResult> Put(CategoriaDTOUpdate user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}