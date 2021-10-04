using MetricsManagerServices.ManagerMetricsServices;
using MetricsManagerServices.Models.MetricsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManagerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricManagerController : ControllerBase
    {
        private readonly ManagerCpuMetricsService _service;
        public CpuMetricManagerController(ManagerCpuMetricsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<CpuResponse> Get()
        {
            return _service.GetMetric();
        }
        [HttpGet("from")]
        public List<CpuResponse> Get(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return _service.GetMetric(from,to);
        }
    }
}
