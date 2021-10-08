using Core.Interfaces;
using Core.Models;
using MetricsManagerServices.Mapper;
using MetricsManagerServices.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.AgentsManagerService
{
    public class AgentManager
    {
        private readonly IMetricManagerMapper _mapper;
        private readonly IDbRepository<AgentInfo> _repo;
        public AgentManager(IDbRepository<AgentInfo> repo, IMetricManagerMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public AgentInfo GetById(long id)
        {
            var agent = _repo.Get().FirstOrDefault(s => s.Id.Equals(id));
            return agent;
        }
        public long GetId(AgentRequest request)
        {
            _ = request ?? throw new ArgumentException(nameof(request));
            var dto = _mapper.Map<AgentInfo>(request);
            var agent = _repo.Get().FirstOrDefault(x => x.Uri.Equals(dto.Uri) && x.Name.Equals(dto.Name));
            _ = agent ?? throw new ArgumentNullException(nameof(agent));
            return agent.Id;
        }
        public bool IsKnown(string uri)
        {
            var agent = _repo.Get().FirstOrDefault(s => s.Uri.Equals(uri));
            if(agent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<AgentInfo> AddAgent(AgentRequest agent)
        {
            var dto = new AgentInfo();
            _mapper.Map(agent, dto);
            if (IsKnown(dto.Uri))
            {
                return null; //Identify that this agent Uri is already registered
            }
            return await _repo.AddAsync(dto);
        }
        public async Task Enable(long id)
        {
            var agent = _repo.Get().FirstOrDefault(s => s.Id.Equals(id));
            agent.IsEnabled = true;
            await _repo.UpdateAsync(agent);
        }
        public async Task Disable(long id)
        {
            var agent = _repo.Get().FirstOrDefault(s => s.Id.Equals(id));
            agent.IsEnabled = false;
            await _repo.UpdateAsync(agent);
        }
        public string GetUri(long id)
        {
            var agent = GetById(id);
            if(agent == null)
            {
                throw new Exception();
            }
            return agent.Uri;
        }
    }
}
