using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Net.Http;
using System.Text.Json;
using MetricsManagerServices.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MetricsManagerServices.Models.Dto;
using MetricsManagerServices.AgentsManagerService;

namespace MetricsManagerServices
{
    public abstract class ManagerBaseService<TResponse,TDto>
            where TResponse : BaseResponse
            where TDto: BaseDto<TResponse>, new()
    {
        protected IHttpClientFactory _clientFactory { get; }
        protected AgentManager _agent { get; }
        protected ManagerBaseService(IHttpClientFactory clientFactory, AgentManager agent)
        {
            _clientFactory = clientFactory;
            _agent = agent;
        }
        public virtual TDto GetMetric(long id)
        {
            var response = GetResponse(id);
            return new TDto
            {
                Id = id,
                Name = _agent.GetById(id).Name,
                Content = response
            };
        }
        protected virtual List<TResponse> GetResponse(long id)
        {
            var client = _clientFactory.CreateClient();
            var requestUrl = _agent.GetUri(id);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream =  response.Content.ReadAsStreamAsync().Result;
                var metricResponse = JsonSerializer.DeserializeAsync
                    <List<TResponse>>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
                return metricResponse;
            }
            throw new Exception();
        }
    }
}
