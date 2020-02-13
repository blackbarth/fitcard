using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitCard.Domain.DTOs;

namespace FitCard.Domain.Interfaces.Services.Empresa
{
    public interface IEmpresaService
    {
        Task<EmpresaDTO> Get(Guid id);
        Task<IEnumerable<EmpresaDTO>> GetAll();
        Task<EmpresaDTOCreateResult> Post(EmpresaDTOCreate user);
        Task<EmpresaDTOUpdateResult> Put(EmpresaDTOUpdate user);
        Task<bool> Delete(Guid id);
    }
}