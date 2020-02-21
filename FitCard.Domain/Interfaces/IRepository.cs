using FitCard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitCard.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        T Insert(T item);
        Task<T> UpdateAsync(T item);
        T Update(T item);
        Task<bool> DeleteAsync(Guid id);
        bool Delete(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        List<T> Select();
        Task<bool> ExistAsync(Guid id);
    }
}