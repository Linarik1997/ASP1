using MetricsManagerServices.AgentsManagerService;
using MetricsManagerServices.Models.Dto;
using MetricsManagerServices.Models.MetricsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.ManagerMetricsServices
{
    public class ManagerCpuMetricsService: ManagerBaseService<CpuResponse,CpuDto>
    {
        public ManagerCpuMetricsService(IHttpClientFactory clientFactory, AgentManager agent) : base(clientFactory,agent) { }
    }
}
