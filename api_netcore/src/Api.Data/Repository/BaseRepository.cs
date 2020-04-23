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

                //o termo await faz parte do método async, salva o objeto usando o contexto
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //retorna o que foi inserido
            return item;
        }


        /// <summary>
        /// Método async para atualizar o objeto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                //Procura o objeto no banco!
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }

                //Caso ele exista informa a data de modificação e reforça a de criação!
                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                //Atualiza as informações novas e salva no banco!
                _context.Entry(result).CurrentValues.SetValues(item);

                //ele faz o commit ou o roolback
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //retorna o que foi atualizado
            return item;
        }


        /// <summary>
        /// Método async para deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                //Procura o objeto no banco!
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id == id);
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);

                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     

        /// <summary>
        /// Método async para buscar todos os registros
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SelectAcync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Método async para buscar um objeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
       
    }
}
