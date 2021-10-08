using AutoMapper;
using Core.Models;
using MetricsManagerServices.Mapper;
using MetricsManagerServices.Models.Request;

namespace MetricsManagerServices.MetricsManagerMapper
{
    public class MetricsManagerMapper : IMetricManagerMapper
    {
        public MetricsManagerMapper()
        {
            var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<AgentRequest, AgentInfo>().
               IgnoreAllPropertiesWithAnInaccessibleSetter());
            Mapper = config.CreateMapper();
        }
        protected IMapper Mapper { get; set; }
        public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;

        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }
    }
}
