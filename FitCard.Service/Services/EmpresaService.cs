using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitCard.Domain.DTOs;
using FitCard.Domain.DTOs.Empresa;
using FitCard.Domain.Entities;
using FitCard.Domain.Interfaces;
using FitCard.Domain.Interfaces.Services.Empresa;
using FitCard.Domain.Models;

namespace FitCard.Service.Services
{
    public class EmpresaService : IEmpresaService
    {
        public IRepository<EmpresaEntity> _repository;
        private readonly IMapper _mapper;

        public EmpresaService(IRepository<EmpresaEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmpresaDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<EmpresaDTO>(entity) ?? new EmpresaDTO();
        }

        public async Task<IEnumerable<EmpresaDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            var dto = _mapper.Map<IEnumerable<EmpresaDTO>>(listEntity);
            return dto;
        }

        public async Task<EmpresaDTOCreateResult> Post(EmpresaDTOCreate empresa)
        {
            var model = _mapper.Map<EmpresaModel>(empresa);
            var entity = _mapper.Map<EmpresaEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<EmpresaDTOCreateResult>(result);
        }

        public async Task<EmpresaDTOUpdateResult> Put(EmpresaDTOUpdate empresa)
        {
            var model = _mapper.Map<EmpresaModel>(empresa);
            var entity = _mapper.Map<EmpresaEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<EmpresaDTOUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}