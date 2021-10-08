using MetricsManagerServices.ManagerMetricsServices;
using MetricsManagerServices.Models.Dto;
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
        [HttpGet("/{id}")]
        public CpuDto Get([FromRoute] long id)
        {
            return _service.GetMetric(id);
        }
        [HttpGet("/{id}/from")]
        public CpuDto Get(
            [FromRoute] long id,
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return _service.GetMetric(id);
        }
    }
}
