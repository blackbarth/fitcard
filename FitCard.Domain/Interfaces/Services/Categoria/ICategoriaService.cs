using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitCard.Domain.DTOs;
using FitCard.Domain.DTOs.Categoria;

namespace FitCard.Domain.Interfaces.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> Get(Guid id);
        Task<IEnumerable<CategoriaDTO>> GetAll();
        List<CategoriaDTO> Todos();
        Task<CategoriaDTOCreateResult> Post(CategoriaDTOCreate categoria);
        CategoriaDTOCreateResult Add(CategoriaDTOCreate categoria);
        Task<CategoriaDTOUpdateResult> Put(CategoriaDTOUpdate categoria);
        Task<bool> Delete(Guid id);
    }
}