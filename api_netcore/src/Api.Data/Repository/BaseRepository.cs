using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;

        private DbSet<T> _dataset;

        /// <summary>
        /// Método construtor que recebe uma injeção de dependencia, com a classe que faz 
        /// a conexao com o banco!
        /// </summary>
        /// <param name="context"> classe de conexao</param>
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método asyncrone que insere um novo objeto!
        /// </summary>
        /// <param name="item">objeto</param>
        /// <returns></returns>
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                //Caso o ID esteja vasio, é criado um id
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                //Salva a data da criação
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                //o termo await faz parte do método async, salva o objeto usnado o contexto
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public Task<IEnumerable<T>> SelectAcync()
        {
            throw new NotImplementedException();
        }

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
