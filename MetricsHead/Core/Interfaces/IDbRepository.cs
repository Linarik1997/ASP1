using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDbRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Получениие параметризируемых объектов из бд
        /// </summary>
        /// <returns>IQueryable дженерик объект</returns>
        IQueryable<TEntity> Get();


        /// <summary>
        /// Асинхронный метод добавления дженерик сущности в таблицу
        /// </summary>
        /// <param name="entity">Объект для добавления в таблицу</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);


        /// <summary>
        /// Асинхронный метод обновления дженерик сущности в таблице
        /// </summary>
        /// <param name="entity">Объект для обновления в таблице</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);


        /// <summary>
        /// Асинхронный метод удаления дженерик сущности из таблицы
        /// </summary>
        /// <param name="entity">Объект для удаления из таблицы</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
    }
}
