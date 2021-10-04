using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Net.Http;
using System.Text.Json;
using MetricsManagerServices.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MetricsManagerServices
{
    public abstract class ManagerBaseService<T>
            where T: BaseResponse
    {
        protected IHttpClientFactory _clientFactory { get; }
        protected ManagerBaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public virtual List<T> GetMetric(string requestUrl)
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream =  response.Content.ReadAsStreamAsync().Result;
                var metricResponse = JsonSerializer.DeserializeAsync
                    <List<T>>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
                return metricResponse;
            }
            throw new Exception();
        }
    }
}
