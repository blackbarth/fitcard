using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitCard.Domain.DTOs;
using FitCard.Domain.DTOs.Empresa;

namespace FitCard.Domain.Interfaces.Services.Empresa
{
    public interface IEmpresaService
    {
        Task<EmpresaDTO> Get(int id);
        Task<IEnumerable<EmpresaDTO>> GetAll();
        Task<EmpresaDTOCreateResult> Post(EmpresaDTOCreate empresa);
        Task<EmpresaDTOUpdateResult> Put(EmpresaDTOUpdate empresa);
        Task<bool> Delete(int id);
    }
}