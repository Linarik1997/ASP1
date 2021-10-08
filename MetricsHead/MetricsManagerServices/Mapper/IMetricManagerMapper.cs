using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.Mapper
{
    public interface IMetricManagerMapper
    {
        /// <summary>
        /// Провайдер конфигурации для Mapper
        /// </summary>
        IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Конвертирует объекб в объект типа <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Тип, в который конвертируется объект</typeparam>
        /// <param name="source">Исходный объект</param>
        /// <returns>Результирующий объект</returns>
        T Map<T>(object source);

        /// <summary>
        /// Конвертирует объект в объект типа <typeparamref name="TDestination"/>
        /// </summary>
        /// <typeparam name="TSource">Исходный тип</typeparam>
        /// <typeparam name="TDestination">Тип, в который конвертируется объект</typeparam>
        /// <param name="source">Исходный объект</param>
        /// <param name="destination">Целевой объект</param>
        void Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
