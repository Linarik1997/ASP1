using Core.Models;
using MetricsManagerServices.AgentsManagerService;
using MetricsManagerServices.Models.Request;
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
    public class AgentsController : ControllerBase
    {
        private readonly AgentManager _agentManager;
        public AgentsController(AgentManager agentManager)
        {
            _agentManager = agentManager;
        }
        [HttpPost("/register")]
        public async Task CreateAsync([FromQuery] AgentRequest request)
        {
            await  _agentManager.AddAgent(request);            
        }
        [HttpPut("/enable")]
        public async Task EnableAsync([FromQuery] long id)
        {
            var agent = _agentManager.GetById(id);
            _ = agent ?? throw new ArgumentException(nameof(agent));
            await _agentManager.Enable(id);
        }
        [HttpPut("/disable")]
        public async Task DisableAsync([FromQuery] long id)
        {
            var agent = _agentManager.GetById(id);
            _ = agent ?? throw new ArgumentException(nameof(agent));
            await _agentManager.Disable(id);
        }
        [HttpGet("/Id")]
        public long GetId([FromQuery] AgentRequest request)
        {
            return _agentManager.GetId(request);
        }
    }
}
