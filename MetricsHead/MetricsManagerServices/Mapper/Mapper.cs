using AutoMapper;
using MetricsManagerServices.Models.MetricsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.Mapper
{
    class Mapper : IMapper
    {
        public Mapper()
        {

        }
        protected IMapper MapperOptions { get; set; }
        public IConfigurationProvider ConfigurationProvider => MapperOptions.ConfigurationProvider;

        public T Map<T>(object source)
        {
            throw new NotImplementedException();
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }
    }
}
