using FitCard.Domain.DTOs.Categoria;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitCard.Domain.Interfaces.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> Get(int id);
        Task<IEnumerable<CategoriaDTO>> GetAll();
        List<CategoriaDTO> Todos();
        Task<CategoriaDTOCreateResult> Post(CategoriaDTOCreate categoria);
        CategoriaDTOCreateResult Add(CategoriaDTOCreate categoria);
        Task<CategoriaDTOUpdateResult> Put(CategoriaDTOUpdate categoria);
        Task<bool> Delete(int id);
    }
}