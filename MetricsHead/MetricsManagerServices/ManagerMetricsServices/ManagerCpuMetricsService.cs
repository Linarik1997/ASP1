using MetricsManagerServices.Models.MetricsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.ManagerMetricsServices
{
    public class ManagerCpuMetricsService: ManagerBaseService<CpuResponse>
    {
        public ManagerCpuMetricsService(IHttpClientFactory clientFactory) : base(clientFactory) { }
        public List<CpuResponse> GetMetric() => base.GetMetric("http://localhost:24583/api/cpu/metrics");
        public List<CpuResponse> GetMetric(DateTime from, DateTime to) => base.GetMetric($"http://localhost:24583/api/cpu/metrics/from/{from}/to/{to}");
    }
}
