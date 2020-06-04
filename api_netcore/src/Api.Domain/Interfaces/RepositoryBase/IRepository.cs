using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.RepositoryBase
{
    /// <summary>
    ///  Implementada na classe: BaseRepository, faz o CRUD generico no banco(EntityFramework)!   
    /// </summary>
    /// <typeparam name="T">entidade obrigatoria</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(Guid id);

        Task<T> SelectAsync(Guid id);

        Task<IEnumerable<T>> SelectAcync();

        Task<bool> ExistAsync (Guid id);
    }
}
