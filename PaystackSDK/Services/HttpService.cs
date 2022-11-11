using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PaystackSDK.Models;

namespace PaystackSDK.Services
{
    internal class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<TData>> PostAsync<TRequest, TData>(string url, TRequest request)
        {
            var message = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, message);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<TData>>(content);
        }
    }
}
