using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitCard.Domain.DTOs;

namespace FitCard.Domain.Interfaces.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> Get(Guid id);
        Task<IEnumerable<CategoriaDTO>> GetAll();
        Task<CategoriaDTOCreateResult> Post(CategoriaDTOCreate user);
        Task<CategoriaDTOUpdateResult> Put(CategoriaDTOUpdate user);
        Task<bool> Delete(Guid id);
    }
}