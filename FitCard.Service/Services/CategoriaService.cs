using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitCard.Domain.DTOs;
using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.Entities;
using FitCard.Domain.Interfaces;
using FitCard.Domain.Interfaces.Services.Categoria;
using FitCard.Domain.Models;

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

        public async Task<CategoriaDTO> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            var cat = _mapper.Map<CategoriaDTO>(entity) ?? new CategoriaDTO();
            return cat;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            var dto = _mapper.Map<IEnumerable<CategoriaDTO>>(listEntity);
            return dto;
        }

        public async Task<CategoriaDTOCreateResult> Post(CategoriaDTOCreate categoria)
        {
            var model = _mapper.Map<CategoriaModel>(categoria);
            var entity = _mapper.Map<CategoriaEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CategoriaDTOCreateResult>(result);
        }

        public CategoriaDTOCreateResult Add(CategoriaDTOCreate categoria)
        {
            var model = _mapper.Map<CategoriaModel>(categoria);
            var entity = _mapper.Map<CategoriaEntity>(model);
            var result = _repository.Insert(entity);
            return _mapper.Map<CategoriaDTOCreateResult>(result);
        }

        public async Task<CategoriaDTOUpdateResult> Put(CategoriaDTOUpdate categoria)
        {
            var model = _mapper.Map<CategoriaModel>(categoria);
            var entity = _mapper.Map<CategoriaEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CategoriaDTOUpdateResult>(result);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public List<CategoriaDTO> Todos()
        {
            var listEntity = _repository.Select();
            var dto = _mapper.Map<List<CategoriaDTO>>(listEntity);
            return dto;
        }

    }
}
